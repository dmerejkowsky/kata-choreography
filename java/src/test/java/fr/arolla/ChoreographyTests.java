package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class ChoreographyTests {
  private final int totalSeats = 100;
  private EventBus bus;
  private Ticketing ticketing;
  private Booking booking;
  private Inventory inventory;


  @BeforeEach
  void setUp() {
    bus = new EventBus();
    this.ticketing = new Ticketing(bus);
    this.inventory = new Inventory(bus, totalSeats);
    this.booking = new Booking(bus);
  }

  @Test
  void whenBookingTicketsInventoryIsUpdatedAndTicketsArePrinted() {
    booking.book(4);
    assertEquals(4, booking.lastBookingRequest());
    assertEquals(96, inventory.getCapacity());
    assertEquals("Ticket for 4 seats", ticketing.getLastTicket());
  }
}
