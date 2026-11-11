namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV4(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
