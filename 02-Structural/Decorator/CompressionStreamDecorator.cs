namespace DesignPatterns.Structural.Decorator;

public interface ICustomStream {
    string Write(string data);
}

public class PlainStream : ICustomStream {
    public string Write(string data) => data;
}

public class CompressedStreamDecorator : ICustomStream {
    private readonly ICustomStream _inner;
    public CompressedStreamDecorator(ICustomStream inner) => _inner = inner;
    public string Write(string data) => $"GZIP({_inner.Write(data)})";
}
