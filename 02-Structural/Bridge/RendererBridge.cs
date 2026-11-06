namespace DesignPatterns.Structural.Bridge;

public interface IRenderer {
    string RenderCircle(float radius);
}

public class VectorRenderer : IRenderer {
    public string RenderCircle(float radius) => $"Drawing vector circle radius {radius}";
}

public class RasterRenderer : IRenderer {
    public string RenderCircle(float radius) => $"Drawing pixels for circle radius {radius}";
}
