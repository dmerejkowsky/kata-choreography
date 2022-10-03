using Choreography.Events;

namespace Choreography
{
    public interface ISubscriber
    {
        void OnEvent(IEvent e);
    }
}