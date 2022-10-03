using System;
namespace Choreography {
    public class Booking {
        public void Book(int numSeats) {
            int totalSeats = 100;
            Console.WriteLine($"Booking {numSeats} seats");
            var inventory = new Inventory(totalSeats);
            inventory.DecrementCapacity(numSeats);
            var ticketing = new Ticketing();
            ticketing.PrintTickets(numSeats);
        }

    }
}