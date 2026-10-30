using BussinesLogic;
using Model;

namespace ConsoleApp
{
    public static class ConsoleOutputUtilities
    {
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
            Console.WriteLine("+---------------------");
            if ((ModStatus)mod["Status"] == ModStatus.Banned)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"| BANNED [{mod["Id"]}] {mod["Name"]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else Console.WriteLine($"| [{mod["Id"]}] {mod["Name"]}");
            Console.WriteLine("+-+-------------------");
            Print((string)mod["Description"]);
            Console.WriteLine("+-+-------------------");
            Console.WriteLine($"|-[Author]: {mod["Author"]}");
            Console.WriteLine($"|-[Version]: {mod["Version"]}");
            Console.WriteLine($"|-[Minecraft Version]: {mod["MinecraftVersion"]}");
            Console.WriteLine($"|-[Type]: {StringUtilities.GetString((bool)mod["IsJavaMod"], "Java mod", "Bedrock mod")}");
            Console.WriteLine($"|-[Rank]: {mod["Rank"]}");
            Console.WriteLine("+-+-------------------");
            Console.WriteLine("| Tags");
            Console.WriteLine("+-+-------------------");
            Print((string[])mod["Tags"]);
            Console.WriteLine($"+---------------------");
        }
        public static void PrintMods(IBasicModDatabase db, string[] mods, EntityVersion minecraftVersion)
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
                    if (((IModDatabaseStringUtilities)db).GetStringMod(mods[i], out string result) == IsNotExistResult.Successful)
                    {
                        ((IModDatabaseMinecraftVersionManager)db).IsCorrectForMinecraftVersion(mods[i], minecraftVersion, out bool res);
                        if (res) Console.ForegroundColor = ConsoleColor.White;
                        else Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($" * {result}");
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------");
        }
    }
}
