using System.Text.RegularExpressions;
using BussinesLogic;

namespace ConsoleApp
{
    internal class ConsoleMenu
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
    internal static class ConsoleUtils
    {
        public static string GetString(bool condition, string ifTrue, string ifFalse)
        {
            return condition ? ifTrue : ifFalse;
        }
        public static string? NullOrString(string str)
        {
            return str == null || str.Length == 0 || str.IsWhiteSpace() ? null : str;
        }
        public static List<string> StringList(List<string> l)
        {
            if (l.Count == 1 && (l[0].Length == 0 || l[0].IsWhiteSpace())) l.Clear();
            return l;
        }


        public static void Print(string lines)
        {
            if (lines.IsWhiteSpace())
            {
                Console.WriteLine("| | EMPTY");
            }
            else
            {
                foreach (var line in lines.Split('\n'))
                {
                    Console.WriteLine($"| | {line}");
                }
            }
        }
        public static void Print(List<string> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("| | EMPTY");
            }
            else
            {
                foreach (var line in list)
                {
                    Console.WriteLine($"| | {line}");
                }
            }
        }

        public static void Print(MinecraftMod mod)
        {
            Console.WriteLine( "+---------------------");
            Console.WriteLine($"| [{mod.Id}] {mod.Name}");
            Console.WriteLine( "+-+-------------------");
            Print(mod.Description);
            Console.WriteLine( "+-+-------------------");
            Console.WriteLine($"|-[Author]: {mod.Author}");
            Console.WriteLine($"|-[Version]: {mod.Version}");
            Console.WriteLine($"|-[Type]: {GetString(mod.IsJavaMod, "Java mod", "Bedrock mod")}");
            Console.WriteLine($"|-[Rank]: {mod.Rank}");
            Console.WriteLine( "+-+-------------------");
            Console.WriteLine( "| ModPacks");
            Console.WriteLine( "+-+-------------------");
            Print(mod.ModPacks);
            Console.WriteLine($"+---------------------");
        }
        public static void Print(MinecraftMod[] mods)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---[ LIST OF MODS ]---");
            if (mods.Length == 0)
            {
                Console.WriteLine($" EMPTY");
            }
            else
            {
                for (int i = 0; i < mods.Length; i++)
                {
                    Console.WriteLine($" * {mods[i]}");
                }
            }
            Console.WriteLine("----------------------");
        }

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

        public static string InputString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INPUT]: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return Console.ReadLine() ?? InputString();
        }
        public static string? InputStringOrNull()
        {
            return NullOrString(InputString());
        }
        public static int InputInt()
        {
            while (true)
            {
                if (int.TryParse(InputString(), out int result))
                {
                    return result;
                }
                Error("This is not a number!");
            }
        }
        public static int? InputIntOrNull()
        {
            string value;
            while (true)
            {
                value = InputString();
                if (value.Length == 0 || value.IsWhiteSpace()) return null;
                if (int.TryParse(value, out int result))
                {
                    return result;
                }
                Error("This is not a number!");
            }
        }
        public static bool InputBool()
        {
            while (true)
            {
                switch (InputString().ToLower())
                {
                    case "true":
                    case "yes":
                    case "y":
                    case "1":
                        return true;
                    case "false":
                    case "no":
                    case "n":
                    case "0":
                        return false;
                }
                Error("Incorrect data (true|yes|y|1 or false|no|n|0)!");
            }
        }
        public static bool? InputBoolOrNull()
        {
            string value;
            while (true)
            {
                value = InputString();
                if (value.Length == 0 || value.IsWhiteSpace()) return null;
                switch (value.ToLower())
                {
                    case "true":
                    case "yes":
                    case "y":
                    case "1":
                        return true;
                    case "false":
                    case "no":
                    case "n":
                    case "0":
                        return false;
                }
                Error("Incorrect data (true|yes|y|1 or false|no|n|0)!");
            }
        }
        public static string InputText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[INPUT]:");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string text = "";
            string? line;
            while (true)
            {
                line = Console.ReadLine();
                if (line is null || line.Length == 0 || line.IsWhiteSpace())
                {
                    if (text.Length == 0 || text.IsWhiteSpace())
                    {
                        return "";
                    }
                    else
                    {
                        return text.Substring(0, text.Length - 1);
                    }
                }
                text += line + "\n";
            }
        }
        public static string? InputTextOrNull()
        {
            return NullOrString(InputText());
        }
        public static ModVersion InputVersion()
        {
            // [v]1.0.0[(]{alpha|a, beta|b, release|r}[)]
            // v1.0.0 (alpha)
            // v1.0.0 beta
            // 1.0.0a
            string text = InputString().ToLower().Replace(" ", "").Replace("(", "").Replace(")", "");
            if (text[0] == 'v') text = text.Substring(1);
            string[] args = text.Split('.');
            if (args.Length == 3 && int.TryParse(args[0], out int a) && int.TryParse(args[1], out int b))
            {
                text = "";
                var regex = new Regex(@"[^0-9]");
                for (int i = 0; i < args[2].Length; i++)
                {
                    text += args[2][i];
                    if (regex.Match(text).Success)
                    {
                        if (int.TryParse(text.Substring(0, text.Length - 1), out int c))
                        {
                            text = args[2].Substring(text.Length - 1);
                            switch (text)
                            {
                                case "r":
                                case "release":
                                    return new ModVersion(TypeVersion.Release, a, b, c);
                                case "b":
                                case "beta":
                                    return new ModVersion(TypeVersion.Beta, a, b, c);
                                case "a":
                                case "alpha":
                                    return new ModVersion(TypeVersion.Alpha, a, b, c);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Error("Incorrect data!\n * 1.0.0r, 1.0.0release -> v1.0.0 (release)\n * 1.0.0a, 1.0.0alpha -> v1.0.0 (alpha)\n * 1.0.0b, 1.0.0beta -> v1.0.0 (beta)\n");
            return InputVersion();
        }
        public static ModVersion? InputVersionOrNull()
        {
            string text = InputString();
            if (text.Length == 0 || text.IsWhiteSpace()) return null;
            text = text.ToLower().Replace(" ", "").Replace("(", "").Replace(")", "");
            if (text[0] == 'v') text = text.Substring(1);
            string[] args = text.Split('.');
            if (args.Length == 3 && int.TryParse(args[0], out int a) && int.TryParse(args[1], out int b))
            {
                text = "";
                var regex = new Regex(@"[^0-9]");
                for (int i = 0; i < args[2].Length; i++)
                {
                    text += args[2][i];
                    if (regex.Match(text).Success)
                    {
                        if (int.TryParse(text.Substring(0, text.Length - 1), out int c))
                        {
                            text = args[2].Substring(text.Length - 1);
                            switch (text)
                            {
                                case "r":
                                case "release":
                                    return new ModVersion(TypeVersion.Release, a, b, c);
                                case "b":
                                case "beta":
                                    return new ModVersion(TypeVersion.Beta, a, b, c);
                                case "a":
                                case "alpha":
                                    return new ModVersion(TypeVersion.Alpha, a, b, c);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Error("Incorrect data!\n * 1.0.0r, 1.0.0release -> v1.0.0 (release)\n * 1.0.0a, 1.0.0alpha -> v1.0.0 (alpha)\n * 1.0.0b, 1.0.0beta -> v1.0.0 (beta)\n");
            return InputVersion();
        }

    }
}
