namespace DesignPatterns.Behavioral.Strategy;

public interface IDiscountStrategy { decimal Apply(decimal originalPrice); }

public class RegularDiscount : IDiscountStrategy {
    public decimal Apply(decimal price) => price;
}

public class VipDiscount : IDiscountStrategy {
    public decimal Apply(decimal price) => price * 0.85m;
}

public class BlackFridayDiscount : IDiscountStrategy {
    public decimal Apply(decimal price) => price * 0.50m;
}
