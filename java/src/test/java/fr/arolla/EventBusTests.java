package fr.arolla;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class EventBusTests {
  @Test
  void canCreateAnEventBus() {
    var bus = new EventBus();
  }

  @Test
  void canAddListeners() {
    var bus = new EventBus();
    var listener = new Spy();
    bus.subscribe(listener);

    bus.emit(42);
    bus.emit("foo");

    assertEquals(2, listener.getMessages().size());
  }

}
