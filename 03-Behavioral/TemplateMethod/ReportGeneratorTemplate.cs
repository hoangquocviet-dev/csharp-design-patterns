namespace DesignPatterns.Behavioral.TemplateMethod;

public abstract class ReportGenerator {
    public string Generate() => $"{FormatHeader()}\n{FormatBody()}\n{FormatFooter()}";
    protected virtual string FormatHeader() => "=== Header ===";
    protected abstract string FormatBody();
    protected virtual string FormatFooter() => "=== End of Report ===";
}
