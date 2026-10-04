using BussinesLogic;
using ConsoleApp;

ConsoleMenu menu = new(["list of mods", "create", "read", "delete", "update", "add tag", "delete tag", "all tags of mod", "change minecraft version for mod", "change minecraft version for user"]);
ModDatabase db = new ModDatabase();

db.Create("ExempleMod", "Exemple mod", "This is a exemple mod with open source code.\nYou can download and use my code for your mods.\nBy Mr. Coder", "Mr. Coder", new(TypeVersion.Release, 1, 0, 0), new(new(TypeVersion.Release, 1, 7, 0), new(TypeVersion.Release, 1, 7, 10)), true, 99, ["mr. coder", "coder", "open source"]);
db.Create("AnotherMod", "Another mod", "This is a another mod.\nYou can download my mod but you can't use my code for your project.\nBy Mr. Coder", "Mr. Coder", new(TypeVersion.Alpha, 2, 25, 484), new(new(TypeVersion.Release, 1, 7, 0), new(TypeVersion.Release, 1, 7, 10)), true, 68, ["mr. coder", "coder"]);
db.Create("SmallMod", "Very Small Mod", "This is my first mod!\nPlease play and enjoy!", "Ms. Coder", new(TypeVersion.Beta, 1, 8, 13), new(new(TypeVersion.Release, 1, 8, 0), new(TypeVersion.Release, 1, 8, 8)), true, 84, ["ms. coder", "coder"]);
db.Create("BadMod", "Not a Mod", "", "AAA", new(TypeVersion.Alpha, 25, 25, 25), new(new(TypeVersion.Release, 1, 13, 0), new(TypeVersion.Release, 1, 16, 3)), false, -46, []);

string InputExistIDOrEmptyString()
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

EntityVersion minecraftVersion = new(TypeVersion.Release, 1, 7, 10);

while (true)
{
    Console.Clear();
    ConsoleUtils.Info($"Minecraft version: {minecraftVersion}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----[MENU]------");
    menu.Print();
    Console.WriteLine("-----------------\n");
    if (menu.Update(out int index))
    {
        switch (index)
        {
            case 0: // list of mods
                {
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 1: // create
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
                        if (db.IsExist(id))
                        {
                            ConsoleUtils.Warn($"Mod with id \"{id}\" is exist!");
                            continue;
                        }
                        break;
                    }
                    if (id == "")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n - Press Enter to continue... ");
                        Console.ReadLine();
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (string) NAME ]---");
                    var name = ConsoleUtils.InputString();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (list of string) DESCRIPTION ]---");
                    var description = ConsoleUtils.InputText();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (string) AUTHOR ]---");
                    var author = ConsoleUtils.InputString();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (version) VERSION ]---");
                    var version = ConsoleUtils.InputVersion();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (version) FIRST MINECRAFT VERSION ]---");
                    var mineVersionA = ConsoleUtils.InputVersion();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (version) LAST MINECRAFT VERSION ]---");
                    var mineVersionB = ConsoleUtils.InputVersion();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (bool) IS JAVA? ]---");
                    var isJava = ConsoleUtils.InputBool();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (int) RANK ]---");
                    var rank = ConsoleUtils.InputInt();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (list of string) LIST OF TAGS ]---");
                    var tags = ConsoleUtils.StringList(ConsoleUtils.InputText().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList());
                    db.Create(id, name, description, author, version, new(mineVersionA, mineVersionB), isJava, rank, tags);
                    ConsoleUtils.Info("Mod is created!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                } 
                break;
            case 2: // read
                {
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        db.Read(id, out var mod);
                        ConsoleUtils.PrintMod(mod);
                    }
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 3: // delete
                {
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        db.Delete(id);
                        ConsoleUtils.Info("Mod is removed!");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 4: // update
                {
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        db.Read(id, out var mod);
                        ConsoleUtils.PrintMod(mod);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (string) NAME or empty space ]---");
                        var name = ConsoleUtils.InputStringOrNull();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (list of string) DESCRIPTION or empty space ]---");
                        var description = ConsoleUtils.InputTextOrNull();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (string) AUTHOR or empty space ]---");
                        var author = ConsoleUtils.InputStringOrNull();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (version) VERSION or empty space ]---");
                        var version = ConsoleUtils.InputVersionOrNull();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (int) RANK or empty space ]---");
                        var rank = ConsoleUtils.InputIntOrNull();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ---[ (list of string) LIST OF TAGS or empty space ]---");
                        var text = ConsoleUtils.InputTextOrNull();
                        List<string>? tags = null;
                        if (text is not null)
                        {
                            tags = text.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
                        }
                        db.Update(id, name, description, author, version, rank, tags);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 5: // add tag
                {
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        Console.WriteLine(" ---[ (string) TAG ]---");
                        var tag = ConsoleUtils.InputString();
                        switch (db.AddTag(id, tag))
                        {
                            case HasTagResult.HasTag:
                                ConsoleUtils.Warn("This mod already has this tag!");
                                break;
                            case HasTagResult.Successful:
                                ConsoleUtils.Info("Tag added to mod!");
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 6: // delete from modpack
                {
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        Console.WriteLine(" ---[ (string) MOD PACK ]---");
                        var tag = ConsoleUtils.InputString();
                        switch (db.RemoveTag(id, tag))
                        {
                            case HasNotTagResult.HasNotTag:
                                ConsoleUtils.Warn("Tag is undefined!");
                                break;
                            case HasNotTagResult.Successful:
                                ConsoleUtils.Info("Tag removed!");
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 7: // all mods from modpack
                {
                    Console.WriteLine(" ---[ (string) MOD PACK ]---");
                    var modpack = ConsoleUtils.InputString();
                    switch (db.GetAllModsWithTag(modpack, out var mods))
                    {
                        case IsNotExistResult.IsNotExist:
                            ConsoleUtils.Warn("This modpack is not exist!");
                            break;
                        case IsNotExistResult.Successful:
                            ConsoleUtils.PrintMods(db, mods, minecraftVersion);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 8: // change minecraft version for mod
                {
                    string id = InputExistIDOrEmptyString();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (id != "")
                    {
                        db.Read(id, out var data);
                        Console.WriteLine(" ---[ MINECRAFT VERSION ]---");
                        ConsoleUtils.Info($"Current version is [{data["MinecraftVersion"]}]!");
                        var a = ConsoleUtils.InputVersionOrNull();
                        var b = ConsoleUtils.InputVersionOrNull();
                        a = a ?? ((MinecraftVersion)data["MinecraftVersion"]).First;
                        b = b ?? ((MinecraftVersion)data["MinecraftVersion"]).Last;
                        if (a > b)
                        {
                            var c = b;
                            b = a;
                            a = c;
                        }
                        switch (db.ChangeMinecraftVersionForMod(id, new((EntityVersion)a, (EntityVersion)b)))
                        {
                            case IsNotCorrectVersionResult.NoCorrectVersion:
                                ConsoleUtils.Warn("You entered an older version than the current one!");
                                break;
                            case IsNotCorrectVersionResult.Successful:
                                ConsoleUtils.Info("Minecraft version for mod is changed!");
                                break;
                        }
                        ;

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 9: // change minecraft version for user
                {
                    Console.WriteLine(" ---[ MINECRAFT VERSION ]---");
                    ConsoleUtils.Info($"Current version is {minecraftVersion}!");
                    var v = ConsoleUtils.InputVersionOrNull();
                    Console.ForegroundColor = ConsoleColor.White;
                    minecraftVersion = v ?? minecraftVersion;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
        }
    }
}