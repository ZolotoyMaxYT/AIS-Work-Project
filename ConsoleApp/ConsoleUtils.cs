using System.Text.RegularExpressions;
using BussinesLogic;

namespace ConsoleApp
{
    internal static class ConsoleUtils
    {
        // Main
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

        // Utilities
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

        // Prints
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
        public static void PrintMod(Dictionary<string, object> mod)
        {
            Console.WriteLine( "+---------------------");
            if ((ModStatus)mod["Status"] == ModStatus.Banned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"| BANNED [{mod["Id"]}] {mod["Name"]}");
                Console.ForegroundColor = ConsoleColor.White;
            }   
            else Console.WriteLine($"| [{mod["Id"]}] {mod["Name"]}");
            Console.WriteLine( "+-+-------------------");
            Print((string)mod["Description"]);
            Console.WriteLine( "+-+-------------------");
            Console.WriteLine($"|-[Author]: {mod["Author"]}");
            Console.WriteLine($"|-[Version]: {mod["Version"]}");
            Console.WriteLine($"|-[Minecraft Version]: {mod["MinecraftVersion"]}");
            Console.WriteLine($"|-[Type]: {GetString((bool)mod["IsJavaMod"], "Java mod", "Bedrock mod")}");
            Console.WriteLine($"|-[Rank]: {mod["Rank"]}");
            Console.WriteLine( "+-+-------------------");
            Console.WriteLine( "| Tags");
            Console.WriteLine( "+-+-------------------");
            Print((List<string>)mod["Tags"]);
            Console.WriteLine($"+---------------------");
        }
        public static void PrintMods(ModDatabase db, string[] mods, EntityVersion minecraftVersion)
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
                    if (db.GetStringMod(mods[i], out string result) == IsNotExistResult.Successful)
                    {
                        db.IsCorrectForMinecraftVersion(mods[i], minecraftVersion, out bool res);
                        if (res) Console.ForegroundColor = ConsoleColor.White;
                        else Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($" * {result}");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------");
        }

        // Inputs
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
        public static EntityVersion InputVersion()
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
                                    return new EntityVersion(TypeVersion.Release, a, b, c);
                                case "b":
                                case "beta":
                                    return new EntityVersion(TypeVersion.Beta, a, b, c);
                                case "a":
                                case "alpha":
                                    return new EntityVersion(TypeVersion.Alpha, a, b, c);
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
        public static EntityVersion? InputVersionOrNull()
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
                                    return new EntityVersion(TypeVersion.Release, a, b, c);
                                case "b":
                                case "beta":
                                    return new EntityVersion(TypeVersion.Beta, a, b, c);
                                case "a":
                                case "alpha":
                                    return new EntityVersion(TypeVersion.Alpha, a, b, c);
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
            return InputVersionOrNull();
        }
        public static string InputExistIDOrEmptyString(ModDatabase db)
        {
            Console.WriteLine(" ---[ (string) ID or empty string ]---");
            string id;
            while (true)
            {
                id = ConsoleUtils.InputString();
                if (id == "")
                {
                    break;
                }
                if (!db.IsCorrectID(id))
                {
                    ConsoleUtils.Warn($"Incorrect id \"{id}\"!");
                    continue;
                }
                if (!db.IsExist(id))
                {
                    ConsoleUtils.Warn($"Mod with id \"{id}\" is not exist!");
                    continue;
                }
                break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---------------------\n");
            return id;
        }
    }
}
