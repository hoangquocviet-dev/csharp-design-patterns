namespace DesignPatterns.Behavioral.TemplateMethod;

public abstract class DataPipeline {
    public void Run() {
        Extract();
        Transform();
        Load();
    }
    protected abstract void Extract();
    protected abstract void Transform();
    protected abstract void Load();
}

public class CsvPipeline : DataPipeline {
    protected override void Extract() => Console.WriteLine("Extracting CSV");
    protected override void Transform() => Console.WriteLine("Transforming CSV to Objects");
    protected override void Load() => Console.WriteLine("Loading into DB");
}
