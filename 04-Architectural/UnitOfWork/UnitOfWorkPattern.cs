using System;

namespace DesignPatterns.Architectural.UnitOfWork;

public interface IUnitOfWork : IDisposable {
    void Commit();
    void Rollback();
}

public class SqlUnitOfWork : IUnitOfWork {
    public void Commit() => Console.WriteLine("Transaction Committed.");
    public void Rollback() => Console.WriteLine("Transaction Rolled Back.");
    public void Dispose() { }
}
