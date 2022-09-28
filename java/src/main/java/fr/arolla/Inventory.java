package fr.arolla;

public class Inventory implements Listener {
  private final EventBus bus;
  private int capacity;

  public Inventory(EventBus bus, int totalSeats) {
    this.bus = bus;
    this.bus.subscribe(this);
    capacity = totalSeats;
  }

  public void decrementCapacity(int numSeats) {
    if (numSeats > capacity) {
      bus.emit(new CapacityExceeded());
      throw new OverBookedException();
    }

    capacity -= numSeats;
    System.out.format("Capacity now at %d\n", capacity);
  }

  public int getCapacity() {
    return capacity;
  }

  @Override
  public void onMessage(Object message) {
    if (message instanceof BookingRequested br) {
      decrementCapacity(br.numSeats());
      bus.emit(new CapacityUpdated(capacity, br.numSeats(), br.user()));
    }
  }
}
