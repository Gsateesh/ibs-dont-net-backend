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
/// This is a straight transcription of the studio's room-by-room build list: the kitchen, the
/// utility, the living / dining / drawing rooms, the bedroom and the main door, each listing
/// exactly what it offers under Modular, Carpentry, Furniture and Others - nothing added, and
/// spelling normalised only where the source obviously slipped ("Flase" -> "False",
/// "Parition" -> "Partition", "Seattee" -> "Settee", "Janitory" -> "Janitor"). Rooms the list
/// does not cover yet (bathroom, study, foyer, the outdoor areas) carry no entries; they take
/// custom lines until the list is extended.
/// </para>
/// <para>
/// The rates are <b>placeholders</b>, not the studio's real pricing. Only the three figures
/// taken from the working mock (base units at 4,200, wall units in wood at 3,600 and in glass
/// at 3,800 per sq.ft) are grounded in anything; every other rate is a plausible round number
/// so no line prices at zero while the real card is being assembled. Catalogue items -
/// furniture, lights, fittings - carry their price on the entry itself.
/// </para>
/// <para>
/// The unit of measure on each entry (square feet, running feet, or a counted number) is the
/// studio's call to confirm; it is set here to whatever reads as sensible for the item.
/// </para>
/// <para>
/// Ids are derived from each row's natural key rather than a running counter, so inserting an
/// item in the middle of a list later does not renumber every row after it.
/// </para>
/// </remarks>
public static class QuotationCatalogSeed
{
    /// <summary>Fixed so migrations are byte-identical between runs.</summary>
    private static readonly DateTimeOffset SeededAt = new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

    private static readonly DateOnly EffectiveFrom = new(2026, 1, 1);

    // --- Category keys -----------------------------------------------------------

    private const string Modular = "modular";
    private const string Carpentry = "carpentry";
    private const string Furniture = "furniture";
    private const string Others = "others";

    private const QuotationUnitOfMeasure RFt = QuotationUnitOfMeasure.RunningFeet;
    private const QuotationUnitOfMeasure Each = QuotationUnitOfMeasure.Number;

    private static readonly Dictionary<string, string> CategoryNames = new(StringComparer.Ordinal)
    {
        [Modular] = "Modular",
        [Carpentry] = "Carpentry",
        [Furniture] = "Furniture",
        [Others] = "Others"
    };

    /// <summary>
    /// The build list has one "Bedroom" column; it is offered against every bedroom-shaped room
    /// so a quotation started for any of them lands on the right picker. Keys match the
    /// Requirements catalogue in the frontend.
    /// </summary>
    private static readonly string[] Bedrooms =
        ["master-bedroom", "bedroom", "kids-bedroom", "guest-bedroom"];

    public static IReadOnlyList<QuotationCatalogEntry> Entries { get; } = BuildEntries();

    public static IReadOnlyList<QuotationRate> Rates { get; } = BuildRates();

    // --- Catalogue -------------------------------------------------------------

