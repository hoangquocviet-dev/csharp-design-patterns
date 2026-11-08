namespace DesignPatterns.Behavioral.State;

public interface IOrderState {
    void Next(OrderContext ctx);
    string GetStatus();
}

public class OrderContext {
    public IOrderState State { get; set; } = new PendingState();
    public void Next() => State.Next(this);
}

public class PendingState : IOrderState {
    public void Next(OrderContext ctx) => ctx.State = new ShippedState();
    public string GetStatus() => "Pending";
}

public class ShippedState : IOrderState {
    public void Next(OrderContext ctx) => ctx.State = new DeliveredState();
    public string GetStatus() => "Shipped";
}

public class DeliveredState : IOrderState {
    public void Next(OrderContext ctx) { }
    public string GetStatus() => "Delivered";
}
