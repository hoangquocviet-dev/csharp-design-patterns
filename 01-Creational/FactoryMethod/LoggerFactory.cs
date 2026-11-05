namespace DesignPatterns.Creational.FactoryMethod;

public interface ICustomLogger {
    void Log(string message);
}

public class FileLogger : ICustomLogger {
    public void Log(string message) => Console.WriteLine($"[FileLog] {message}");
}

public class ConsoleLogger : ICustomLogger {
    public void Log(string message) => Console.WriteLine($"[ConsoleLog] {message}");
}
