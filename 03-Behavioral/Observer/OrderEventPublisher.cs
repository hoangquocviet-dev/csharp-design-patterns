using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer;

public record OrderPlacedEvent(string OrderId, decimal Amount);

public class OrderEventPublisher {
    private readonly List<Action<OrderPlacedEvent>> _listeners = new();
    public void Subscribe(Action<OrderPlacedEvent> listener) => _listeners.Add(listener);
    public void Publish(OrderPlacedEvent ev) {
        foreach (var l in _listeners) l(ev);
    }
}
