using System.Collections.Generic;

namespace DesignPatterns.Structural.Composite;

public interface IFileSystemItem {
    string GetName();
    long GetSize();
}

public class FileItem : IFileSystemItem {
    private readonly string _name;
    private readonly long _size;
    public FileItem(string name, long size) { _name = name; _size = size; }
    public string GetName() => _name;
    public long GetSize() => _size;
}

public class FolderItem : IFileSystemItem {
    private readonly string _name;
    private readonly List<IFileSystemItem> _items = new();
    public FolderItem(string name) => _name = name;
    public void Add(IFileSystemItem item) => _items.Add(item);
    public string GetName() => _name;
    public long GetSize() {
        long total = 0;
        foreach (var i in _items) total += i.GetSize();
        return total;
    }
}
