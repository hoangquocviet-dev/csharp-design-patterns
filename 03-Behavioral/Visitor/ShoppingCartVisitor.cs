namespace DesignPatterns.Behavioral.Visitor;

public interface IVisitor { void Visit(BookItem book); void Visit(FruitItem fruit); }

public interface ICartItem { void Accept(IVisitor visitor); }

public class BookItem : ICartItem {
    public decimal Price { get; } = 20m;
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class FruitItem : ICartItem {
    public decimal PricePerKg { get; } = 5m;
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}
