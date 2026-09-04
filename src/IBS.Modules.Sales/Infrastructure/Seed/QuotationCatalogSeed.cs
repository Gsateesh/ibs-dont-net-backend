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
/// The rooms and items here follow the studio's room-by-room build list (kitchen, utility, the
/// living/dining/drawing rooms, the bedrooms, and the main door). Each room lists what it
/// offers under the four categories the quotation colour-codes by: Modular, Carpentry,
/// Furniture and Others.
/// </para>
/// <para>
/// The rates are <b>placeholders</b>, not the studio's real pricing. Only the three figures
/// taken from the working mock (base units at 4,200, wall units in wood at 3,600 and in glass
/// at 3,800 per sq.ft) are grounded in anything; every other rate is a plausible round number
/// so no line prices at zero while the real card is being assembled.
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
    private const string Carpentry = "carpentry";
    private const string Furniture = "furniture";

    /// <summary>
    /// Everything that is neither modular, carpentry nor loose furniture - accessories, stone,
    /// tiles, false ceiling, painting, lighting, the trades. The studio prices and colour-codes
    /// them as one bucket.
    /// </summary>
    private const string Others = "others";

    /// <summary>Room key meaning "offered in every room".</summary>
    private const string AnyRoom = "";

    private static readonly Dictionary<string, string> CategoryNames = new(StringComparer.Ordinal)
    {
        [Modular] = "Modular",
        [Carpentry] = "Carpentry",
        [Furniture] = "Furniture",
        [Others] = "Others"
    };

    /// <summary>
    /// The bedroom-shaped rooms, which all offer the same list. The keys match the Requirements
    /// catalogue in the frontend so a room copied from the brief lands on the right picker.
    /// </summary>
    private static readonly string[] Bedrooms =
        ["master-bedroom", "bedroom", "kids-bedroom", "guest-bedroom"];

    /// <summary>Short aliases for the units used often below; square feet is the parameter default.</summary>
    private const QuotationUnitOfMeasure RFt = QuotationUnitOfMeasure.RunningFeet;

    private const QuotationUnitOfMeasure Each = QuotationUnitOfMeasure.Number;

    public static IReadOnlyList<QuotationCatalogEntry> Entries { get; } = BuildEntries();

    public static IReadOnlyList<QuotationRate> Rates { get; } = BuildRates();

    // --- Catalogue ---------------------------------------------------------------

    private static List<QuotationCatalogEntry> BuildEntries()
    {
        var entries = new List<QuotationCatalogEntry>();

        // --- Kitchen ---------------------------------------------------------
        Add(entries, "kitchen", Modular, "base-units", "Base Units");
        Add(entries, "kitchen", Modular, "wall-units", "Wall Units", "wooden", "Wooden");
        Add(entries, "kitchen", Modular, "wall-units", "Wall Units", "glass", "Glass");
        Add(entries, "kitchen", Modular, "loft", "Loft");
        Add(entries, "kitchen", Modular, "tall-unit", "Tall Unit", "pantry", "Pantry");
        Add(entries, "kitchen", Modular, "tall-unit", "Tall Unit", "appliance", "Appliance");
        Add(entries, "kitchen", Modular, "breakfast-counter", "Breakfast Counter", uom: RFt);
        Add(entries, "kitchen", Modular, "breakfast-shelf", "Breakfast Shelf / Arch");

        Add(entries, "kitchen", Carpentry, "arch", "Arch", uom: RFt);
        Add(entries, "kitchen", Carpentry, "fluted-panel", "Fluted Panel");
        Add(entries, "kitchen", Carpentry, "groove-shutters", "Groove Shutters");
        Add(entries, "kitchen", Carpentry, "breakfast-counter-arch", "Breakfast Counter - Arch", uom: RFt);
        Add(entries, "kitchen", Carpentry, "open-shelves", "Shelves", uom: RFt);
        Add(entries, "kitchen", Carpentry, "ms-rods", "MS Rods", uom: RFt);

        Add(entries, "kitchen", Others, "accessories", "Accessories", QuotationPricingType.Catalog, Each, 6500m);
        Add(entries, "kitchen", Others, "countertop", "Countertop", uom: RFt);
        Add(entries, "kitchen", Others, "dado-tiles", "Dado Tiles");
        Add(entries, "kitchen", Others, "false-ceiling", "False Ceiling + Paint");
        Add(entries, "kitchen", Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
        Add(entries, "kitchen", Others, "cob-lights", "COB Lights", uom: RFt);
        Add(entries, "kitchen", Others, "profile-lights", "Profile Lights", uom: RFt);
        Add(entries, "kitchen", Others, "cove-lights", "Cove Lights", uom: RFt);
        Add(entries, "kitchen", Others, "sink", "Sink", QuotationPricingType.Catalog, Each, 8500m);
        Add(entries, "kitchen", Others, "tap", "Tap", QuotationPricingType.Catalog, Each, 3500m);

        // --- Utility --------------------------------------------------------
        Add(entries, "utility", Modular, "base-units", "Base Units");
        Add(entries, "utility", Modular, "wall-units", "Wall Units");
        Add(entries, "utility", Modular, "shelf", "Shelf");
        Add(entries, "utility", Modular, "loft", "Loft");
        Add(entries, "utility", Modular, "tall-unit", "Tall Unit", "pantry", "Pantry");
        Add(entries, "utility", Modular, "janitor-unit", "Janitor Unit");

        Add(entries, "utility", Others, "accessories", "Accessories", QuotationPricingType.Catalog, Each, 6500m);
        Add(entries, "utility", Others, "countertop", "Countertop", uom: RFt);
        Add(entries, "utility", Others, "dado-tiles", "Dado Tiles");
        Add(entries, "utility", Others, "false-ceiling", "False Ceiling + Paint");
        Add(entries, "utility", Others, "wooden-ceiling", "Wooden Ceiling");
        Add(entries, "utility", Others, "cylinder-lights", "Cylinder Lights", QuotationPricingType.Catalog, Each, 1200m);
        Add(entries, "utility", Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
        Add(entries, "utility", Others, "cob-lights", "COB Lights", uom: RFt);
        Add(entries, "utility", Others, "iron-grills", "Iron Grills");

        // --- Living / Dining / Drawing rooms -------------------------------
        // The three share a spine of carpentry and lighting; dining and drawing add a crockery
        // and bar unit, dining adds a dining table.
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
            Add(entries, room, Carpentry, "beading", "Beadings", uom: RFt);
            Add(entries, room, Carpentry, "rafters-pu", "Rafters with PU", uom: RFt);
            Add(entries, room, Carpentry, "partition", "Partition");
            Add(entries, room, Carpentry, "storage-unit", "Storage Unit");
            Add(entries, room, Carpentry, "console-unit", "Console Unit");
            Add(entries, room, Carpentry, "pooja-unit", "Pooja Unit");

            if (room == "dining-room")
            {
                Add(entries, room, Furniture, "dining-table", "Dining Table", QuotationPricingType.Catalog, Each, 48000m);
            }

            Add(entries, room, Furniture, "sofa", "Sofa", QuotationPricingType.Catalog, Each, 65000m);
            Add(entries, room, Furniture, "coffee-table", "Coffee Table", QuotationPricingType.Catalog, Each, 18000m);
            Add(entries, room, Furniture, "settee", "Settee", QuotationPricingType.Catalog, Each, 28000m);
            Add(entries, room, Furniture, "curtains", "Curtains / Blinds");

            Add(entries, room, Others, "false-ceiling", "False Ceiling + Paint");
            Add(entries, room, Others, "wooden-ceiling", "Wooden Ceiling");
            Add(entries, room, Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
            Add(entries, room, Others, "cob-lights", "COB Lights", uom: RFt);
            Add(entries, room, Others, "profile-lights", "Profile Lights", uom: RFt);
            Add(entries, room, Others, "cove-lights", "Cove Lights", uom: RFt);
            Add(entries, room, Others, "track-lights", "Track Lights", QuotationPricingType.Catalog, Each, 1400m);
            Add(entries, room, Others, "magnetic-track-lights", "Magnetic Track Lights", uom: RFt);
        }

        // --- Bedrooms ------------------------------------------------------
        foreach (var room in Bedrooms)
        {
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "hinged-7", "Hinged - 7'");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "hinged-full", "Hinged - Full Length");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "sliding-7", "Sliding - 7'");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "sliding-full", "Sliding - Full Height");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "sliding-glass", "Sliding Glass");
            Add(entries, room, Modular, "wardrobe", "Wardrobe", "used-clothes", "Used Clothes");
            Add(entries, room, Modular, "loft", "Loft");
            Add(entries, room, Modular, "study-table", "Study Table", uom: RFt);
            Add(entries, room, Modular, "study-table-wall-storage", "Study Table - Wall Storage");
            Add(entries, room, Modular, "bookshelf", "Book Shelf Unit");
            Add(entries, room, Modular, "seating-unit", "Seating Unit");

            Add(entries, room, Carpentry, "bay-window-paneling", "Bay Window Paneling");
            Add(entries, room, Carpentry, "tv-unit", "TV Unit", uom: RFt);
            Add(entries, room, Carpentry, "accent-wall-wallpaper", "Accent Wall - Wallpaper");
            Add(entries, room, Carpentry, "accent-wall-paneling", "Accent Wall - Paneling");
            Add(entries, room, Carpentry, "beading", "Beadings", uom: RFt);
            Add(entries, room, Carpentry, "rafters-pu", "Rafters with PU", uom: RFt);
            Add(entries, room, Carpentry, "partition", "Partition");

            Add(entries, room, Others, "false-ceiling", "False Ceiling + Paint");
            Add(entries, room, Others, "panel-lights", "Down / Panel Lights", QuotationPricingType.Catalog, Each, 850m);
            Add(entries, room, Others, "cove-lights", "Cove Lights", uom: RFt);
            Add(entries, room, Others, "mosquito-mesh", "Mosquito Mesh");
        }

        // --- Main door & paneling ----------------------------------------
        Add(entries, "main-door", Carpentry, "shoe-rack", "Shoe Rack");
        Add(entries, "main-door", Carpentry, "main-door-paneling", "Main Door Paneling");
        Add(entries, "main-door", Carpentry, "security-door", "Security Door", QuotationPricingType.Catalog, Each, 45000m);
        Add(entries, "main-door", Others, "mosquito-mesh", "Mosquito Mesh");

        // --- Offered everywhere -----------------------------------------
        // One-off carpentry and the trades are not room-specific: an empty room key offers them
        // in every room rather than repeating the list under each heading.
        Add(entries, AnyRoom, Carpentry, "floating-shelf", "Floating Shelf", uom: RFt);
        Add(entries, AnyRoom, Carpentry, "wall-panelling", "Wall Panelling");
        Add(entries, AnyRoom, Carpentry, "jali-partition", "Jali / Partition");

        Add(entries, AnyRoom, Others, "flooring", "Flooring");
        Add(entries, AnyRoom, Others, "painting", "Painting");
        Add(entries, AnyRoom, Others, "electrical", "Electrical Work", QuotationPricingType.Custom, Each);
        Add(entries, AnyRoom, Others, "plumbing", "Plumbing Work", QuotationPricingType.Custom, Each);

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
        => Add(into, roomKey, categoryKey, itemKey, itemName, "", "", pricing, uom, basePrice);

    private static void Add(
        List<QuotationCatalogEntry> into,
        string roomKey,
        string categoryKey,
        string itemKey,
        string itemName,
        string variantKey,
        string variantName,
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

    // --- Rate card -------------------------------------------------------------

    /// <summary>
    /// One wildcard row per parametric item - an empty carcass, shutter and finish match
    /// anything, so every combination somebody can pick returns a rate instead of a silent
    /// zero. The three grounded figures from the working mock get a specific row that the
    /// pricing service prefers when its materials line up.
    /// Catalogue items (furniture, lights, fittings) carry their price on the entry itself and
    /// need no row here.
    /// </summary>
    private static List<QuotationRate> BuildRates()
    {
        var rates = new List<QuotationRate>();

        // The three grounded figures, taken from the working mock.
        Rate(rates, "base-units", "", 4200m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units", "wooden", 3600m, carcass: "BWP", shutter: "HDHMR", finish: "Acrylic");
        Rate(rates, "wall-units", "glass", 3800m, carcass: "BWP", shutter: "Profile", finish: "Glass");

        // Modular - shutter and panel work, per sq.ft unless noted.
        Rate(rates, "base-units", "", 3800m);
        Rate(rates, "wall-units", "wooden", 3200m);
        Rate(rates, "wall-units", "glass", 3400m);
        Rate(rates, "wall-units", "", 3200m);
        Rate(rates, "loft", "", 2400m);
        Rate(rates, "tall-unit", "pantry", 3600m);
        Rate(rates, "tall-unit", "appliance", 3900m);
        Rate(rates, "breakfast-counter", "", 2800m, uom: RFt);
        Rate(rates, "breakfast-shelf", "", 2600m);
        Rate(rates, "shelf", "", 1800m);
        Rate(rates, "janitor-unit", "", 2200m);

        Rate(rates, "wardrobe", "hinged-7", 1850m);
        Rate(rates, "wardrobe", "hinged-full", 2000m);
        Rate(rates, "wardrobe", "sliding-7", 2150m);
        Rate(rates, "wardrobe", "sliding-full", 2300m);
        Rate(rates, "wardrobe", "sliding-glass", 2600m);
        Rate(rates, "wardrobe", "used-clothes", 1700m);
        Rate(rates, "study-table", "", 2600m, uom: RFt);
        Rate(rates, "study-table-wall-storage", "", 2200m);
        Rate(rates, "bookshelf", "", 1900m);
        Rate(rates, "seating-unit", "", 2100m);

        // Carpentry.
        Rate(rates, "arch", "", 1100m, uom: RFt);
        Rate(rates, "fluted-panel", "", 1200m);
        Rate(rates, "groove-shutters", "", 1400m);
        Rate(rates, "breakfast-counter-arch", "", 1200m, uom: RFt);
        Rate(rates, "open-shelves", "", 900m, uom: RFt);
        Rate(rates, "ms-rods", "", 600m, uom: RFt);
        Rate(rates, "tv-unit", "", 2400m, uom: RFt);
        Rate(rates, "crockery-unit", "", 1950m);
        Rate(rates, "bar-unit", "", 2000m);
        Rate(rates, "accent-wall-wallpaper", "", 900m);
        Rate(rates, "accent-wall-paneling", "", 1300m);
        Rate(rates, "bay-window-paneling", "", 1350m);
        Rate(rates, "beading", "", 350m, uom: RFt);
        Rate(rates, "rafters-pu", "", 1250m, uom: RFt);
        Rate(rates, "partition", "", 1400m);
        Rate(rates, "storage-unit", "", 1600m);
        Rate(rates, "console-unit", "", 1500m);
        Rate(rates, "pooja-unit", "", 2600m);
        Rate(rates, "shoe-rack", "", 1600m);
        Rate(rates, "main-door-paneling", "", 1800m);
        Rate(rates, "floating-shelf", "", 1200m, uom: RFt);
        Rate(rates, "wall-panelling", "", 1100m);
        Rate(rates, "jali-partition", "", 1400m);

        // Furniture - loose curtains only; the rest are catalogue-priced.
        Rate(rates, "curtains", "", 450m);

        // Others.
        Rate(rates, "countertop", "", 1600m, uom: RFt);
        Rate(rates, "dado-tiles", "", 220m);
        Rate(rates, "false-ceiling", "", 260m);
        Rate(rates, "wooden-ceiling", "", 850m);
        Rate(rates, "iron-grills", "", 900m);
        Rate(rates, "mosquito-mesh", "", 350m);
        Rate(rates, "cob-lights", "", 450m, uom: RFt);
        Rate(rates, "profile-lights", "", 550m, uom: RFt);
        Rate(rates, "cove-lights", "", 500m, uom: RFt);
        Rate(rates, "magnetic-track-lights", "", 900m, uom: RFt);
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
