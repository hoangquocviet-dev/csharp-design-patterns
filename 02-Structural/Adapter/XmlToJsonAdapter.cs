namespace DesignPatterns.Structural.Adapter;

public interface IJsonDataProvider {
    string GetJson();
}

public class LegacyXmlService {
    public string GetXml() => "<data><id>101</id></data>";
}

public class XmlToJsonAdapter : IJsonDataProvider {
    private readonly LegacyXmlService _xmlService = new();
    public string GetJson() => "{"id": 101}";
}
