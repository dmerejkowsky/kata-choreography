package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class OrchestratorTests {
  private final int totalSeats = 100;
  private Ticketing ticketing;
  private Booking booking;
  private Inventory inventory;
  private Orchestrator orchestrator;

  @BeforeEach
  void setUp() {
    this.ticketing = new Ticketing();
    this.inventory = new Inventory(totalSeats);
    this.booking = new Booking();
    this.orchestrator = new Orchestrator(booking, inventory, ticketing);
  }

  @Test
  void whenBookingTicketsInventoryIsUpdatedAndTicketsArePrinted() {
    orchestrator.orchestrate(4);
    assertEquals(4, booking.lastBookingRequest());
    assertEquals(96, inventory.getCapacity());
    assertEquals("Ticket for 4 seats", ticketing.getLastTicket());
  }
}
