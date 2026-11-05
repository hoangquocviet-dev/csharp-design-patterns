using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Prototype;

public class DocumentPrototype : ICloneable {
    public string Title { get; set; } = "";
    public List<string> Tags { get; set; } = new();

    public object Clone() {
        return new DocumentPrototype {
            Title = this.Title,
            Tags = new List<string>(this.Tags)
        };
    }
}
