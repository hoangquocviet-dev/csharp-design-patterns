using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpDesignPatterns.Messaging;

public interface IEventBus
{
    void Subscribe<TEvent>(Func<TEvent, CancellationToken, Task> handler) where TEvent : class;
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class;
}

public sealed class InMemoryEventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, List<Delegate>> _handlers = new();

    public void Subscribe<TEvent>(Func<TEvent, CancellationToken, Task> handler) where TEvent : class
    {
        ArgumentNullException.ThrowIfNull(handler);
        _handlers.AddOrUpdate(
            typeof(TEvent),
            _ => [handler],
            (_, existing) => {
                lock (existing)
                {
                    existing.Add(handler);
                    return existing;
                }
            });
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class
    {
        ArgumentNullException.ThrowIfNull(@event);
        
        if (!_handlers.TryGetValue(typeof(TEvent), out var handlers))
        {
            return;
        }

        List<Delegate> snapshot;
        lock (handlers)
        {
            snapshot = [.. handlers];
        }

        var tasks = snapshot
            .Cast<Func<TEvent, CancellationToken, Task>>()
            .Select(handler => handler(@event, cancellationToken));

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}
