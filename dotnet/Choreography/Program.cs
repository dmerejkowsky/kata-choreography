namespace Choreography
{
    public class Program
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var booking = new Booking(logger);
            booking.Book(4);
        }
    }
}
