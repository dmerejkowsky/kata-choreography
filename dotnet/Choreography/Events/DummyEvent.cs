namespace Choreography.Events;

public readonly record struct DummyEvent(int Value) : IEvent
{
    public string Display()
    {
        return Value.ToString();
    }
}