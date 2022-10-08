namespace Choreography;

public interface ISubscriber
{
    void OnEvent(IEvent e);
}