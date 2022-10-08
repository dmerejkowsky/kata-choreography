using System.Collections.Generic;
using System.Linq;
using Choreography.Events;
using Xunit;

namespace Choreography.Test;

public class InventoryTest
{
    private readonly Inventory _inventory;
    private readonly SpySubscriber _spySubscriber;

    public InventoryTest()
    {
        var logger = new SpyLogger();
        var bus = new EventBus();
        _spySubscriber = new SpySubscriber();
        bus.Subscribe(_spySubscriber);
        var context = new Context(logger, bus);
        _inventory = new Inventory(context, 100);
    }

    [Fact]
    public void UpdateCapacityWhenEnoughFreeSeats()
    {
        _inventory.DecrementCapacity(10);

        var newCapacity = _inventory.CurrentCapacity();
        Assert.Equal(90, newCapacity);
    }

    [Fact]
    public void ThrowWhenOverBooked()
    {
        Assert.Throws<OverbookedException>(() => _inventory.DecrementCapacity(120));
    }

    [Fact]
    public void UpdateCapacityWhenReceivingBookingRequestedEvent()
    {
        _inventory.OnEvent(new BookingRequested(4));
        Assert.Equal(96, _inventory.CurrentCapacity());
    }

    [Fact]
    public void EmitCapacityUpdatedOnSuccess()
    {
        _inventory.OnEvent(new BookingRequested(4));

        var expected = new List<string> { "CapacityUpdated(96, 4)" };
        var caughtEvents = _spySubscriber.CaughtEvents().Select(e => e.Display());
        Assert.Equal(expected, caughtEvents);
    }

    [Fact]
    public void EmitOverBookedOnFailure()
    {
        _inventory.OnEvent(new BookingRequested(105));

        var expected = new List<string> { "OverBooked()" };
        var caughtEvents = _spySubscriber.CaughtEvents().Select(e => e.Display());
        Assert.Equal(expected, caughtEvents);
    }
}