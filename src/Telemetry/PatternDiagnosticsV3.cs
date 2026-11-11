namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV3(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
