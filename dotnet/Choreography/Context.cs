namespace Choreography
{
    public class Context
    {
        private readonly ILogger logger;
        private readonly EventBus bus;

        public Context(ILogger logger, EventBus bus)
        {
            this.logger = logger;
            this.bus = bus;
        }

        public EventBus Bus() => bus;
        public ILogger Logger() => logger;
    }
}
