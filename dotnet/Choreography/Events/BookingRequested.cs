namespace Choreography.Events;

public readonly record struct BookingRequested(int NumSeats) : IEvent
{
    public string Display()
    {
        return $"BookingRequested({NumSeats})";
    }
}