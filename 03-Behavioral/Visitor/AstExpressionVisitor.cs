namespace DesignPatterns.Behavioral.Visitor;

public interface IExpressionVisitor {
    int VisitLiteral(int value);
    int VisitAdd(int left, int right);
}
