package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class TicketingTests {
  private EventBus bus;
  private Spy spy;

  @BeforeEach
  void setUp() {
    bus = new EventBus();
  }

  @Test
  void canPrintTickets() {
    var ticketing = new Ticketing(bus);
    ticketing.printTicket(4);
  }
}
