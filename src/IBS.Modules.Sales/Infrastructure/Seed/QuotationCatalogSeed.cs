using System.Security.Cryptography;
using System.Text;

using IBS.Modules.Sales.Domain.Entities;
using IBS.Modules.Sales.Domain.Enums;

namespace IBS.Modules.Sales.Infrastructure.Seed;

/// <summary>
/// The starting contents of the quotation item picker and its rate card, seeded through the
/// model so the same rows exist in every environment.
/// </summary>
/// <remarks>
/// <para>
/// The rates here are <b>placeholders</b>, not the studio's real pricing. Only the three
/// figures taken from the working mock (base units at 4,200, wall units in wood at 3,600 and
/// in glass at 3,800 per sq.ft) are grounded in anything; everything else is a round number
/// chosen to make the arithmetic on screen obviously fake rather than plausibly wrong. They
/// exist so the tab can be built and demonstrated before the real card is supplied.
/// </para>
/// <para>
/// Ids are derived from each row's natural key rather than a running counter, so inserting an
/// item in the middle of a list later does not renumber every row after it - which would show
/// up as a migration that deletes and reinserts the whole catalogue.
/// </para>
/// </remarks>
public static class QuotationCatalogSeed
{
    /// <summary>Fixed so migrations are byte-identical between runs.</summary>
    private static readonly DateTimeOffset SeededAt = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    private static readonly DateOnly EffectiveFrom = new(2026, 1, 1);

    // --- Category keys -----------------------------------------------------------

    private const string Modular = "modular";
    private const string CustomWork = "custom-work";
    private const string Furniture = "furniture";
    private const string Furnishings = "furnishings";
    private const string Services = "services";

    /// <summary>Room key meaning "offered in every room".</summary>
    private const string AnyRoom = "";

    private static readonly Dictionary<string, string> CategoryNames = new(StringComparer.Ordinal)
    {
        [Modular] = "Modular",
        [CustomWork] = "Custom work",
        [Furniture] = "Furniture",
        [Furnishings] = "Furnishings",
        [Services] = "Services"
    };

    /// <summary>The bedroom-shaped rooms, which all offer the same modular items.</summary>
    private static readonly string[] Bedrooms =
        ["master-bedroom", "bedroom", "kids-bedroom", "guest-bedroom"];

    public static IReadOnlyList<QuotationCatalogEntry> Entries { get; } = BuildEntries();

    public static IReadOnlyList<QuotationRate> Rates { get; } = BuildRates();

    // --- Catalogue ---------------------------------------------------------------

