package fr.arolla;

public class Booking {
  private final EventBus bus;
  private int numSeats;

  public Booking(EventBus bus) {
    this.bus = bus;
  }

  public void book(BookingRequest request) {
    int numSeats = request.numSeats();
    String user = request.user();
    this.numSeats = numSeats;
    System.out.format("Booking %d seats\n", numSeats);
    bus.emit(new BookingRequested(numSeats, user));
  }

  public int lastBookingRequest() {
    return this.numSeats;
  }
}
