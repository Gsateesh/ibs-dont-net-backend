using IBS.Modules.Sales.Application.Abstractions;
using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;
using IBS.SharedKernel.Time;
using Microsoft.EntityFrameworkCore;

namespace IBS.Modules.Sales.Application.Services;

/// <summary>Turns a line's specification into money, and a version's lines into its totals.</summary>
public interface IQuotationPricingService
{
    /// <summary>
    /// Loads the rates that could apply to the given items, once, so pricing a whole quotation
    /// is a single query rather than one per line.
    /// </summary>
    Task<RateCard> LoadRateCardAsync(IReadOnlyCollection<string> itemKeys, CancellationToken ct = default);

    /// <summary>
    /// Fills in <see cref="QuotationLineItem.BillableQuantity"/>, the rate and every amount on
    /// the line, from the specification already set on it.
    /// </summary>
    void PriceLine(QuotationLineItem line, RateCard card, decimal? rateOverride, decimal? catalogBasePrice);

    /// <summary>Rolls the priced lines up into room totals and the version's totals.</summary>
    void RecalculateTotals(Quotation quotation);
}

/// <inheritdoc cref="IQuotationPricingService" />
public sealed class QuotationPricingService(ISalesDbContext db, IClock clock) : IQuotationPricingService
{
    public async Task<RateCard> LoadRateCardAsync(
        IReadOnlyCollection<string> itemKeys, CancellationToken ct = default)
    {
        if (itemKeys.Count == 0) return new RateCard([], Today);

        var today = Today;

        var rows = await db.QuotationRates
            .AsNoTracking()
            .Where(r => r.IsActive && itemKeys.Contains(r.ItemKey) && r.EffectiveFrom <= today)
            .ToListAsync(ct);

        return new RateCard(rows, today);
    }

    public void PriceLine(
        QuotationLineItem line, RateCard card, decimal? rateOverride, decimal? catalogBasePrice)
    {
        line.BillableQuantity = BillableQuantityFor(line);

        // Three ways a rate is arrived at, in descending order of authority: the estimator typed
        // one, the catalogue lists one for a fixed-size product, or the rate card is consulted.
        if (rateOverride is not null)
        {
            line.Rate = Round(rateOverride.Value);
            line.IsRateOverridden = true;
        }
        else if (line.PricingType == QuotationPricingType.Catalog && catalogBasePrice is not null)
        {
            line.Rate = Round(catalogBasePrice.Value);
            line.IsRateOverridden = false;
        }
        else if (line.PricingType == QuotationPricingType.Custom)
        {
            // A custom line has no card behind it. Without a typed rate it is worth nothing yet,
            // which is correct: it shows as unpriced rather than quietly inventing a number.
            line.Rate = 0m;
            line.IsRateOverridden = false;
        }
        else
        {
            line.Rate = Round(card.Resolve(line) ?? 0m);
            line.IsRateOverridden = false;
        }

        var quantity = line.Quantity < 1 ? 1 : line.Quantity;
        line.Quantity = quantity;

        line.BaseAmount = Round(line.BillableQuantity * line.Rate * quantity);
        line.HardwareAmount = Round(line.HardwareAmount);
        line.AccessoryAmount = Round(line.AccessoryAmount);
        line.Amount = Round(line.BaseAmount + line.HardwareAmount + line.AccessoryAmount);
    }

    public void RecalculateTotals(Quotation quotation)
    {
        foreach (var room in quotation.Rooms)
        {
            room.RoomTotal = Round(room.LineItems.Sum(i => i.Amount));
        }

        quotation.Subtotal = Round(quotation.Rooms.Sum(r => r.RoomTotal));

        // Percent and flat amount are mutually exclusive; percent is authoritative when set, so
        // the stored amount always agrees with the percentage shown beside it on the PDF.
        quotation.DiscountAmount = quotation.DiscountPercent is { } percent
            ? Round(quotation.Subtotal * percent / 100m)
            : Round(quotation.DiscountAmount);

        // A discount larger than the quotation would make the taxable value negative and the GST
        // a credit. Clamp rather than reject: the estimator is mid-edit, not attacking anything.
        if (quotation.DiscountAmount > quotation.Subtotal)
        {
            quotation.DiscountAmount = quotation.Subtotal;
        }

        if (quotation.DiscountAmount < 0m) quotation.DiscountAmount = 0m;

        quotation.TaxableValue = Round(quotation.Subtotal - quotation.DiscountAmount);
        quotation.GstAmount = Round(quotation.TaxableValue * quotation.GstRatePercent / 100m);
        quotation.TransportCharges = Round(quotation.TransportCharges);
        quotation.InstallationCharges = Round(quotation.InstallationCharges);

        // Transport and installation sit after tax, as their own lines on the PDF, which is how
        // the pricing note describes them.
        quotation.GrandTotal = Round(
            quotation.TaxableValue
            + quotation.GstAmount
            + quotation.TransportCharges
            + quotation.InstallationCharges);
    }

