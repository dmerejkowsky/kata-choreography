package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class OrchestratorTests {
  private final int totalSeats = 100;
  private EventBus bus;
  private Ticketing ticketing;
  private Booking booking;
  private Inventory inventory;
  private Orchestrator orchestrator;

  @BeforeEach
  void setUp() {
    bus = new EventBus();
    this.ticketing = new Ticketing(bus);
    this.inventory = new Inventory(bus, totalSeats);
    this.booking = new Booking(bus);
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
