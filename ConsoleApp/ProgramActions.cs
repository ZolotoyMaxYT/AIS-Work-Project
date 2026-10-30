using BussinesLogic;
using Model;
using Ninject;

namespace ConsoleApp
{
    public static class ProgramActions
    {
        public static ConsoleMenu Menu = new(
            new ConsoleMenuOption("list of mods", PrintListOfMod),
            new ConsoleMenuOption("create", CreateMod),
            new ConsoleMenuOption("read", ReadMod),
            new ConsoleMenuOption("delete", DeleteMod),
            new ConsoleMenuOption("update", UpdateMod),
            new ConsoleMenuOption("add tag", AddTag),
            new ConsoleMenuOption("delete tag", DeleteTag),
            new ConsoleMenuOption("all mods with tag", PrintAllModsWithTags),
            new ConsoleMenuOption("change minecraft version for mod", ChangeMinecraftVersionForMod),
            new ConsoleMenuOption("change minecraft version for user", ChangeMinecraftVersionForUser),
            new ConsoleMenuOption("ban mod", BanMod),
            new ConsoleMenuOption("shadow ban mod", ShadowBanMod)
        );
        public static EntityVersion MinecraftVersion = new(TypeVersion.Release, 1, 7, 10);
        public static IKernel NinjectKernel = new StandardKernel(new SimpleConfigModule());
        public static ModDatabase ModDatabase = NinjectKernel.Get<ModDatabase>();

        public static void MainLoop()
        {
            Menu.OnStartPrint = PrintPreMenu;
            Menu.OnEndPrint = PrintPostMenu;
            Menu.Print();
            while (true)
            {
                Menu.Update();
            }
        }

        public static void PrintPreMenu()
        {
            Console.Clear();
            ConsoleLogger.Info($"Minecraft version: {MinecraftVersion}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----[MENU]------");
        }
        public static void PrintPostMenu()
        {
            Console.WriteLine("-----------------");
        }

