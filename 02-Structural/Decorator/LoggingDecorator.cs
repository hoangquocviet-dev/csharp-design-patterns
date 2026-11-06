namespace DesignPatterns.Structural.Decorator;

public interface ICommandService {
    void Execute(string command);
}

public class BaseCommandService : ICommandService {
    public void Execute(string command) => Console.WriteLine($"Executing {command}");
}

public class LoggingCommandServiceDecorator : ICommandService {
    private readonly ICommandService _inner;
    public LoggingCommandServiceDecorator(ICommandService inner) => _inner = inner;
    public void Execute(string command) {
        Console.WriteLine($"[START] Command: {command}");
        _inner.Execute(command);
        Console.WriteLine($"[END] Command: {command}");
    }
}
