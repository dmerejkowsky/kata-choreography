using System;
namespace Choreography {

    public class Booking {
        private readonly Context context;

        public Booking(Context context)
        {
            this.context = context;
        }

        public void Book(int numSeats)
        {
            context.Logger().Log($"Booking {numSeats} seats");
        }
    }
}