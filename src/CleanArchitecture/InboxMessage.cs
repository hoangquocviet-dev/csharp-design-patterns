namespace DesignPatterns.CleanArchitecture;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed record InboxMessage(Guid MessageId, string ConsumerName, DateTime ProcessedOnUtc);
