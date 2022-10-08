using System.Collections.Generic;
using System.Linq;
using Choreography.Events;
using Xunit;

namespace Choreography.Test;

public class EventsTest
{
    [Fact]
    public void DummyEventWorksAsExpected()
    {
        var dummy = new DummyEvent(42);
        Assert.Equal(42, dummy.Value);
    }

    [Fact]
    public void SpySubscriberWorks()
    {
        var bus = new EventBus();
        var spySubscriber = new SpySubscriber();
        bus.Subscribe(spySubscriber);

        bus.Emit(new DummyEvent(42));

        var caughtEvents = spySubscriber.CaughtEvents().Select(e => e.Display());
        var expected = new List<string> { "42" };
        Assert.Equal(caughtEvents, expected);
    }
}