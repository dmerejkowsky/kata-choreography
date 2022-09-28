package fr.arolla;

import java.util.ArrayList;
import java.util.List;

public class Spy implements Listener {
  private final ArrayList<Object> caughtMessages;

  public Spy() {
    caughtMessages = new ArrayList<>();
  }

  public void onMessage(Object message) {
    caughtMessages.add(message);
  }

  public List<String> getMessages() {
    return caughtMessages.stream().map(o -> o.toString()).toList();
  }

  public Object lastMessage() {
    int n = caughtMessages.size();
    if (n == 0) {
      throw new RuntimeException("No messages were caught");
    }
    return caughtMessages.get(n - 1);
  }
}
