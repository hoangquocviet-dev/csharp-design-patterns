namespace DesignPatterns.Behavioral.ChainOfResponsibility;

public abstract class Approver {
    protected Approver? _successor;
    public void SetSuccessor(Approver s) => _successor = s;
    public abstract string ProcessRequest(decimal amount);
}

public class TeamLead : Approver {
    public override string ProcessRequest(decimal amount) => 
        amount <= 1000 ? "TeamLead Approved" : _successor?.ProcessRequest(amount) ?? "Denied";
}

public class Director : Approver {
    public override string ProcessRequest(decimal amount) => 
        amount <= 10000 ? "Director Approved" : _successor?.ProcessRequest(amount) ?? "Denied";
}
