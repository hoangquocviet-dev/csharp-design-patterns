using System.Text.RegularExpressions;

namespace DesignPatterns.Behavioral.Strategy;

public interface IValidationStrategy { bool Validate(string input); }

public class EmailValidationStrategy : IValidationStrategy {
    public bool Validate(string input) => input.Contains("@") && input.Contains(".");
}

public class NumericValidationStrategy : IValidationStrategy {
    public bool Validate(string input) => decimal.TryParse(input, out _);
}
