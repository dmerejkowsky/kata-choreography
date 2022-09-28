package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class OrchestratorTests {
  private final int totalSeats = 100;
  private Ticketing ticketing;
  private Booking booking;
  private Inventory inventory;

  private Notifier notifier;

  private Orchestrator orchestrator;

  @BeforeEach
  void setUp() {
    this.ticketing = new Ticketing();
    this.inventory = new Inventory(totalSeats);
    this.booking = new Booking();
    this.notifier = new Notifier();
    this.orchestrator = new Orchestrator(booking, inventory, ticketing, notifier);
  }

  @Test
  void whenBookingTicketsInventoryIsUpdatedTicketsArePrintedAndUserIsNotified() {
    var request = new BookingRequest(4, "Alex");

    orchestrator.orchestrate(request);

    assertEquals(4, booking.lastBookingRequest());
    assertEquals(96, inventory.getCapacity());
    assertEquals("Ticket for 4 seats", ticketing.getLastTicket());
    assertEquals(List.of("Your tickets are ready"), notifier.messagesFor("Alex"));
  }

  @Test
  void whenOverBookedUserIsNotified() {
    var request = new BookingRequest(103, "Alex");

    orchestrator.orchestrate(request);

    assertEquals(103, booking.lastBookingRequest());
    assertEquals(100, inventory.getCapacity());
    assertEquals(List.of("Event is at full capacity"), notifier.messagesFor("Alex"));

  }
}
