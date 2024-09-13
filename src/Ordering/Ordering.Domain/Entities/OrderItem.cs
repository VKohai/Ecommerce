using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Entities;
public class OrderItem : BaseEntity<int>
{
    public int ProductId { get; private set; }
    public uint Amount { get; private set; }
    public decimal TotalPrice { get; private set; }

    public OrderItem(int productId, uint amount, decimal totalPrice)
    {
        ProductId = productId;
        Amount = amount;
        TotalPrice = totalPrice;
    }
}
