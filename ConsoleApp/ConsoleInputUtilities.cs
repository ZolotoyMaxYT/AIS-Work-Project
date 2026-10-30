using Model;
using BussinesLogic;

namespace ConsoleApp
{
    public static class ConsoleInputUtilities
    {
        public static string InputString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[INPUT]: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return Console.ReadLine() ?? InputString();
        }
        public static string? InputStringOrNull()
        {
            return StringUtilities.NullOrString(InputString());
        }
        public static int InputInt()
        {
            while (true)
            {
                if (int.TryParse(InputString(), out int result))
                {
                    return result;
                }
                ConsoleLogger.Error("This is not a number!");
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
                ConsoleLogger.Error("This is not a number!");
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
                ConsoleLogger.Error("Incorrect data (true|yes|y|1 or false|no|n|0)!");
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
                ConsoleLogger.Error("Incorrect data (true|yes|y|1 or false|no|n|0)!");
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
            return StringUtilities.NullOrString(InputText());
        }
        public static EntityVersion InputVersion()
        {
            if (EntityVersion.TryParse(InputString(), out EntityVersion version))
            {
                return version;
            }
            ConsoleLogger.Error("Incorrect data!\n * 1.0.0r, 1.0.0release -> v1.0.0 (release)\n * 1.0.0a, 1.0.0alpha -> v1.0.0 (alpha)\n * 1.0.0b, 1.0.0beta -> v1.0.0 (beta)\n");
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
            ConsoleLogger.Error("Incorrect data!\n * 1.0.0r, 1.0.0release -> v1.0.0 (release)\n * 1.0.0a, 1.0.0alpha -> v1.0.0 (alpha)\n * 1.0.0b, 1.0.0beta -> v1.0.0 (beta)\n");
            return InputVersionOrNull();
        }
        public static string InputExistIDOrEmptyString(ModDatabase db)
        {
            Console.WriteLine(" ---[ (string) ID or empty string ]---");
            string id;
            while (true)
            {
                id = InputString();
                if (id == "")
                {
                    break;
                }
                if (!db.IsCorrectID(id))
                {
                    ConsoleLogger.Warn($"Incorrect id \"{id}\"!");
                    continue;
                }
                if (!db.IsExist(id))
                {
                    ConsoleLogger.Warn($"Mod with id \"{id}\" is not exist!");
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
