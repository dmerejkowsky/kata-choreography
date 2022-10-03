
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Xunit;

namespace Choreography.Test
{
    public class OrchestratorTest
    {
        private readonly SpyLogger logger;
        private readonly Orchestrator orchestrator;
        public OrchestratorTest() {
            logger = new SpyLogger();
            var totalSeats = 100;
            var inventory = new Inventory(logger, totalSeats);
            var booking = new Booking(logger);
            var ticketing = new Ticketing(logger);
            orchestrator = new Orchestrator(booking, inventory, ticketing);
        }

        [Fact]
        public void CanBookWhenEnoughRoom()
        {
            orchestrator.Book(4);

            var loggedMessages = logger.Messages();
            var expected = new List<string> { "Booking 4 seats", "Capacity is now at 96", "Printing tickets for 4 seats" };
            Assert.Equal(expected, loggedMessages);
        }

        [Fact]
        public void DoNotPrintTicketsWhenNotEnoughRoom()
        {
            Assert.Throws<OverbookedException>(() => orchestrator.Book(104));
        }
    }
}
