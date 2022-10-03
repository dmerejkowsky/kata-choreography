using System;
namespace Choreography {

    public class Booking {
        private readonly ILogger logger;

        public Booking(ILogger logger)
        {
            this.logger = logger;
        }

        public void Book(int numSeats)
        {
            logger.Log($"Booking {numSeats} seats");
        }
    }
}