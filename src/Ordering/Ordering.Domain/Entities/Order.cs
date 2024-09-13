using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;
public class Order : BaseEntity<int>
{
    public ClientContacts ClientContacts { get; private set; }
    public Address Address { get; private set; }

    public Order(ClientContacts clientContacts, Address address)
    {
        ClientContacts = clientContacts;
        Address = address;
    }

    public Order(int id)
    {
        Id = id;
    }

    private Order() // required for EF
    { }

    public void UpdateClientContacts(ClientContacts? clientContacts)
    {
        if (clientContacts == null)
            return;

        ClientContacts = clientContacts;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
