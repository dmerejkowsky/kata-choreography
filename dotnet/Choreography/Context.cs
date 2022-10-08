namespace Choreography;

public class Context
{
    private readonly EventBus _bus;
    private readonly ILogger _logger;

    public Context(ILogger logger, EventBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    public EventBus Bus()
    {
        return _bus;
    }

    public ILogger Logger()
    {
        return _logger;
    }
}