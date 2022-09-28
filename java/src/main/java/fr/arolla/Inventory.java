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
    if (message instanceof BookingRequested bookingRequested) {
      var numSeats = bookingRequested.numSeats();
      var user = bookingRequested.user();
      try {
        decrementCapacity(numSeats);
        bus.emit(new CapacityUpdated(capacity, numSeats, user));
      } catch (OverBookedException e) {
        bus.emit(new CapacityExceeded(user));
      }
    }
  }
}
