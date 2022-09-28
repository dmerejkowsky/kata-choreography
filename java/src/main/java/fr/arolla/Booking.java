package fr.arolla;

public class Booking {
  private final Inventory inventory;
  private final Ticketing ticketing;

  public Booking(Inventory inventory, Ticketing ticketing) {
    this.inventory = inventory;
    this.ticketing = ticketing;
  }

  public void book(int numSeats) {
    System.out.format("Booking %d seats", numSeats);
    inventory.decrementCapacity(numSeats);
    ticketing.printTicket(numSeats);
  }
}
