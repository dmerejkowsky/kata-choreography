package fr.arolla;


public class App {
  public static void main(String[] args) {
    var booking = new Booking();
    var ticketing = new Ticketing();
    var totalSeats = 100;
    var inventory = new Inventory(totalSeats);
    var orchestrator = new Orchestrator(booking, inventory, ticketing);
    orchestrator.orchestrate(4);
  }
}
