package fr.arolla;

public class Ticketing implements Listener {
  private final EventBus bus;
  private Integer numberOfSeatsInLastPrint;

  public Ticketing(EventBus bus) {
    this.bus = bus;
    bus.subscribe(this);
  }

  public void printTicket(int numSeats) {
    System.out.format("Printing ticket for %d seats\n", numSeats);
    numberOfSeatsInLastPrint = numSeats;
    bus.emit(new TicketPrinted(numSeats));
  }

  public String getLastTicket() {
    return String.format("Ticket for %d seats", numberOfSeatsInLastPrint);
  }

  @Override
  public void onMessage(Object message) {
    if (message instanceof CapacityUpdated capacityUpdated) {
      printTicket(capacityUpdated.booked());
    }
  }
}
