using System.Collections.Generic;

namespace Choreography.Test;

public class SpyLogger : ILogger
{
    private readonly List<string> _messages;

    public SpyLogger()
    {
        _messages = new List<string>();
    }

    public void Log(string message)
    {
        _messages.Add(message);
    }

    public List<string> Messages()
    {
        return _messages;
    }
}