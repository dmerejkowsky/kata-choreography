﻿using System;

namespace Choreograhpy
{
    public class Inventory
    {
        private int capacity;

        public Inventory(int totalSeats)
        {
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
        }
    }
}