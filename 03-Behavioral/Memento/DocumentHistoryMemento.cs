namespace DesignPatterns.Behavioral.Memento;

public class DocumentMemento {
    public string Content { get; }
    public DocumentMemento(string content) => Content = content;
}

public class DocumentOriginator {
    public string Content { get; set; } = "";
    public DocumentMemento Save() => new(Content);
    public void Restore(DocumentMemento memento) => Content = memento.Content;
}
