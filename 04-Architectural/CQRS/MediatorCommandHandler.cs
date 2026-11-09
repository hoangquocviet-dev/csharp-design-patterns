namespace DesignPatterns.Architectural.CQRS;

public interface ICommand<TResult> { }
public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand<TResult> {
    TResult Handle(TCommand command);
}

public record CreateUserCommand(string Username, string Email) : ICommand<int>;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, int> {
    public int Handle(CreateUserCommand command) => 1;
}
