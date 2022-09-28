package fr.arolla;

import org.junit.jupiter.api.Test;

public class TicketingTests {
  @Test
  void canPrintTickets() {
    var ticketing = new Ticketing();
    ticketing.printTicket(4);

  }
}
