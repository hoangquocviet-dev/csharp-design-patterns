namespace CSharpDesignPatterns.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
    ISpecification<T> And(ISpecification<T> other);
    ISpecification<T> Or(ISpecification<T> other);
    ISpecification<T> Not();
}

public abstract class Specification<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T candidate);

    public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);

    public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);

    public ISpecification<T> Not() => new NotSpecification<T>(this);
}

internal sealed class AndSpecification<T>(ISpecification<T> left, ISpecification<T> right) : Specification<T>
{
    public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) && right.IsSatisfiedBy(candidate);
}

internal sealed class OrSpecification<T>(ISpecification<T> left, ISpecification<T> right) : Specification<T>
{
    public override bool IsSatisfiedBy(T candidate) => left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
}

internal sealed class NotSpecification<T>(ISpecification<T> inner) : Specification<T>
{
    public override bool IsSatisfiedBy(T candidate) => !inner.IsSatisfiedBy(candidate);
}

public class ExpressionSpecification<T>(Func<T, bool> expression) : Specification<T>
{
    private readonly Func<T, bool> _expression = expression ?? throw new ArgumentNullException(nameof(expression));

    public override bool IsSatisfiedBy(T candidate) => _expression(candidate);
}
