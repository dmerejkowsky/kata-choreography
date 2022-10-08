using System.Collections.Generic;
using Choreography.Events;

namespace Choreography;

public class EventBus
{
    private readonly List<ISubscriber> _subscribers;

    public EventBus()
    {
        _subscribers = new List<ISubscriber>();
    }

    public void Emit(IEvent e)
    {
        _subscribers.ForEach(s => s.OnEvent(e));
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
}