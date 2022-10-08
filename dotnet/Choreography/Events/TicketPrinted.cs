namespace Choreography.Events;

public readonly record struct TicketPrinted : IEvent
{
    public string Display()
    {
        return "TicketPrinted()";
    }
}