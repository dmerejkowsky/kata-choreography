package fr.arolla;


public class App {
  public static void main(String[] args) {
    var booking = new Booking();
    var ticketing = new Ticketing();
    var totalSeats = 100;
    var inventory = new Inventory(totalSeats);
    var notifier = new Notifier();
    var orchestrator = new Orchestrator(booking, inventory, ticketing, notifier);
    var request = new BookingRequest(4, "Alex");
    orchestrator.orchestrate(request);
  }
}
