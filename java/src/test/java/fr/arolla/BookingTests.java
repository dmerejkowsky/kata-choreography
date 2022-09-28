package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BookingTests {
  private EventBus bus;

  @BeforeEach
  void setUp() {
    bus = new EventBus();
  }

  @Test
  void canBookSomeSeats() {
    var booking = new Booking(bus);
    var spy = new Spy();
    bus.subscribe(spy);
    var request = new BookingRequest(4, "Alex");
    booking.book(request);

    var lastMessage = spy.lastMessage();
    var bookingRequested = (BookingRequested) lastMessage;
    assertEquals(4, bookingRequested.numSeats());
    assertEquals("Alex", bookingRequested.user());

  }
}
