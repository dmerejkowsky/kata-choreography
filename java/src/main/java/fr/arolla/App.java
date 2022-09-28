package fr.arolla;


public class App {
  public static void main(String[] args) {
    var bus = new EventBus();
    var booking = new Booking(bus);
    var ticketing = new Ticketing(bus);
    var totalSeats = 100;
    var inventory = new Inventory(bus, totalSeats);
    booking.book(new BookingRequest(4, "Alex"));
  }
}
