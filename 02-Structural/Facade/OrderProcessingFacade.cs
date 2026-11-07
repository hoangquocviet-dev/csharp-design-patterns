namespace DesignPatterns.Structural.Facade;

public class InventoryService { public bool CheckStock(string id) => true; }
public class PaymentService { public bool Pay(decimal amount) => true; }
public class ShippingService { public string Ship(string id) => "TRACK_12345"; }

public class OrderProcessingFacade {
    private readonly InventoryService _inventory = new();
    private readonly PaymentService _payment = new();
    private readonly ShippingService _shipping = new();

    public bool PlaceOrder(string productId, decimal amount) {
        if (!_inventory.CheckStock(productId)) return false;
        if (!_payment.Pay(amount)) return false;
        _shipping.Ship(productId);
        return true;
    }
}
