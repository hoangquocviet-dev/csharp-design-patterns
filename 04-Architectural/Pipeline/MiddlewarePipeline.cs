using System;
using System.Collections.Generic;

namespace DesignPatterns.Architectural.Pipeline;

public delegate void HttpDelegate(string context);

public class PipelineBuilder {
    private readonly List<Func<HttpDelegate, HttpDelegate>> _components = new();

    public PipelineBuilder Use(Func<HttpDelegate, HttpDelegate> middleware) {
        _components.Add(middleware);
        return this;
    }

    public HttpDelegate Build() {
        HttpDelegate app = (ctx) => Console.WriteLine($"Handled: {ctx}");
        for (int i = _components.Count - 1; i >= 0; i--) {
            app = _components[i](app);
        }
        return app;
    }
}
