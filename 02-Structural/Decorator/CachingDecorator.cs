using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator;

public interface IDataService {
    string GetData(string id);
}

public class SqlDataService : IDataService {
    public string GetData(string id) => $"SQL_Result_{id}";
}

public class CachingDataServiceDecorator : IDataService {
    private readonly IDataService _inner;
    private readonly Dictionary<string, string> _cache = new();
    public CachingDataServiceDecorator(IDataService inner) => _inner = inner;

    public string GetData(string id) {
        if (_cache.TryGetValue(id, out var val)) return val;
        val = _inner.GetData(id);
        _cache[id] = val;
        return val;
    }
}