    private static List<QuotationCatalogEntry> BuildEntries()
    {
        var entries = new List<QuotationCatalogEntry>();

        // Kitchen. Wall units and tall units carry variants: each variant is measured and rated
        // separately, so each adds its own line rather than nesting under a parent.
        Add(entries, "kitchen", Modular, "base-units", "Base Units");
        Add(entries, "kitchen", Modular, "wall-units", "Wall Units", "wooden", "Wooden");
        Add(entries, "kitchen", Modular, "wall-units", "Wall Units", "glass", "Glass");
        Add(entries, "kitchen", Modular, "loft", "Loft");
        Add(entries, "kitchen", Modular, "tall-unit", "Tall Unit", "pantry", "Pantry");
        Add(entries, "kitchen", Modular, "tall-unit", "Tall Unit", "appliance", "Appliance");
        Add(entries, "kitchen", Modular, "breakfast-counter", "Breakfast Counter",
            uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, "kitchen", Modular, "rolling-shutter-unit", "Rolling Shutter Unit");

        // Bedrooms all share one modular list.
        foreach (var room in Bedrooms)
        {
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "openable", "Openable");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "sliding", "Sliding");
            Add(entries, room, Modular, "loft-storage", "Loft Storage");
            Add(entries, room, Modular, "bed-unit", "Bed Unit", pricing: QuotationPricingType.Catalog,
                uom: QuotationUnitOfMeasure.Number, basePrice: 42000m);
            Add(entries, room, Modular, "side-table", "Side Table", pricing: QuotationPricingType.Catalog,
                uom: QuotationUnitOfMeasure.Number, basePrice: 8500m);
            Add(entries, room, Modular, "dresser", "Dresser Unit");
            Add(entries, room, Modular, "study-table", "Study Table",
                uom: QuotationUnitOfMeasure.RunningFeet);
            Add(entries, room, Modular, "tv-unit", "TV Unit", uom: QuotationUnitOfMeasure.RunningFeet);
        }

        Add(entries, "living-room", Modular, "tv-unit", "TV Unit", uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, "living-room", Modular, "crockery-unit", "Crockery Unit");
        Add(entries, "living-room", Modular, "shoe-rack", "Shoe Rack");
        Add(entries, "living-room", Modular, "display-unit", "Display Unit");

        Add(entries, "dining-room", Modular, "crockery-unit", "Crockery Unit");
        Add(entries, "dining-room", Modular, "dining-storage", "Dining Storage");

        Add(entries, "pooja-room", Modular, "pooja-unit", "Pooja Unit");
        Add(entries, "study-room", Modular, "study-table", "Study Table",
            uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, "study-room", Modular, "bookshelf", "Bookshelf");
        Add(entries, "utility", Modular, "utility-storage", "Utility Storage");
        Add(entries, "foyer", Modular, "shoe-rack", "Shoe Rack");

        // Custom work, furniture, furnishings and services are not room-specific: an empty room
        // key offers them everywhere rather than repeating the list twenty-one times.
        Add(entries, AnyRoom, CustomWork, "floating-shelf", "Floating Shelf",
            uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, AnyRoom, CustomWork, "rafters", "Rafters", uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, AnyRoom, CustomWork, "ms-rods", "MS Rods", uom: QuotationUnitOfMeasure.RunningFeet);
        Add(entries, AnyRoom, CustomWork, "jali-partition", "Jali / Partition");
        Add(entries, AnyRoom, CustomWork, "wall-panelling", "Wall Panelling");

        Add(entries, AnyRoom, Furniture, "sofa", "Sofa", pricing: QuotationPricingType.Catalog,
            uom: QuotationUnitOfMeasure.Number, basePrice: 65000m);
        Add(entries, AnyRoom, Furniture, "coffee-table", "Coffee Table",
            pricing: QuotationPricingType.Catalog, uom: QuotationUnitOfMeasure.Number, basePrice: 18000m);
        Add(entries, AnyRoom, Furniture, "console-table", "Console Table",
            pricing: QuotationPricingType.Catalog, uom: QuotationUnitOfMeasure.Number, basePrice: 22000m);
        Add(entries, AnyRoom, Furniture, "dining-table", "Dining Table",
            pricing: QuotationPricingType.Catalog, uom: QuotationUnitOfMeasure.Number, basePrice: 48000m);

        Add(entries, AnyRoom, Furnishings, "curtains", "Curtains", uom: QuotationUnitOfMeasure.SquareFeet);
        Add(entries, AnyRoom, Furnishings, "blinds", "Blinds", uom: QuotationUnitOfMeasure.SquareFeet);
        Add(entries, AnyRoom, Furnishings, "wallpaper", "Wallpaper", uom: QuotationUnitOfMeasure.SquareFeet);

        Add(entries, AnyRoom, Services, "false-ceiling", "False Ceiling");
        Add(entries, AnyRoom, Services, "flooring", "Flooring");
        Add(entries, AnyRoom, Services, "painting", "Painting");
        Add(entries, AnyRoom, Services, "electrical", "Electrical Work",
            pricing: QuotationPricingType.Custom, uom: QuotationUnitOfMeasure.Number);
        Add(entries, AnyRoom, Services, "plumbing", "Plumbing Work",
            pricing: QuotationPricingType.Custom, uom: QuotationUnitOfMeasure.Number);

        return entries;
    }

    private static void Add(
        List<QuotationCatalogEntry> into,
        string roomKey,
        string categoryKey,
        string itemKey,
        string itemName,
        string variantKey = "",
        string variantName = "",
        QuotationPricingType pricing = QuotationPricingType.Parametric,
        QuotationUnitOfMeasure uom = QuotationUnitOfMeasure.SquareFeet,
        decimal? basePrice = null)
    {
        into.Add(new QuotationCatalogEntry
        {
            Id = DeterministicId("catalog", roomKey, categoryKey, itemKey, variantKey),
            RoomKey = roomKey,
            CategoryKey = categoryKey,
            CategoryName = CategoryNames[categoryKey],
            ItemKey = itemKey,
            ItemName = itemName,
            VariantKey = variantKey,
            VariantName = variantName,
            PricingType = pricing,
            UnitOfMeasure = uom,
            BasePrice = basePrice,
            SortOrder = into.Count(e => e.RoomKey == roomKey && e.CategoryKey == categoryKey),
            IsActive = true,
            CreatedAt = SeededAt
        });
    }

    // --- Rate card ---------------------------------------------------------------

    /// <summary>
    /// Mostly wildcard rows - an empty carcass, shutter or finish matches anything, and the
    /// pricing service prefers the most specific row it can find. That keeps a placeholder card
    /// small while still returning a rate for every combination somebody can pick, instead of
    /// leaving most of the picker silently priced at zero.
    /// </summary>
    private static List<QuotationRate> BuildRates()
    {
        var rates = new List<QuotationRate>();

        // The three grounded figures, taken from the working mock.
        Rate(rates, "base-units", "", 4200m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units", "wooden", 3600m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units", "glass", 3800m, carcass: "BWP", shutter: "Profile", finish: "Glass");

        // Wildcard fallbacks, per square foot unless the item is measured otherwise.
        Rate(rates, "base-units", "", 3800m);
        Rate(rates, "wall-units", "wooden", 3200m);
        Rate(rates, "wall-units", "glass", 3400m);
        Rate(rates, "loft", "", 2400m);
        Rate(rates, "tall-unit", "pantry", 3600m);
        Rate(rates, "tall-unit", "appliance", 3900m);
        Rate(rates, "rolling-shutter-unit", "", 4100m);
        Rate(rates, "breakfast-counter", "", 2800m, uom: QuotationUnitOfMeasure.RunningFeet);

        Rate(rates, "wardrobe", "openable", 1850m);
        Rate(rates, "wardrobe", "sliding", 2150m);
        Rate(rates, "loft-storage", "", 1500m);
        Rate(rates, "dresser", "", 1900m);
        Rate(rates, "study-table", "", 2600m, uom: QuotationUnitOfMeasure.RunningFeet);
        Rate(rates, "tv-unit", "", 2400m, uom: QuotationUnitOfMeasure.RunningFeet);
        Rate(rates, "crockery-unit", "", 1950m);
        Rate(rates, "display-unit", "", 1800m);
        Rate(rates, "shoe-rack", "", 1600m);
        Rate(rates, "bookshelf", "", 1700m);
        Rate(rates, "pooja-unit", "", 2600m);
        Rate(rates, "dining-storage", "", 1900m);
        Rate(rates, "utility-storage", "", 1450m);

        Rate(rates, "floating-shelf", "", 1200m, uom: QuotationUnitOfMeasure.RunningFeet);
        Rate(rates, "rafters", "", 950m, uom: QuotationUnitOfMeasure.RunningFeet);
        Rate(rates, "ms-rods", "", 600m, uom: QuotationUnitOfMeasure.RunningFeet);
        Rate(rates, "jali-partition", "", 1400m);
        Rate(rates, "wall-panelling", "", 1100m);

        Rate(rates, "curtains", "", 450m);
        Rate(rates, "blinds", "", 380m);
        Rate(rates, "wallpaper", "", 120m);

        Rate(rates, "false-ceiling", "", 220m);
        Rate(rates, "flooring", "", 180m);
        Rate(rates, "painting", "", 45m);

        return rates;
    }

    private static void Rate(
        List<QuotationRate> into,
        string itemKey,
        string variantKey,
        decimal ratePerUnit,
        string carcass = "",
        string shutter = "",
        string finish = "",
        QuotationUnitOfMeasure uom = QuotationUnitOfMeasure.SquareFeet)
    {
        into.Add(new QuotationRate
        {
            Id = DeterministicId("rate", itemKey, variantKey, carcass, shutter, finish),
            ItemKey = itemKey,
            VariantKey = variantKey,
            CarcassMaterial = carcass,
            ShutterMaterial = shutter,
            Finish = finish,
            UnitOfMeasure = uom,
            RatePerUnit = ratePerUnit,
            EffectiveFrom = EffectiveFrom,
            IsActive = true,
            CreatedAt = SeededAt
        });
    }

    /// <summary>
    /// A stable id for a seed row, derived from its natural key. MD5 is used as a hash here and
    /// not as a security primitive - all that matters is that the same key yields the same id on
    /// every machine and every run.
    /// </summary>
    private static Guid DeterministicId(string prefix, params string[] parts)
    {
        var key = prefix + "|" + string.Join("|", parts);
        return new Guid(MD5.HashData(Encoding.UTF8.GetBytes(key)));
    }
}
