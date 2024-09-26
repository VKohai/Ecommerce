using Ordering.Domain.Abstractions;
using Ordering.Domain.Exceptions;

namespace Ordering.Domain.Entities;
public class OrderItem : BaseEntity<int>
{
    public string ProductName { get; private set; }
    public string PictureUrl { get; private set; }
    public string? ProductSize { get; private set; }
    public decimal UnitPrice { get; private set; }
    public uint Units { get; private set; }
    public decimal TotalPrice => UnitPrice * Units;
    public int ProductId { get; private set; }

    public OrderItem(string productName, string pictureUrl,
        decimal unitPrice, int productId, uint units = 1, string? productSize = null)
    {
        ProductName = productName;
        PictureUrl = pictureUrl;
        UnitPrice = unitPrice;
        Units = units;
        ProductId = productId;
        ProductSize = productSize;
    }

#pragma warning disable CS8618
    private OrderItem() { } // required for EF
#pragma warning restore CS8618

    public void UpdateProductName(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            throw new OrderingDomainException($"Updating Product Name. {nameof(productName)} is wrong");
        }

        ProductName = productName;
    }

    public void UpdatePictureUrl(string pictureUrl)
    {
        if (string.IsNullOrWhiteSpace(pictureUrl))
        {
            throw new OrderingDomainException($"Updating Picture URL. {nameof(pictureUrl)} is wrong");
        }

        PictureUrl = pictureUrl;
    }

    public void UpdateProductSize(string productSize)
    {
        if (string.IsNullOrWhiteSpace(productSize))
        {
            throw new OrderingDomainException($"Updating Product Size: {nameof(productSize)} is wrong");
        }

        PictureUrl = productSize;
    }

    public void AddUnits(uint units)
    {
        Units += units;
    }

    public void UpdateUnitPrice(uint unitPrice)
    {
        UnitPrice = unitPrice;
    }

    public override string ToString()
    {
        return $"{nameof(ProductName)}: {ProductName}\n" +
            $"{nameof(PictureUrl)}: {PictureUrl}\n" +
            $"{nameof(ProductSize)}: {ProductSize}\n" +
            $"{nameof(UnitPrice)}: {UnitPrice}\n" +
            $"{nameof(Units)}: {Units}\n" +
            $"{nameof(TotalPrice)}: {TotalPrice}";
    }
}
