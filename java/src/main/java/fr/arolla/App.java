package fr.arolla;


import java.util.Objects;

public class App {
  public static void main(String[] args) {
    var bus = new EventBus();
    var booking = new Booking(bus);
    var ticketing = new Ticketing(bus);
    var totalSeats = 100;
    var inventory = new Inventory(bus, totalSeats);
    if (args.length == 1 && Objects.equals(args[0], "--with-notifier")) {
      var notifier = new Notifier(bus);
    }

    booking.book(new BookingRequest(4, "Alex"));
  }
}
