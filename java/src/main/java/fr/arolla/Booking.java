package fr.arolla;

public class Booking {

  private int numSeats;

  public void book(int numSeats) {
    this.numSeats = numSeats;
    System.out.format("Booking %d seats", numSeats);
  }

  public int lastBookingRequest() {
    return this.numSeats;
  }
}
