package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class TicketingTests {
  private EventBus bus;
  private Spy spy;

  @BeforeEach
  void setUp() {
    bus = new EventBus();
    spy = new Spy();
    bus.subscribe(spy);
  }

  @Test
  void canPrintTickets() {
    var ticketing = new Ticketing(bus);
    ticketing.printTicket(4);

    TicketPrinted message = (TicketPrinted) spy.lastMessage();
    assertEquals(4, message.numSeats());
  }
}
