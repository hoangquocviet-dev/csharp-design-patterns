namespace DesignPatterns.Architectural.OptionsPattern;

public class DatabaseOptions {
    public const string SectionName = "Database";
    public string ConnectionString { get; set; } = "";
    public int TimeoutSeconds { get; set; } = 30;
}
