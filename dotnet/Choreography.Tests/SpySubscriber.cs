using System.Collections.Generic;

namespace Choreography.Test;

internal class SpySubscriber : ISubscriber
{
    private readonly List<IEvent> _caughtEvents;

    public SpySubscriber()
    {
        _caughtEvents = new List<IEvent>();
    }

    public void OnEvent(IEvent e)
    {
        _caughtEvents.Add(e);
    }

    public IEnumerable<IEvent> CaughtEvents()
    {
        return _caughtEvents;
    }
}