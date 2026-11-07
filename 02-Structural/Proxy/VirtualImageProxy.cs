namespace DesignPatterns.Structural.Proxy;

public interface IImage { void Display(); }

public class RealImage : IImage {
    private readonly string _filename;
    public RealImage(string filename) {
        _filename = filename;
        Console.WriteLine($"Heavy Loading {_filename} from disk...");
    }
    public void Display() => Console.WriteLine($"Displaying {_filename}");
}

public class VirtualImageProxy : IImage {
    private readonly string _filename;
    private RealImage? _realImage;
    public VirtualImageProxy(string filename) => _filename = filename;

    public void Display() {
        _realImage ??= new RealImage(_filename);
        _realImage.Display();
    }
}
