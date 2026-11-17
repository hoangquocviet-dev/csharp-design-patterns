namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV9(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
