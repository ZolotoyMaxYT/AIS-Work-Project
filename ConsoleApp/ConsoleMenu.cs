namespace ConsoleApp
{
    /// <summary>
    /// Console menu for console project
    /// </summary>
    public class ConsoleMenu
    {
        /// <summary>
        /// Array of options
        /// </summary>
        public ConsoleMenuOption[] Options;
        /// <summary>
        /// Index of selected option
        /// </summary>
        public int Index = 0;
        /// <summary>
        /// Event calling every time on start in Print()
        /// </summary>
        public ConsoleMenuAction? OnStartPrint = null;
        /// <summary>
        /// Event calling every time on end in Print()
        /// </summary>
        public ConsoleMenuAction? OnEndPrint = null;

        public ConsoleMenu(params ConsoleMenuOption[] options)
        {
            Options = options;
        }

        /// <summary>
        /// Update selected index of menu
        /// </summary>
        /// <returns>true if index is changed, else false</returns>
        private bool UpdateIndex()
        {
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Index = Math.Max(0, Index - 1);
                    Thread.Sleep(100);
                    return true;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Index = Math.Min(Options.Length - 1, Index + 1);
                    Thread.Sleep(100);
                    return true;
                }
                if (key.Key == ConsoleKey.Enter) 
                {
                    Console.Clear();
                    Options[Index].Action?.Invoke();
                    return true; 
                }
                return false;
            }
        }
        
        /// <summary>
        /// Print Menu in console
        /// </summary>
        public void Print()
        {
            OnStartPrint?.Invoke();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Options.Length; i++)
            {
                if (Index == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" > ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Options[i].Title);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($" * {Options[i].Title}");
                }
            }
            OnEndPrint?.Invoke();
        }

        /// <summary>
        /// Main Logic Console Menu. Call this every times in loop
        /// </summary>
        public void Update()
        {
            if (UpdateIndex())
            {
                Console.Clear();
                Print();
            }
        }
    }
}
