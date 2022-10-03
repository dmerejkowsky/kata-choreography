using System;

namespace Choreography
{
    public class Ticketing
    {
        private readonly Context context;

        public Ticketing(Context context)
        {
            this.context = context;
        }

        public void PrintTickets(int numSeats)
        {
            context.Logger().Log($"Printing tickets for {numSeats} seats");
        }
    }
}