package fr.arolla;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class InventoryTests {
  private EventBus bus;
  private Spy spy;

  @BeforeEach
  void setUp() {
    bus = new EventBus();
    spy = new Spy();
    bus.subscribe(spy);
  }

  @Test
  void decrementCapacityIfThereAreSomeSeatsLeft() {
    int totalSeats = 100;
    var inventory = new Inventory(bus, totalSeats);
    var spy = new Spy();
    bus.subscribe(spy);

    inventory.decrementCapacity(10);

    assertEquals(90, inventory.getCapacity());
  }

  @Test
  void throwWhenOverbooked() {
    int totalSeats = 12;
    var inventory = new Inventory(bus, totalSeats);

    assertThrows(OverBookedException.class, () -> inventory.decrementCapacity(14));
  }
}
