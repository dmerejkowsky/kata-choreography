using Xunit;
using System;
using System.Collections.Generic;

namespace Choreography.Tests
{
    public class BookingTest
    {
        [Fact]
        public void CanBookWhenEnoughRoom() {
            var logger = new SpyLogger();
            var booking = new Booking(logger);

            booking.Book(4);

            var loggedMessages = logger.Messages();
            var expected = new List<string> { "Booking 4 seats", "Capacity is now at 96", "Printing tickets for 4 seats" };
            Assert.Equal(expected, loggedMessages);
        }

        [Fact]
        public void DoNotPrintTicketsWhenNotEnoughRoom()
        {
            var logger = new SpyLogger();
            var booking = new Booking(logger);

            Assert.Throws<OverbookedException>(() => booking.Book(104));
        }
    }
}