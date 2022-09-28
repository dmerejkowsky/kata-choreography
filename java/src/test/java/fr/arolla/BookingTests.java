package fr.arolla;

import org.junit.jupiter.api.Test;

public class BookingTests {
  @Test
  void canBookSomeSeats() {
    var booking = new Booking();
    booking.book(4);
  }
}
