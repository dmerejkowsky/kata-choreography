namespace Choreography.Events;

public readonly record struct CapacityUpdated(int NewCapacity, int BookedSeats) : IEvent
{
    public string Display()
    {
        return $"CapacityUpdated({NewCapacity}, {BookedSeats})";
    }
}