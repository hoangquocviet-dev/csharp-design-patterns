using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Command;

public class TextEditor {
    public string Content { get; set; } = "";
}

public class AppendTextCommand : ITransactionCommand {
    private readonly TextEditor _editor;
    private readonly string _text;
    public AppendTextCommand(TextEditor editor, string text) { _editor = editor; _text = text; }
    public void Execute() => _editor.Content += _text;
    public void Undo() => _editor.Content = _editor.Content[..^_text.Length];
}
