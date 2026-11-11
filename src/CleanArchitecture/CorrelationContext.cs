namespace DesignPatterns.CleanArchitecture;

using System;

public sealed record CorrelationContext(string CorrelationId, DateTime CreatedAtUtc);
