package fr.arolla;

public class Booking {
  private final EventBus bus;
  private int numSeats;

  public Booking(EventBus bus) {
    this.bus = bus;
  }

  public void book(int numSeats) {
    this.numSeats = numSeats;
    System.out.format("Booking %d seats\n", numSeats);
    bus.emit(new BookingRequested(numSeats));
  }

  public int lastBookingRequest() {
    return this.numSeats;
  }
}
