using Xunit;

namespace DotnetStarter.Logic.Tests
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