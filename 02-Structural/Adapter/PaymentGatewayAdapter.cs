namespace DesignPatterns.Structural.Adapter;

public interface IPaymentProcessor {
    bool Charge(decimal amount);
}

public class StripeLegacyService {
    public string MakeTransaction(double totalDollars) => "Stripe_Success";
}

public class StripePaymentAdapter : IPaymentProcessor {
    private readonly StripeLegacyService _legacy = new();
    public bool Charge(decimal amount) => _legacy.MakeTransaction((double)amount) == "Stripe_Success";
}
