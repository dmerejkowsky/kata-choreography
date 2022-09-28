package fr.arolla;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BookingTests {
  @Test
  void canBookSomeSeats() {
    int totalSeats = 100;
    var inventory = new Inventory(totalSeats);
    var ticketing = new Ticketing();
    var booking = new Booking(inventory, ticketing);
    booking.book(4);

    assertEquals(96, inventory.getCapacity());
  }
}
