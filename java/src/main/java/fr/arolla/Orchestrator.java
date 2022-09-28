package fr.arolla;

public class Orchestrator {
  private final Booking booking;

  private final Inventory inventory;
  private final Ticketing ticketing;
  private final Notifier notifier;

  public Orchestrator(Booking booking, Inventory inventory, Ticketing ticketing, Notifier notifier) {
    this.ticketing = ticketing;
    this.inventory = inventory;
    this.booking = booking;
    this.notifier = notifier;
  }

  public void orchestrate(BookingRequest request) {
    int numSeats = request.numSeats();
    String user = request.user();

    booking.book(numSeats);
    inventory.decrementCapacity(numSeats);
    ticketing.printTicket(numSeats);
    notifier.notifyUser(user, "Your tickets are ready");
  }
}
