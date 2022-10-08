using System.Collections.Generic;
using Xunit;

namespace Choreography.Test;

public class ChoreographyTest
{
    private readonly Booking _booking;
    private readonly Inventory _inventory;
    private readonly SpyLogger _logger;
    private readonly Ticketing _ticketing;

    public ChoreographyTest()
    {
        const int totalSeats = 100;
        _logger = new SpyLogger();
        var bus = new EventBus();
        var context = new Context(_logger, bus);
        _inventory = new Inventory(context, totalSeats);
        _booking = new Booking(context);
        _ticketing = new Ticketing(context);
    }

    [Fact]
    public void CanBookWhenEnoughRoom()
    {
        _booking.Book(4);

        var loggedMessages = _logger.Messages();
        var expected = new List<string> { "Booking 4 seats", "Capacity is now at 96", "Printing tickets for 4 seats" };
        Assert.Equal(expected, loggedMessages);
    }

    [Fact]
    public void DoNotPrintTicketsWhenNotEnoughRoom()
    {
        _booking.Book(104);

        var loggedMessages = _logger.Messages();
        var expected = new List<string> { "Booking 104 seats", "OverBooked" };
        Assert.Equal(expected, loggedMessages);
    }
}