using System.Collections.Generic;

namespace DesignPatterns.Structural.Flyweight;

public class CharacterGlyph {
    public char Symbol { get; }
    public string FontFamily { get; }
    public CharacterGlyph(char symbol, string font) { Symbol = symbol; FontFamily = font; }
}

public class GlyphFactory {
    private readonly Dictionary<string, CharacterGlyph> _glyphs = new();
    public CharacterGlyph GetGlyph(char symbol, string font) {
        string key = $"{symbol}_{font}";
        if (!_glyphs.TryGetValue(key, out var glyph)) {
            glyph = new CharacterGlyph(symbol, font);
            _glyphs[key] = glyph;
        }
        return glyph;
    }
}
