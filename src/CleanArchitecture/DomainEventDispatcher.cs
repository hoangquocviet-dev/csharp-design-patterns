namespace DesignPatterns.CleanArchitecture;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent, CancellationToken cancellationToken = default);
}

public sealed class DomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public DomainEventDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
}
