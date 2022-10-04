
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Xunit;

namespace Choreography.Test
{
    public class OrchestratorTest
    {
        private readonly SpyLogger _logger;
        private readonly Context _context;
        private readonly Orchestrator _orchestrator;
        public OrchestratorTest() {
            _logger = new SpyLogger();
            var bus = new EventBus();
            _context = new Context(_logger, bus);
            var totalSeats = 100;
            var inventory = new Inventory(_context, totalSeats);
            var booking = new Booking(_context);
            var ticketing = new Ticketing(_context);
            _orchestrator = new Orchestrator(booking, inventory, ticketing);
        }

        [Fact]
        public void CanBookWhenEnoughRoom()
        {
            _orchestrator.Book(4);

            var loggedMessages = _logger.Messages();
            var expected = new List<string> { "Booking 4 seats", "Capacity is now at 96", "Printing tickets for 4 seats" };
            Assert.Equal(expected, loggedMessages);
        }

        [Fact]
        public void DoNotPrintTicketsWhenNotEnoughRoom()
        {
            Assert.Throws<OverbookedException>(() => _orchestrator.Book(104));
        }
    }
}
