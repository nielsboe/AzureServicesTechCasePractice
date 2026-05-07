namespace Application.Interfaces;

public interface IRepository<T>
{
    Task<int> Create(T item, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<ICollection<T>> All(CancellationToken cancellationToken);
    Task Update(T item, CancellationToken cancellationToken);
}