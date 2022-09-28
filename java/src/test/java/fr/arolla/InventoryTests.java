package fr.arolla;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class InventoryTests {
  @Test
  void decrementCapacityIfThereAreSomeSeatsLeft() {
    int totalSeats = 100;
    var inventory = new Inventory(totalSeats);

    inventory.decrementCapacity(10);

    assertEquals(90, inventory.getCapacity());
  }

  @Test
  void throwWhenOverbooked() {
    int totalSeats = 12;
    var inventory = new Inventory(totalSeats);

    assertThrows(OverBookedException.class, () -> inventory.decrementCapacity(14));
  }
}
