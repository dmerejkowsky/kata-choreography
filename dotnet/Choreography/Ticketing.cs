using Choreography.Events;

namespace Choreography;

public class Ticketing : ISubscriber
{
    private readonly Context _context;

    public Ticketing(Context context)
    {
        _context = context;
        var bus = _context.Bus();
        bus.Subscribe(this);
    }


    public void OnEvent(IEvent e)
    {
        if (e is CapacityUpdated capacityUpdated)
        {
            var numSeats = capacityUpdated.BookedSeats;
            PrintTickets(numSeats);
        }
    }

    public void PrintTickets(int numSeats)
    {
        _context.Logger().Log($"Printing tickets for {numSeats} seats");
        _context.Bus().Emit(new TicketPrinted());
    }
}