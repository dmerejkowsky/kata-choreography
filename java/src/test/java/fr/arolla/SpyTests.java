package fr.arolla;

import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class SpyTests {
  @Test
  void canSpyOnMessages() {
    var spy = new Spy();
    spy.onMessage(42);
    spy.onMessage("Foo");

    var caught = spy.getMessages();
    assertEquals(List.of("42", "Foo"), caught);
  }
}
