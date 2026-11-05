namespace DesignPatterns.Creational.AbstractFactory;

public interface IButton { string Render(); }
public interface ITextBox { string Render(); }

public class DarkButton : IButton { public string Render() => "Dark Button Rendered"; }
public class DarkTextBox : ITextBox { public string Render() => "Dark TextBox Rendered"; }

public class LightButton : IButton { public string Render() => "Light Button Rendered"; }
public class LightTextBox : ITextBox { public string Render() => "Light TextBox Rendered"; }

public interface IGuiFactory {
    IButton CreateButton();
    ITextBox CreateTextBox();
}

public class DarkThemeFactory : IGuiFactory {
    public IButton CreateButton() => new DarkButton();
    public ITextBox CreateTextBox() => new DarkTextBox();
}

public class LightThemeFactory : IGuiFactory {
    public IButton CreateButton() => new LightButton();
    public ITextBox CreateTextBox() => new LightTextBox();
}
