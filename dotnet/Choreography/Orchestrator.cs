namespace Choreography
{


    public class Orchestrator
    {
        private readonly Booking booking;
        private readonly Inventory inventory;
        private readonly Ticketing ticketing;

        public Orchestrator(Booking booking, Inventory inventory, Ticketing ticketing)
        {
            this.booking = booking;
            this.inventory = inventory;
            this.ticketing = ticketing;
        }

        public void Book(int numSeats)
        {
            booking.Book(numSeats);
            inventory.DecrementCapacity(numSeats);
            ticketing.PrintTickets(numSeats);
        }
    }
}
