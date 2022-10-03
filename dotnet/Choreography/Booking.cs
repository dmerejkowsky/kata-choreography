using System;
namespace Choreography {

    public class Booking {
        private readonly ILogger logger;

        public Booking(ILogger logger)
        {
            this.logger = logger;
        }

        public void Book(int numSeats) {
            int totalSeats = 100;
            logger.Log($"Booking {numSeats} seats");
            var inventory = new Inventory(logger, totalSeats);
            inventory.DecrementCapacity(numSeats);
            var ticketing = new Ticketing(logger);
            ticketing.PrintTickets(numSeats);
        }

    }
}