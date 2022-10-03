using System;

namespace Choreography
{
    public class Ticketing
    {
        private readonly ILogger logger;

        public Ticketing(ILogger logger)
        {
            this.logger = logger;
        }

        public void PrintTickets(int numSeats)
        {
            logger.Log($"Printing tickets for {numSeats} seats");
        }
    }
}