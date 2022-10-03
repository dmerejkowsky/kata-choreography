using System;

namespace Choreography
{
    public class Inventory
    {
        private readonly ILogger logger;
        private int capacity;


        public Inventory(ILogger logger, int totalSeats)
        {
            this.logger = logger;
            capacity = totalSeats;
        }

        public int CurrentCapacity()
        {
            return capacity;
        }

        public void DecrementCapacity(int numSeats)
        {
            if (numSeats > capacity)
            {
                throw new OverbookedException();
            }

            capacity -= numSeats;
            logger.Log($"Capacity is now at {capacity}");
        }
    }
}