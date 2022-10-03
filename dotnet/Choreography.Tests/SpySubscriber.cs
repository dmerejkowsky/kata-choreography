using Choreography.Events;
using System;
using System.Collections.Generic;

namespace Choreography.Test
{
    internal class SpySubscriber : ISubscriber
    {
        private readonly List<IEvent> caughtEvents;

        public SpySubscriber()
        {
            caughtEvents = new List<IEvent>();
        }

        public void OnEvent(IEvent e)
        {
            caughtEvents.Add(e);
        }

        public List<IEvent> CaughtEvents() => caughtEvents;

    }
}