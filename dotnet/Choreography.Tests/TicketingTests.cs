using Xunit;

namespace Choreography.Test
{
    public class TicketingTests
    {
        [Fact]  
        public void CanPrintTickets()
        {
            var ticketing = new Ticketing();
            ticketing.PrintTickets(4);

        }
    }
}
