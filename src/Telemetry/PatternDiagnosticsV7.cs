namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV7(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
