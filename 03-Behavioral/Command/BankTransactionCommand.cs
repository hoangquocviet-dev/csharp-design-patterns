namespace DesignPatterns.Behavioral.Command;

public interface ITransactionCommand {
    void Execute();
    void Undo();
}

public class Account {
    public decimal Balance { get; set; } = 0;
}

public class DepositCommand : ITransactionCommand {
    private readonly Account _account;
    private readonly decimal _amount;
    public DepositCommand(Account acc, decimal amount) { _account = acc; _amount = amount; }
    public void Execute() => _account.Balance += _amount;
    public void Undo() => _account.Balance -= _amount;
}
