using System.Collections.Generic;

namespace Choreography.Tests
{
    public class SpyLogger : ILogger
    {
        private readonly List<string> messages;

        public List<string> Messages() => messages;

        public SpyLogger()
        {
            messages = new List<string>();
        }

        public void Log(string message)
        {
            messages.Add(message);
        }
    }
}