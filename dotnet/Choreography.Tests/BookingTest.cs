using Xunit;
using Choreography;

namespace Choreography.Tests
{
    public class BookingTest
    {
        [Fact]
        public void CanBook() {
            var booking = new Booking();
            booking.Book(4);
        }
    }
}