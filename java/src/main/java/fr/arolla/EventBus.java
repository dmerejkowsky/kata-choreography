package fr.arolla;

import java.util.ArrayList;
import java.util.List;

public class EventBus {
  private final List<Listener> listeners;

  public EventBus() {
    listeners = new ArrayList<>();
  }

  public void subscribe(Listener listener) {
    listeners.add(listener);
  }

  public void emit(Object message) {
    for (var listener : listeners) {
      listener.onMessage(message);
    }
  }
}
