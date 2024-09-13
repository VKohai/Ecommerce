using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Entities;
public class Product : BaseEntity<int>
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; } = 0;
    public uint Units { get; private set; } = 0;
    public string Size { get; private set; }
    public ProductStatus ProductStatus { get; private set; }
}

public enum ProductStatus
{
    Draft,
    OnSale,
    OutOfStock
}