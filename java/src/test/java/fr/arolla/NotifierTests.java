package fr.arolla;

import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class NotifierTests {
  @Test
  void canNotify() {
    var bus = new EventBus();
    var notifier = new Notifier(bus);
    var message = "This is a message";
    var user = "Alex";

    notifier.notifyUser(user, message);

    var sent = notifier.messagesFor(user);
    assertEquals(List.of(message), sent);
  }
}
