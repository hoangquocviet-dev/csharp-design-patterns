using System.Collections.Concurrent;

namespace DesignPatterns.Creational.ObjectPool;

public class DbConnectionItem {
    public string Id { get; } = Guid.NewGuid().ToString("N")[..8];
}

public class ConnectionPool {
    private readonly ConcurrentBag<DbConnectionItem> _pool = new();

    public DbConnectionItem Acquire() => _pool.TryTake(out var conn) ? conn : new DbConnectionItem();
    public void Release(DbConnectionItem conn) => _pool.Add(conn);
}
