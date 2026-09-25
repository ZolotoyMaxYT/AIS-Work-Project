using BussinesLogic;
using ConsoleApp;

ConsoleMenu menu = new(["list of mods", "create", "read", "delete", "update", "add to modpack", "delete from modpack", "all mods from modpack"]);
ModDatabase db = new ModDatabase();

db.Create("ExempleMod", "Exemple mod", "This is a exemple mod with open source code.\nYou can download and use my code for your mods.\nBy Mr. Coder", "Mr. Coder", new(TypeVersion.Release, 1, 0, 0), true, 99, ["mr. coder", "coder", "open source"]);
db.Create("AnotherMod", "Another mod", "This is a another mod.\nYou can download my mod but you can't use my code for your project.\nBy Mr. Coder", "Mr. Coder", new(TypeVersion.Alpha, 2, 25, 484), true, 68, ["mr. coder", "coder"]);
db.Create("SmallMod", "Very Small Mod", "This is my first mod!\nPlease play and enjoy!", "Ms. Coder", new(TypeVersion.Beta, 1, 8, 13), true, 84, ["ms. coder", "coder"]);
db.Create("BadMod", "Not a Mod", "", "AAA", new(TypeVersion.Alpha, 25, 25, 25), false, -46, []);

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
        if (!db.Has(id))
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

while (true)
{
    Console.Clear();
    Console.WriteLine("-----[MENU]------");
    menu.Print();
    Console.WriteLine("-----------------\n");
    if (menu.Update(out int index))
    {
        switch (index)
        {
            case 0: // list of mods
                {
                    ConsoleUtils.PrintMods(db, db.ListOfIDMods());
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
                        if (db.Has(id))
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
                    Console.WriteLine(" ---[ (bool) IS JAVA? ]---");
                    var isJava = ConsoleUtils.InputBool();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (int) RANK ]---");
                    var rank = ConsoleUtils.InputInt();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---[ (list of string) LIST OF MOD PACKS ]---");
                    var modpacks = ConsoleUtils.StringList(ConsoleUtils.InputText().Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList());
                    db.Create(id, name, description, author, version, isJava, rank, modpacks);
                    ConsoleUtils.Info("Mod is created!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                } 
                break;
            case 2: // read
                {
                    ConsoleUtils.PrintMods(db, db.ListOfIDMods());
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
                        Console.WriteLine(" ---[ (list of string) LIST OF MOD PACKS or empty space ]---");
                        var text = ConsoleUtils.InputTextOrNull();
                        List<string>? modpacks = null;
                        if (text is not null)
                        {
                            modpacks = text.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
                        }
                        db.Update(id, name, description, author, version, rank, modpacks);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 5: // add to modpack
                {
                    string id = InputExistIDOrEmptyString();
                    if (id != "")
                    {
                        Console.WriteLine(" ---[ (string) MOD PACK ]---");
                        var modpack = ConsoleUtils.InputString();
                        switch (db.AddToModPack(id, modpack))
                        {
                            case InModPackResult.InModPack:
                                ConsoleUtils.Warn("This mod is already in modpack!");
                                break;
                            case InModPackResult.Successful:
                                ConsoleUtils.Info("Mod added to modpack!");
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
                        var modpack = ConsoleUtils.InputString();
                        switch (db.RemoveFromModPack(id, modpack))
                        {
                            case NotInModPackResult.NotInModPack:
                                ConsoleUtils.Warn("This mod is not in modpack!");
                                break;
                            case NotInModPackResult.Successful:
                                ConsoleUtils.Info("Mod removed from modpack!");
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
                    switch (db.GetAllModsFromModPack(modpack, out var mods))
                    {
                        case IsNotExistResult.IsNotExist:
                            ConsoleUtils.Warn("This modpack is not exist!");
                            break;
                        case IsNotExistResult.Successful:
                            ConsoleUtils.PrintMods(db, mods);
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
        }
    }
}