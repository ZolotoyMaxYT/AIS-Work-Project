using Model;
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
        public static void Print(string[] list)
        {
            if (list.Length == 0)
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
            Print((string[])mod["Tags"]);
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
            if (EntityVersion.TryParse(InputString(), out EntityVersion version))
            {
                return version;
            }
            Error("Incorrect data!\n * 1.0.0r, 1.0.0release -> v1.0.0 (release)\n * 1.0.0a, 1.0.0alpha -> v1.0.0 (alpha)\n * 1.0.0b, 1.0.0beta -> v1.0.0 (beta)\n");
            return InputVersion();
        }
        public static EntityVersion? InputVersionOrNull()
        {
            string text = InputString();
            if (text.Length == 0 || text.IsWhiteSpace()) return null;
            if (EntityVersion.TryParse(text, out EntityVersion version))
            {
                return version;
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
