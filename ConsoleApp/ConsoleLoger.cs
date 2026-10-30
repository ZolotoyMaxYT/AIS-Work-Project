
namespace ConsoleApp
{
    public static class ConsoleLogger
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR]: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
        }
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[WARN]: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
        }
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[INFO]: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
        }
    }
}
