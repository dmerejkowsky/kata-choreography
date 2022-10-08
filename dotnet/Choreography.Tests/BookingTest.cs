using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Choreography.Test;

public class BookingTest
{
    private readonly Booking _booking;
    private readonly SpySubscriber _spySubscriber;

    public BookingTest()
    {
        var logger = new SpyLogger();
        _spySubscriber = new SpySubscriber();
        var bus = new EventBus();
        bus.Subscribe(_spySubscriber);
        var context = new Context(logger, bus);
        _booking = new Booking(context);
    }

    [Fact]
    public void EmitBookingRequestedEvent()
    {
        _booking.Book(4);

        var caught = _spySubscriber.CaughtEvents().Select(e => e.Display());
        var expected = new List<string> { "BookingRequested(4)" };
        Assert.Equal(expected, caught);
    }
}