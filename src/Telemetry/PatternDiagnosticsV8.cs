namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV8(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
