namespace DesignPatterns.Structural.Bridge;

public interface IDevice {
    void TurnOn();
    void TurnOff();
}

public class TvDevice : IDevice {
    public void TurnOn() => Console.WriteLine("TV On");
    public void TurnOff() => Console.WriteLine("TV Off");
}

public class RadioDevice : IDevice {
    public void TurnOn() => Console.WriteLine("Radio On");
    public void TurnOff() => Console.WriteLine("Radio Off");
}

public class RemoteControl {
    protected readonly IDevice _device;
    public RemoteControl(IDevice device) => _device = device;
    public void TogglePower(bool on) { if (on) _device.TurnOn(); else _device.TurnOff(); }
}
