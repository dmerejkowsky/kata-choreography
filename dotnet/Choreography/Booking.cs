using Choreography.Events;

namespace Choreography;

public class Booking
{
    private readonly Context _context;

    public Booking(Context context)
    {
        _context = context;
    }

    public void Book(int numSeats)
    {
        _context.Logger().Log($"Booking {numSeats} seats");
        _context.Bus().Emit(new BookingRequested(numSeats));
    }
}