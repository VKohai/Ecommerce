namespace Ordering.Domain.ValueObjects;
public class Address
{
    public required string Settlement { get; set; }
    public required string Street { get; set; }
    public required string HomeNumber { get; set; }
    public string? Apartement { get; set; }
}
