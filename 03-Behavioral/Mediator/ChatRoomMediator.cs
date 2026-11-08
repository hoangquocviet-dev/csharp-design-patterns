using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Mediator;

public interface IChatMediator {
    void SendMessage(string sender, string message);
    void Register(ChatUser user);
}

public class ChatUser {
    public string Name { get; }
    private readonly IChatMediator _mediator;
    public ChatUser(string name, IChatMediator mediator) { Name = name; _mediator = mediator; }
    public void Send(string msg) => _mediator.SendMessage(Name, msg);
    public void Receive(string from, string msg) => Console.WriteLine($"[{Name}] received from {from}: {msg}");
}
