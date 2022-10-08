using Choreography.Events;

namespace Choreography;

public class Inventory : ISubscriber
{
    private readonly Context _context;
    private int _capacity;


    public Inventory(Context context, int totalSeats)
    {
        _capacity = totalSeats;
        _context = context;
        _context.Bus().Subscribe(this);
    }

    public void OnEvent(IEvent e)
    {
        var bus = _context.Bus();
        if (e is BookingRequested bookingRequested)
        {
            var numSeats = bookingRequested.NumSeats;
            try
            {
                DecrementCapacity(numSeats);

                bus.Emit(new CapacityUpdated(_capacity, numSeats));
            }
            catch (OverbookedException)
            {
                bus.Emit(new OverBooked());
            }
        }
    }

    public int CurrentCapacity()
    {
        return _capacity;
    }

    public void DecrementCapacity(int numSeats)
    {
        if (numSeats > _capacity)
        {
            _context.Logger().Log("OverBooked");
            throw new OverbookedException();
        }

        _capacity -= numSeats;
        _context.Logger().Log($"Capacity is now at {_capacity}");
    }
}