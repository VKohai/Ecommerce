namespace Ordering.Domain.ValueObjects;
public class Address
{
    public required string Settlement { get; init; }
    public required string Street { get; init; }
    public required string HomeNumber { get; init; }
    public string? Apartement { get; set; }

    public Address(string settlement, string street, string homeNumber, string? apartement)
    {
        Settlement = settlement;
        Street = street;
        HomeNumber = homeNumber;
        Apartement = apartement;
    }
}
