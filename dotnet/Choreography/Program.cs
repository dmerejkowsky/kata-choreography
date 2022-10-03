﻿namespace Choreography
{
    public class Program
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var bus = new EventBus();
            var context = new Context(logger, bus);
            var booking = new Booking(context);
            var inventory = new Inventory(context, 100);
            var ticketing = new Ticketing(context);
            booking.Book(4);
        }
    }
}
