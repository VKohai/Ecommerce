using Ordering.Domain.Abstractions;

namespace Ordering.Application.Services;
public interface IHttpService<T, TKey> where T : BaseEntity<TKey>
{
    Task Create(string url, T entity);
    Task<T?> Get(string url, TKey id);
    Task<IEnumerable<T?>> GetAll(string url);
    Task Delete(string url, T entity);
    Task<bool> Update(string url, T entity);
}
