package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class ChoreographyTests {
  private final int totalSeats = 100;
  private EventBus bus;
  private Ticketing ticketing;
  private Booking booking;
  private Inventory inventory;
  private Notifier notifier;


  @BeforeEach
  void setUp() {
    bus = new EventBus();
    this.ticketing = new Ticketing(bus);
    this.inventory = new Inventory(bus, totalSeats);
    this.booking = new Booking(bus);
    this.notifier = new Notifier(bus);
  }

  @Test
  void whenBookingTicketsInventoryIsUpdatedAndTicketsArePrinted() {
    var bookingRequest = new BookingRequest(4, "Alex");
    booking.book(bookingRequest);
    assertEquals(4, booking.lastBookingRequest());
    assertEquals(96, inventory.getCapacity());
    assertEquals("Ticket for 4 seats", ticketing.getLastTicket());
    assertEquals(List.of("Your tickets have been printed"), notifier.messagesFor("Alex"));
  }

  @Test
  void userIsNotifiedWhenEventIsOverbooked() {
    var bookingRequest = new BookingRequest(103, "Alex");
    booking.book(bookingRequest);
    assertEquals(100, inventory.getCapacity());
    assertEquals(List.of("Event is fully booked"), notifier.messagesFor("Alex"));
  }

}
