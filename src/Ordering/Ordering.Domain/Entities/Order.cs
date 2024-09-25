using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;
using System.Text;

namespace Ordering.Domain.Entities;
public class Order : BaseEntity<int>, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems;
    private DateTime _orderCreatedDate;

    public decimal TotalPrice { get; private set; }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    public ClientContacts ClientContacts { get; private set; }
    public Address Address { get; private set; }

    public Order(ClientContacts clientContacts, Address address)
    {
        _orderItems = new List<OrderItem>();
        _orderCreatedDate = DateTime.UtcNow;
        ClientContacts = clientContacts;
        Address = address;
    }

    private Order() // required for EF
    { }

    public void AddOrderItem(OrderItem item)
    {
        var existingItemIndex = _orderItems
            .FindIndex(e => e.ProductId == item.ProductId && e.ProductSize == item.ProductSize);

        if (existingItemIndex == -1)
        {
            _orderItems.Add(item);
            TotalPrice += item.TotalPrice;
        }
    }

    public bool RemoveOrderItem(OrderItem item)
    {
        if (_orderItems.Remove(item))
        {
            TotalPrice -= item.TotalPrice;
            return true;
        }
        return false;
    }

    public void UpdateClientContacts(ClientContacts clientContacts)
    {
        if (clientContacts == ClientContacts)
            return;

        ClientContacts = clientContacts;
    }

    public void UpdateAddress(Address address)
    {
        if (address == Address)
            return;

        Address = address;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        foreach (var item in _orderItems)
        {
            builder.Append(item.ToString() + "\n");
            builder.AppendLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        }

        return builder.ToString();
    }
}
