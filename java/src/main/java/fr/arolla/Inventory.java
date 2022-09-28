package fr.arolla;

public class Inventory {
  private final EventBus bus;
  private int capacity;

  public Inventory(EventBus bus, int totalSeats) {
    this.bus = bus;
    capacity = totalSeats;
  }

  public void decrementCapacity(int numSeats) {
    if (numSeats > capacity) {
      bus.emit(new CapacityExceeded());
      throw new OverBookedException();
    }

    capacity -= numSeats;
    System.out.format("Capacity now at %d\n", capacity);
    bus.emit(new CapacityUpdated(capacity));
  }

  public int getCapacity() {
    return capacity;
  }
}
