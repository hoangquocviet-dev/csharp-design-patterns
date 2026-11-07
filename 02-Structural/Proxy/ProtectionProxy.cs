namespace DesignPatterns.Structural.Proxy;

public interface ISensitiveReport { string ReadReport(); }

public class RealSensitiveReport : ISensitiveReport {
    public string ReadReport() => "CONFIDENTIAL_DATA";
}

public class ProtectionProxy : ISensitiveReport {
    private readonly ISensitiveReport _real = new RealSensitiveReport();
    private readonly string _userRole;
    public ProtectionProxy(string userRole) => _userRole = userRole;

    public string ReadReport() => _userRole == "Admin" ? _real.ReadReport() : "ACCESS_DENIED";
}
