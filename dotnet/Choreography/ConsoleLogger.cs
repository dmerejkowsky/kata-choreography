using System;

namespace Choreography;

internal class ConsoleLogger : ILogger

{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}