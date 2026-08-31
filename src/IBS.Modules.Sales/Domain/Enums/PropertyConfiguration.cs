namespace IBS.Modules.Sales.Domain.Enums;

/// <summary>
/// Layout of the property, in the Indian residential shorthand. Orthogonal to
/// <see cref="PropertyType"/>: a Villa and an Apartment can both be 3BHK.
/// </summary>
public enum PropertyConfiguration
{
    Studio = 1,
    OneBhk = 2,
    TwoBhk = 3,
    ThreeBhk = 4,
    FourBhk = 5,
    FiveBhkPlus = 6,
    Duplex = 7,
    Penthouse = 8,
    NotApplicable = 9
}