    /// <summary>
    /// What the rate is charged against. Depth is only consulted for volume work, and a counted
    /// item bills at one unit so the rate is the price of the thing itself.
    /// </summary>
    private static decimal BillableQuantityFor(QuotationLineItem line)
    {
        var width = line.WidthFeet ?? 0m;
        var height = line.HeightFeet ?? 0m;
        var depth = line.DepthFeet ?? 0m;

        var quantity = line.UnitOfMeasure switch
        {
            QuotationUnitOfMeasure.SquareFeet => width * height,
            QuotationUnitOfMeasure.RunningFeet => width,
            QuotationUnitOfMeasure.CubicFeet => width * height * depth,
            QuotationUnitOfMeasure.Number => 1m,
            _ => 0m
        };

        return quantity < 0m ? 0m : decimal.Round(quantity, 3, MidpointRounding.AwayFromZero);
    }

    /// <summary>IClock exposes an instant, not a date; the rate card is keyed by day.</summary>
    private DateOnly Today => DateOnly.FromDateTime(clock.UtcNow.UtcDateTime);

    private static decimal Round(decimal value) => decimal.Round(value, 2, MidpointRounding.AwayFromZero);
}

/// <summary>
/// The rates in play for one pricing pass, with the lookup that picks between them.
/// </summary>
/// <remarks>
/// A rate row may leave any of carcass, shutter and finish empty, which means "any". That is
/// what lets a small placeholder card still return a rate for every combination somebody can
/// pick, instead of leaving most of the picker silently priced at zero - and it is also how the
/// real card will express a rate that genuinely does not vary by finish.
/// </remarks>
public sealed class RateCard(IReadOnlyList<QuotationRate> rows, DateOnly asOf)
{
    public DateOnly AsOf { get; } = asOf;

    /// <summary>
    /// The best rate for this line, or null when the card says nothing about it. Specificity
    /// wins first, then the later effective date - so a March override beats a January one, and
    /// a row naming the exact finish beats a wildcard whatever its date.
    /// </summary>
    public decimal? Resolve(QuotationLineItem line)
    {
        QuotationRate? best = null;
        var bestScore = -1;

        foreach (var row in rows)
        {
            if (!string.Equals(row.ItemKey, line.ItemKey, StringComparison.OrdinalIgnoreCase)) continue;

            // A variant is part of the item's identity, so a rate for "wall units in glass" must
            // never be handed to "wall units in wood". Unlike the material axes, this is not a
            // wildcard when empty - it either matches or the row is not about this line.
            if (!string.Equals(row.VariantKey, line.VariantKey, StringComparison.OrdinalIgnoreCase)) continue;

            var carcass = Match(row.CarcassMaterial, line.CarcassMaterial);
            if (carcass < 0) continue;

            var shutter = Match(row.ShutterMaterial, line.ShutterMaterial);
            if (shutter < 0) continue;

            var finish = Match(row.Finish, line.Finish);
            if (finish < 0) continue;

            // Weighted so a row naming the carcass outranks one naming only the finish. The
            // weights only have to order the axes, not mean anything on their own.
            var score = (carcass * 4) + (shutter * 2) + finish;

            if (score > bestScore || (score == bestScore && best is not null && row.EffectiveFrom > best.EffectiveFrom))
            {
                best = row;
                bestScore = score;
            }
        }

        return best?.RatePerUnit;
    }

    /// <summary>1 for an exact match, 0 for a wildcard, -1 when the row rules this line out.</summary>
    private static int Match(string rowValue, string? lineValue)
    {
        if (string.IsNullOrWhiteSpace(rowValue)) return 0;

        return string.Equals(rowValue, lineValue, StringComparison.OrdinalIgnoreCase) ? 1 : -1;
    }
}
