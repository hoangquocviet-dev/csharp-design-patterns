namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV6(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
