using System.Collections.Generic;
using System.Linq;
using Choreography.Events;
using Xunit;

namespace Choreography.Test;

public class TicketingTests
{
    private readonly SpyLogger _spyLogger;
    private readonly SpySubscriber _spySubscriber;
    private readonly Ticketing _ticketing;

    public TicketingTests()
    {
        _spyLogger = new SpyLogger();
        var bus = new EventBus();
        _spySubscriber = new SpySubscriber();
        bus.Subscribe(_spySubscriber);
        var context = new Context(_spyLogger, bus);
        _ticketing = new Ticketing(context);
    }

    [Fact]
    public void CanPrintTickets()
    {
        _ticketing.PrintTickets(4);
    }

    [Fact]
    public void LogsWhenPrintingTickets()
    {
        _ticketing.PrintTickets(3);

        var messages = _spyLogger.Messages();
        Assert.Equal(
            new List<string> { "Printing tickets for 3 seats" },
            messages
        );
    }

    [Fact]
    public void PrintTicketWhenReceivingCapacityUpdated()
    {
        _ticketing.OnEvent(new CapacityUpdated(97, 3));

        var messages = _spyLogger.Messages();
        Assert.Equal(
            new List<string> { "Printing tickets for 3 seats" },
            messages
        );
    }

    [Fact]
    public void EmitTicketPrintedWhenPrintingTickets()
    {
        _ticketing.PrintTickets(3);

        var expected = new List<string> { "TicketPrinted()" };
        var caughtEvents = _spySubscriber.CaughtEvents().Select(e => e.Display());
        Assert.Equal(expected, caughtEvents);
    }
}