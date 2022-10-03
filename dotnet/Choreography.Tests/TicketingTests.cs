using Xunit;

namespace Choreography.Test
{
    public class TicketingTests
    {
        private readonly SpyLogger logger;

        public TicketingTests()
        {
            this.logger = new SpyLogger();
        }

        [Fact]  
        public void CanPrintTickets()
        {
            var ticketing = new Ticketing(logger);
            ticketing.PrintTickets(4);
        }
    }
}
