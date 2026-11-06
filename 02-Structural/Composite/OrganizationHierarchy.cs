using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite;

public interface IEmployee {
    decimal GetSalary();
}

public class Developer : IEmployee {
    private readonly decimal _salary;
    public Developer(decimal salary) => _salary = salary;
    public decimal GetSalary() => _salary;
}

public class Manager : IEmployee {
    private readonly List<IEmployee> _subordinates = new();
    private readonly decimal _salary;
    public Manager(decimal salary) => _salary = salary;
    public void AddSubordinate(IEmployee e) => _subordinates.Add(e);
    public decimal GetSalary() {
        decimal total = _salary;
        foreach (var sub in _subordinates) total += sub.GetSalary();
        return total;
    }
}
