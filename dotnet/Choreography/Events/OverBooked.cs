namespace Choreography.Events;

public readonly record struct OverBooked : IEvent
{
    public string Display()
    {
        return "OverBooked()";
    }
}