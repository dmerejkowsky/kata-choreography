using Choreography.Events;
using System.Collections.Generic;

namespace Choreography
{

    public class EventBus
    {
        private readonly List<ISubscriber> subscribers;

        public EventBus()
        {
            subscribers = new List<ISubscriber>();
        }

        public void Emit(IEvent e)
        {
            subscribers.ForEach(s => s.OnEvent(e));
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }
    }
}