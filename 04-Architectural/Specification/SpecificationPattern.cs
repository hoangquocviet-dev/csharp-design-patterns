using System;
using System.Linq.Expressions;

namespace DesignPatterns.Architectural.Specification;

public interface ISpecification<T> {
    bool IsSatisfiedBy(T entity);
}

public class PremiumCustomerSpecification : ISpecification<int> {
    public bool IsSatisfiedBy(int totalPurchases) => totalPurchases > 1000;
}
