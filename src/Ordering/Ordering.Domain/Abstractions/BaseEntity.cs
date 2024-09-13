namespace Ordering.Domain.Abstractions;
public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}
