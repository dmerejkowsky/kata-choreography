using Choreography.Events;


namespace Choreography.Events
{
    public record struct DummyEvent(int Value) : IEvent
    {
        public string Display()
        {
            return Value.ToString();

        }
    }
}
