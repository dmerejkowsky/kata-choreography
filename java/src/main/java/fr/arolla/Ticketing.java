package fr.arolla;

public class Ticketing {
  private int numberOfSeatsInLastPrint;

  public void printTicket(int numberOfSeats) {
    System.out.format("Printing ticket for %d seats\n", numberOfSeats);
    numberOfSeatsInLastPrint = numberOfSeats;
  }

  public String getLastTicket() {
    return String.format("Ticket for %d seats", numberOfSeatsInLastPrint);
  }

}
