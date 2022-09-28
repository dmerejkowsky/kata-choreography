package fr.arolla;

public class Inventory {
  private int capacity;

  public Inventory(int totalSeats) {
    capacity = totalSeats;
  }

  public void decrementCapacity(int numSeats) {
    if (numSeats > capacity) {
      throw new OverBookedException();
    }

    capacity -= numSeats;
    System.out.format("Capacity now at %d\n", capacity);
  }

  public int getCapacity() {
    return capacity;
  }
}
