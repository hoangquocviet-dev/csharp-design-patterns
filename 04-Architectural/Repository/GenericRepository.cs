using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Architectural.Repository;

public interface IRepository<T> where T : class {
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
}

public class InMemoryRepository<T> : IRepository<T> where T : class {
    protected readonly List<T> _items = new();
    public virtual T? GetById(int id) => _items.FirstOrDefault();
    public virtual IEnumerable<T> GetAll() => _items;
    public virtual void Add(T entity) => _items.Add(entity);
    public virtual void Remove(T entity) => _items.Remove(entity);
}
