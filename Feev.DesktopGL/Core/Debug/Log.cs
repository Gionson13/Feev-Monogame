using System;

namespace Feev.DesktopGL.Debug
{
    public static class Log
    {
        public static void Print(object message)
        {
            Console.WriteLine($"[{DateTime.Now}]: {message}");
        }

        public static void Info(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{DateTime.Now}]: {message}");
            Console.ResetColor();
        }

        public static void Warning(object message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now}]: {message}");
            Console.ResetColor();
        }

        public static void Error(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now}]: {message}");
            Console.ResetColor();
        }
    }
}
