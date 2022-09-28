package fr.arolla;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Notifier implements Listener {
  private final Map<String, List<String>> sentMessages;
  private final EventBus bus;

  public Notifier(EventBus bus) {
    this.bus = bus;
    bus.subscribe(this);
    sentMessages = new HashMap<>();
  }

  public void notifyUser(String user, String message) {
    System.out.format("Message for %s : %s\n", user, message);
    if (sentMessages.containsKey(user)) {
      sentMessages.get(user).add(message);
    } else {
      sentMessages.put(user, List.of(message));
    }
  }

  public List<String> messagesFor(String user) {
    return sentMessages.get(user);
  }

  @Override
  public void onMessage(Object message) {
    if (message instanceof TicketPrinted ticketPrinted) {
      var user = ticketPrinted.user();
      notifyUser(user, "Your tickets have been printed");
    }

    if (message instanceof CapacityExceeded capacityExceeded) {
      var user = capacityExceeded.user();
      notifyUser(user, "Event is fully booked");
    }
  }
}
