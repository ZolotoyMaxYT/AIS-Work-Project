using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class ConsoleMenu
    {
        public string[] Options;
        public int Index = 0;

        public ConsoleMenu(string[] options)
        {
            Options = options;
        }

        public bool Update(out int index)
        {
            index = Index;
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Index = Math.Max(0, Index - 1);
                    Thread.Sleep(100);
                    return false;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Index = Math.Min(Options.Length - 1, Index + 1);
                    Thread.Sleep(100);
                    return false;
                }
                if (key.Key == ConsoleKey.Enter) return true;
            }
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Options.Length; i++)
            {
                if (Index == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" > ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Options[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($" * {Options[i]}");
                }
            }
        }
    }
}
