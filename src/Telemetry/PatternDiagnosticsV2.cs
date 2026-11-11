namespace DesignPatterns.Telemetry;

using System;

public sealed record PatternDiagnosticsV2(string PatternName, long ElapsedTicks, DateTime RecordedAtUtc);
