namespace DesignPatterns.Behavioral.Mediator;

public interface IDialogMediator { void Notify(object sender, string ev); }

public class ButtonComponent {
    private readonly IDialogMediator _m;
    public ButtonComponent(IDialogMediator m) => _m = m;
    public void Click() => _m.Notify(this, "click");
}
