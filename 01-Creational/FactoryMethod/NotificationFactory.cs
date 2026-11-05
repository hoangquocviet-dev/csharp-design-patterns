namespace DesignPatterns.Creational.FactoryMethod;

public interface INotification {
    string Send(string message);
}

public class EmailNotification : INotification {
    public string Send(string message) => $"[Email] {message}";
}

public class SmsNotification : INotification {
    public string Send(string message) => $"[SMS] {message}";
}

public abstract class NotificationCreator {
    public abstract INotification CreateNotification();
}

public class EmailCreator : NotificationCreator {
    public override INotification CreateNotification() => new EmailNotification();
}

public class SmsCreator : NotificationCreator {
    public override INotification CreateNotification() => new SmsNotification();
}
