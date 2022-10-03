using System;

namespace Choreography
{
    public class Inventory
    {
        private readonly Context context;
        private int capacity;


        public Inventory(Context context, int totalSeats)
        {
            this.context = context;
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
            context.Logger().Log($"Capacity is now at {capacity}");
        }
    }
}