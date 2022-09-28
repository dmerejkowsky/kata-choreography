package fr.arolla;

public class Orchestrator {
  private final Booking booking;

  private final Inventory inventory;
  private final Ticketing ticketing;

  public Orchestrator(Booking booking, Inventory inventory, Ticketing ticketing) {
    this.ticketing = ticketing;
    this.inventory = inventory;
    this.booking = booking;
  }

  public void orchestrate(int numSeats) {
    booking.book(numSeats);
    inventory.decrementCapacity(numSeats);
    ticketing.printTicket(numSeats);
  }
}
