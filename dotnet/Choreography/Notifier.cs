using Choreography.Events;

namespace Choreography;

public class Notifier : ISubscriber
{
    private readonly Context _context;

    public Notifier(Context context)
    {
        _context = context;
        _context.Bus().Subscribe(this);
    }

    public void OnEvent(IEvent e)
    {
        if (e is TicketPrinted) _context.Logger().Log("Sending: your tickets have been printed");
        if (e is OverBooked) _context.Logger().Log("Sending: sorry, event is overbooked");
    }
}