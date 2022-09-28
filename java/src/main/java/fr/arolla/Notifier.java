package fr.arolla;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Notifier {
  private final Map<String, List<String>> sentMessages;

  public Notifier() {
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
}
