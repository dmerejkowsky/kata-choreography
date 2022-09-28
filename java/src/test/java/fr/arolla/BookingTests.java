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
    booking.book(4);

    var lastMessage = spy.lastMessage();
    var bookRequest = (BookRequest) lastMessage;
    assertEquals(4, bookRequest.numSeats());

  }
}
