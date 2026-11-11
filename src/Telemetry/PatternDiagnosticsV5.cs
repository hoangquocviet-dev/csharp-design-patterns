namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV5(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