        public static void PrintListOfMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void CreateMod()
        {
            Console.WriteLine(" ---[ (string) ID or empty string ]---");
            string id;
            while (true)
            {
                id = ConsoleInputUtilities.InputString();
                if (id == "")
                {
                    break;
                }
                if (!ModDatabase.IsCorrectID(id))
                {
                    ConsoleLogger.Warn($"Incorrect id \"{id}\"!");
                    continue;
                }
                if (ModDatabase.IsExist(id))
                {
                    ConsoleLogger.Warn($"Mod with id \"{id}\" is exist!");
                    continue;
                }
                break;
            }
            if (id == "")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n - Press Enter to continue... ");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (string) NAME ]---");
            var name = ConsoleInputUtilities.InputString();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (list of string) DESCRIPTION ]---");
            var description = ConsoleInputUtilities.InputText();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (string) AUTHOR ]---");
            var author = ConsoleInputUtilities.InputString();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (version) VERSION ]---");
            var version = ConsoleInputUtilities.InputVersion();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (version) FIRST MINECRAFT VERSION ]---");
            var mineVersionA = ConsoleInputUtilities.InputVersion();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (version) LAST MINECRAFT VERSION ]---");
            var mineVersionB = ConsoleInputUtilities.InputVersion();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (bool) IS JAVA? ]---");
            var isJava = ConsoleInputUtilities.InputBool();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (int) RANK ]---");
            var rank = ConsoleInputUtilities.InputInt();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---[ (list of string) LIST OF TAGS ]---");
            var tags = StringUtilities.StringList(ConsoleInputUtilities.InputText().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList());
            ModDatabase.Create(id, name, description, author, version, new(mineVersionA, mineVersionB), isJava, rank, tags);
            ConsoleLogger.Info("Mod is created!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void ReadMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                ModDatabase.Read(id, out var mod);
                ConsoleOutputUtilities.PrintMod(mod);
            }
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void DeleteMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                ModDatabase.Delete(id);
                ConsoleLogger.Info("Mod is removed!");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void UpdateMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                ModDatabase.Read(id, out var mod);
                ConsoleOutputUtilities.PrintMod(mod);

                if ((ModStatus)mod["Status"] == ModStatus.Banned)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (string) NAME or empty space ]---");
                var name = ConsoleInputUtilities.InputStringOrNull();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (list of string) DESCRIPTION or empty space ]---");
                var description = ConsoleInputUtilities.InputTextOrNull();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (string) AUTHOR or empty space ]---");
                var author = ConsoleInputUtilities.InputStringOrNull();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (version) VERSION or empty space ]---");
                var version = ConsoleInputUtilities.InputVersionOrNull();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (int) RANK or empty space ]---");
                var rank = ConsoleInputUtilities.InputIntOrNull();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ---[ (list of string) LIST OF TAGS or empty space ]---");
                var text = ConsoleInputUtilities.InputTextOrNull();
                List<string>? tags = null;
                if (text is not null)
                {
                    tags = text.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                ModDatabase.Update(id, name, description, author, version, rank, tags);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void AddTag()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                ModDatabase.CheckStatusMod(id, out ModStatus status);
                if (status == ModStatus.Banned)
                {
                    ConsoleLogger.Warn("This mod is banned!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine(" ---[ (string) TAG ]---");
                var tag = ConsoleInputUtilities.InputString();
                switch (ModDatabase.AddTag(id, tag))
                {
                    case HasTagResult.HasTag:
                        ConsoleLogger.Warn("This mod already has this tag!");
                        break;
                    case HasTagResult.Successful:
                        ConsoleLogger.Info("Tag added to mod!");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void DeleteTag()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                ModDatabase.CheckStatusMod(id, out ModStatus status);
                if (status == ModStatus.Banned)
                {
                    ConsoleLogger.Warn("This mod is banned!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine(" ---[ (string) MOD TAGS ]---");
                var tag = ConsoleInputUtilities.InputString();
                switch (ModDatabase.RemoveTag(id, tag))
                {
                    case HasNotTagResult.HasNotTag:
                        ConsoleLogger.Warn("Tag is undefined!");
                        break;
                    case HasNotTagResult.Successful:
                        ConsoleLogger.Info("Tag removed!");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void PrintAllModsWithTags()
        {
            Console.WriteLine(" ---[ (string) MOD TAGS ]---");
            var modpack = ConsoleInputUtilities.InputString();
            switch (ModDatabase.GetAllModsWithTag(modpack, out var mods))
            {
                case IsNotExistResult.IsNotExist:
                    ConsoleLogger.Warn("This tag is not exist!");
                    break;
                case IsNotExistResult.Successful:
                    ConsoleOutputUtilities.PrintMods(ModDatabase, mods, MinecraftVersion);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void ChangeMinecraftVersionForMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            Console.ForegroundColor = ConsoleColor.White;
            if (id != "")
            {
                ModDatabase.CheckStatusMod(id, out ModStatus status);
                if (status == ModStatus.Banned)
                {
                    ConsoleLogger.Warn("This mod is banned!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                    return;
                }

                ModDatabase.Read(id, out var data);
                Console.WriteLine(" ---[ MINECRAFT VERSION ]---");
                ConsoleLogger.Info($"Current version is [{data["MinecraftVersion"]}]!");
                var a = ConsoleInputUtilities.InputVersionOrNull();
                var b = ConsoleInputUtilities.InputVersionOrNull();
                a = a ?? ((ModMinecraftVersion)data["MinecraftVersion"]).First;
                b = b ?? ((ModMinecraftVersion)data["MinecraftVersion"]).Last;
                if (a > b)
                {
                    var c = b;
                    b = a;
                    a = c;
                }
                switch (ModDatabase.ChangeMinecraftVersionForMod(id, new((EntityVersion)a, (EntityVersion)b), out string newID))
                {
                    case IsNotCorrectVersionResult.NoCorrectVersion:
                        ConsoleLogger.Warn("You entered an older version than the current one!");
                        break;
                    case IsNotCorrectVersionResult.Successful:
                        if (newID == id)
                        {
                            ConsoleLogger.Info("Minecraft version for mod is changed!");
                        }
                        else
                        {
                            ConsoleLogger.Info($"Minecraft version for mod is changed! Also changed ID! New ID is [{newID}]");
                        }
                        break;
                };

                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void ChangeMinecraftVersionForUser()
        {
            Console.WriteLine(" ---[ MINECRAFT VERSION ]---");
            ConsoleLogger.Info($"Current version is {MinecraftVersion}!");
            var v = ConsoleInputUtilities.InputVersionOrNull();
            Console.ForegroundColor = ConsoleColor.White;
            MinecraftVersion = v ?? MinecraftVersion;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void BanMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                switch (ModDatabase.BanMod(id))
                {
                    case IsBanResult.IsBan:
                        ConsoleLogger.Warn("Mod is already banned!");
                        break;
                    case IsBanResult.Successful:
                        ConsoleLogger.Info("Mod is banned!");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
        public static void ShadowBanMod()
        {
            ConsoleOutputUtilities.PrintMods(ModDatabase, ModDatabase.GetListOfIDMods(), MinecraftVersion);
            Console.WriteLine();
            string id = ConsoleInputUtilities.InputExistIDOrEmptyString(ModDatabase);
            if (id != "")
            {
                switch (ModDatabase.ShadowBan(id))
                {
                    case IsBanResult.IsBan:
                        ConsoleLogger.Warn("Mod is already shadow banned!");
                        break;
                    case IsBanResult.Successful:
                        ConsoleLogger.Info("Mod is shadow banned!");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n - Press Enter to continue... ");
            Console.ReadLine();
        }
    }
}
