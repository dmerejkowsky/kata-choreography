package fr.arolla;

import java.util.ArrayList;
import java.util.List;

public class Spy implements Listener {
  private final List<Object> caughtMessages;

  public Spy() {
    caughtMessages = new ArrayList<>();
  }

  public void onMessage(Object message) {
    caughtMessages.add(message);
  }

  public List<String> getMessages() {
    return caughtMessages.stream().map(o -> o.toString()).toList();
  }
}
