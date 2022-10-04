using Xunit;

namespace Choreography.Test
{
    public class TicketingTests
    {
        private readonly SpyLogger _logger;
        private readonly Context _context;

        public TicketingTests()
        {
            _logger = new SpyLogger();
            var bus = new EventBus();
            _context = new Context(_logger, bus);
        }

        [Fact]  
        public void CanPrintTickets()
        {
            var ticketing = new Ticketing(_context);
            ticketing.PrintTickets(4);
        }
    }
}
