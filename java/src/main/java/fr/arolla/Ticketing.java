package fr.arolla;

public class Ticketing {
  private final EventBus bus;
  private int numberOfSeatsInLastPrint;

  public Ticketing(EventBus bus) {
    this.bus = bus;
  }

  public void printTicket(int numSeats) {
    System.out.format("Printing ticket for %d seats\n", numSeats);
    numberOfSeatsInLastPrint = numSeats;
    bus.emit(new TicketPrinted(numSeats));
  }

  public String getLastTicket() {
    return String.format("Ticket for %d seats", numberOfSeatsInLastPrint);
  }

}