    private static List<QuotationCatalogEntry> BuildEntries()
    {
        var entries = new List<QuotationCatalogEntry>();

        // --- Kitchen -----------------------------------------------------
        Add(entries, "kitchen", Modular, "base-units", "Base Units");
        Add(entries, "kitchen", Modular, "wall-units-wood", "Wall Units - Wood");
        Add(entries, "kitchen", Modular, "wall-units-glass", "Wall Units - Glass");
        Add(entries, "kitchen", Modular, "loft", "Loft");
        Add(entries, "kitchen", Modular, "pantry-unit", "Pantry Unit");
        Add(entries, "kitchen", Modular, "appliance-unit", "Appliance Unit");
        Add(entries, "kitchen", Modular, "breakfast-counter", "Breakfast Counter", uom: RFt);
        Add(entries, "kitchen", Modular, "breakfast-shelf-arch", "Breakfast Shelf / Arch");

        Add(entries, "kitchen", Carpentry, "arch", "Arch", uom: RFt);
        Add(entries, "kitchen", Carpentry, "fluted-panel", "Fluted Panel");
        Add(entries, "kitchen", Carpentry, "groove-shutters", "Groove Shutters");
        Add(entries, "kitchen", Carpentry, "breakfast-counter-arch", "Breakfast Counter - Arch", uom: RFt);
        Add(entries, "kitchen", Carpentry, "shelves", "Shelves", uom: RFt);
        Add(entries, "kitchen", Carpentry, "ms-rods", "MS Rods", uom: RFt);

        Add(entries, "kitchen", Others, "accessories", "Accessories", QuotationPricingType.Catalog, Each, 6500m);
        Add(entries, "kitchen", Others, "countertop", "Countertop", uom: RFt);
        Add(entries, "kitchen", Others, "dado-tiles", "Dado Tiles");
        Add(entries, "kitchen", Others, "false-ceiling-paint", "False Ceiling + Paint");
        Add(entries, "kitchen", Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
        Add(entries, "kitchen", Others, "cob-lights", "COB Lights", uom: RFt);
        Add(entries, "kitchen", Others, "profile-lights", "Profile Lights", uom: RFt);
        Add(entries, "kitchen", Others, "cove-lights", "Cove Lights", uom: RFt);
        Add(entries, "kitchen", Others, "sink", "Sink", QuotationPricingType.Catalog, Each, 8500m);
        Add(entries, "kitchen", Others, "tap", "Tap", QuotationPricingType.Catalog, Each, 3500m);

        // --- Utility ---------------------------------------------------
        Add(entries, "utility", Modular, "base-units", "Base Units");
        Add(entries, "utility", Modular, "wall-units", "Wall Units");
        Add(entries, "utility", Modular, "shelf", "Shelf");
        Add(entries, "utility", Modular, "loft", "Loft");
        Add(entries, "utility", Modular, "pantry-unit", "Pantry Unit");
        Add(entries, "utility", Modular, "janitor-unit", "Janitor Unit");

        Add(entries, "utility", Others, "accessories", "Accessories", QuotationPricingType.Catalog, Each, 6500m);
        Add(entries, "utility", Others, "countertop", "Countertop", uom: RFt);
        Add(entries, "utility", Others, "dado-tiles", "Dado Tiles");
        Add(entries, "utility", Others, "false-ceiling-paint", "False Ceiling + Paint");
        Add(entries, "utility", Others, "wooden-ceiling", "Wooden Ceiling");
        Add(entries, "utility", Others, "cylinder-lights", "Cylinder Lights", QuotationPricingType.Catalog, Each, 1200m);
        Add(entries, "utility", Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
        Add(entries, "utility", Others, "cob-lights", "COB Lights", uom: RFt);
        Add(entries, "utility", Others, "iron-grills", "Iron Grills");

        // --- Living / Dining / Drawing rooms -------------------------
        // Dining and drawing add a crockery and bar unit; dining alone adds a dining table.
        foreach (var room in new[] { "living-room", "dining-room", "drawing-room" })
        {
            if (room != "living-room")
            {
                Add(entries, room, Carpentry, "crockery-unit", "Crockery Unit");
                Add(entries, room, Carpentry, "bar-unit", "Bar Unit");
            }

            Add(entries, room, Carpentry, "tv-unit", "TV Unit", uom: RFt);
            Add(entries, room, Carpentry, "accent-wall-wallpaper", "Accent Wall - Wallpaper");
            Add(entries, room, Carpentry, "accent-wall-paneling", "Accent Wall - Paneling");
            Add(entries, room, Carpentry, "beadings", "Beadings", uom: RFt);
            Add(entries, room, Carpentry, "rafters-with-pu", "Rafters with PU", uom: RFt);
            Add(entries, room, Carpentry, "partition", "Partition");
            Add(entries, room, Carpentry, "storage-unit", "Storage Unit");
            Add(entries, room, Carpentry, "console-unit", "Console Unit");
            Add(entries, room, Carpentry, "puja-unit", "Puja Unit");

            if (room == "dining-room")
            {
                Add(entries, room, Furniture, "dining-table", "Dining Table", QuotationPricingType.Catalog, Each, 48000m);
            }

            Add(entries, room, Furniture, "sofa", "Sofa", QuotationPricingType.Catalog, Each, 65000m);
            Add(entries, room, Furniture, "coffee-table", "Coffee Table", QuotationPricingType.Catalog, Each, 18000m);
            Add(entries, room, Furniture, "settee", "Settee", QuotationPricingType.Catalog, Each, 28000m);
            Add(entries, room, Furniture, "curtains-blind", "Curtains / Blind");

            Add(entries, room, Others, "false-ceiling-paint", "False Ceiling + Paint");
            Add(entries, room, Others, "wooden-ceiling", "Wooden Ceiling");
            Add(entries, room, Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
            Add(entries, room, Others, "cob-lights", "COB Lights", uom: RFt);
            Add(entries, room, Others, "profile-lights", "Profile Lights", uom: RFt);
            Add(entries, room, Others, "cove-lights", "Cove Lights", uom: RFt);
            Add(entries, room, Others, "track-lights", "Track Lights", QuotationPricingType.Catalog, Each, 1400m);
            Add(entries, room, Others, "magnetic-track-lights", "Magnetic Track Lights", uom: RFt);
        }

        // --- Bedroom (every bedroom-shaped room) -------------------
        foreach (var room in Bedrooms)
        {
            Add(entries, room, Modular, "hinged-wardrobe-7", "Hinged Wardrobe - 7'");
            Add(entries, room, Modular, "hinged-wardrobe-full-length", "Hinged Wardrobe - Full Length");
            Add(entries, room, Modular, "sliding-wardrobe-7", "Sliding Wardrobe - 7'");
            Add(entries, room, Modular, "sliding-wardrobe-full-height", "Sliding Wardrobe - Full Height");
            Add(entries, room, Modular, "sliding-glass-wardrobe", "Sliding Glass Wardrobe");
            Add(entries, room, Modular, "loft", "Loft");
            Add(entries, room, Modular, "used-clothes-wardrobe", "Used Clothes Wardrobe");
            Add(entries, room, Modular, "study-table", "Study Table", uom: RFt);
            Add(entries, room, Modular, "study-table-wall-storage", "Study Table - Wall Storage");
            Add(entries, room, Modular, "book-shelf-unit", "Book Shelf Unit");
            Add(entries, room, Modular, "seating-unit", "Seating Unit");

            Add(entries, room, Carpentry, "bay-window-paneling", "Bay Window Paneling");
            Add(entries, room, Carpentry, "tv-unit", "TV Unit", uom: RFt);
            Add(entries, room, Carpentry, "accent-wall-wallpaper", "Accent Wall - Wallpaper");
            Add(entries, room, Carpentry, "accent-wall-paneling", "Accent Wall - Paneling");
            Add(entries, room, Carpentry, "beadings", "Beadings", uom: RFt);
            Add(entries, room, Carpentry, "rafters-with-pu", "Rafters with PU", uom: RFt);
            Add(entries, room, Carpentry, "partition", "Partition");

            Add(entries, room, Others, "mosquito-mesh", "Mosquito Mesh");
        }

        // --- Main door & paneling -------------------------------
        Add(entries, "main-door", Carpentry, "shoe-rack", "Shoe Rack");
        Add(entries, "main-door", Carpentry, "main-door-paneling", "Main Door Paneling");
        Add(entries, "main-door", Carpentry, "security-door", "Security Door", QuotationPricingType.Catalog, Each, 45000m);
        Add(entries, "main-door", Others, "mosquito-mesh", "Mosquito Mesh");

        return entries;
    }

    private static void Add(
        List<QuotationCatalogEntry> into,
        string roomKey,
        string categoryKey,
        string itemKey,
        string itemName,
        QuotationPricingType pricing = QuotationPricingType.Parametric,
        QuotationUnitOfMeasure uom = QuotationUnitOfMeasure.SquareFeet,
        decimal? basePrice = null)
    {
        into.Add(new QuotationCatalogEntry
        {
            Id = DeterministicId("catalog", roomKey, categoryKey, itemKey),
            RoomKey = roomKey,
            CategoryKey = categoryKey,
            CategoryName = CategoryNames[categoryKey],
            ItemKey = itemKey,
            ItemName = itemName,
            VariantKey = string.Empty,
            VariantName = string.Empty,
            PricingType = pricing,
            UnitOfMeasure = uom,
            BasePrice = basePrice,
            SortOrder = into.Count(e => e.RoomKey == roomKey && e.CategoryKey == categoryKey),
            IsActive = true,
            CreatedAt = SeededAt
        });
    }

    // --- Rate card -----------------------------------------------------------

    /// <summary>
    /// One wildcard row per parametric item - an empty carcass, shutter and finish match
    /// anything - so every combination somebody can pick returns a rate rather than a silent
    /// zero. The three grounded figures from the working mock get a specific row the pricing
    /// service prefers when its materials line up.
    /// </summary>
    private static List<QuotationRate> BuildRates()
    {
        var rates = new List<QuotationRate>();

        // Grounded figures from the working mock.
        Rate(rates, "base-units", 4200m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units-wood", 3600m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units-glass", 3800m, carcass: "BWP", shutter: "Profile", finish: "Glass");

        // Modular.
        Rate(rates, "base-units", 3800m);
        Rate(rates, "wall-units-wood", 3200m);
        Rate(rates, "wall-units-glass", 3400m);
        Rate(rates, "wall-units", 3200m);
        Rate(rates, "loft", 2400m);
        Rate(rates, "pantry-unit", 3600m);
        Rate(rates, "appliance-unit", 3900m);
        Rate(rates, "breakfast-counter", 2800m, uom: RFt);
        Rate(rates, "breakfast-shelf-arch", 2600m);
        Rate(rates, "shelf", 1800m);
        Rate(rates, "janitor-unit", 2200m);
        Rate(rates, "hinged-wardrobe-7", 1850m);
        Rate(rates, "hinged-wardrobe-full-length", 2000m);
        Rate(rates, "sliding-wardrobe-7", 2150m);
        Rate(rates, "sliding-wardrobe-full-height", 2300m);
        Rate(rates, "sliding-glass-wardrobe", 2600m);
        Rate(rates, "used-clothes-wardrobe", 1700m);
        Rate(rates, "study-table", 2600m, uom: RFt);
        Rate(rates, "study-table-wall-storage", 2200m);
        Rate(rates, "book-shelf-unit", 1900m);
        Rate(rates, "seating-unit", 2100m);

        // Carpentry.
        Rate(rates, "arch", 1100m, uom: RFt);
        Rate(rates, "fluted-panel", 1200m);
        Rate(rates, "groove-shutters", 1400m);
        Rate(rates, "breakfast-counter-arch", 1200m, uom: RFt);
        Rate(rates, "shelves", 900m, uom: RFt);
        Rate(rates, "ms-rods", 600m, uom: RFt);
        Rate(rates, "tv-unit", 2400m, uom: RFt);
        Rate(rates, "accent-wall-wallpaper", 900m);
        Rate(rates, "accent-wall-paneling", 1300m);
        Rate(rates, "beadings", 350m, uom: RFt);
        Rate(rates, "rafters-with-pu", 1250m, uom: RFt);
        Rate(rates, "partition", 1400m);
        Rate(rates, "storage-unit", 1600m);
        Rate(rates, "console-unit", 1500m);
        Rate(rates, "puja-unit", 2600m);
        Rate(rates, "crockery-unit", 1950m);
        Rate(rates, "bar-unit", 2000m);
        Rate(rates, "bay-window-paneling", 1350m);
        Rate(rates, "shoe-rack", 1600m);
        Rate(rates, "main-door-paneling", 1800m);

        // Furniture - loose curtains only; the rest are catalogue-priced.
        Rate(rates, "curtains-blind", 450m);

        // Others.
        Rate(rates, "countertop", 1600m, uom: RFt);
        Rate(rates, "dado-tiles", 220m);
        Rate(rates, "false-ceiling-paint", 260m);
        Rate(rates, "wooden-ceiling", 850m);
        Rate(rates, "iron-grills", 900m);
        Rate(rates, "mosquito-mesh", 350m);
        Rate(rates, "cob-lights", 450m, uom: RFt);
        Rate(rates, "profile-lights", 550m, uom: RFt);
        Rate(rates, "cove-lights", 500m, uom: RFt);
        Rate(rates, "magnetic-track-lights", 900m, uom: RFt);

        return rates;
    }

    private static void Rate(
        List<QuotationRate> into,
        string itemKey,
        decimal ratePerUnit,
        string carcass = "",
        string shutter = "",
        string finish = "",
        QuotationUnitOfMeasure uom = QuotationUnitOfMeasure.SquareFeet)
    {
        into.Add(new QuotationRate
        {
            Id = DeterministicId("rate", itemKey, carcass, shutter, finish),
            ItemKey = itemKey,
            VariantKey = string.Empty,
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
