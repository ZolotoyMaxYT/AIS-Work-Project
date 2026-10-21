using Model;
using BussinesLogic;
using ConsoleApp;

ConsoleMenu menu = new(["list of mods", "create", "read", "delete", "update", "add tag", "delete tag", "all mods with tag", "change minecraft version for mod", "change minecraft version for user", "ban mod", "shadow ban mod"]);
ModDatabase db = new ModDatabase();

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
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
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
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
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
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    if (id != "")
                    {
                        db.Read(id, out var mod);
                        ConsoleUtils.PrintMod(mod);

                        if ((ModStatus)mod["Status"] == ModStatus.Banned)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n - Press Enter to continue... ");
                            Console.ReadLine();
                            continue;
                        }

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
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    if (id != "")
                    {
                        db.CheckStatusMod(id, out ModStatus status);
                        if (status == ModStatus.Banned)
                        {
                            ConsoleUtils.Warn("This mod is banned!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n - Press Enter to continue... ");
                            Console.ReadLine();
                            continue;
                        }
                        
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
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    if (id != "")
                    {
                        db.CheckStatusMod(id, out ModStatus status);
                        if (status == ModStatus.Banned)
                        {
                            ConsoleUtils.Warn("This mod is banned!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n - Press Enter to continue... ");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine(" ---[ (string) MOD TAGS ]---");
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
            case 7: // all mods with tags
                {
                    Console.WriteLine(" ---[ (string) MOD TAGS ]---");
                    var modpack = ConsoleUtils.InputString();
                    switch (db.GetAllModsWithTag(modpack, out var mods))
                    {
                        case IsNotExistResult.IsNotExist:
                            ConsoleUtils.Warn("This tag is not exist!");
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
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (id != "")
                    {
                        db.CheckStatusMod(id, out ModStatus status);
                        if (status == ModStatus.Banned)
                        {
                            ConsoleUtils.Warn("This mod is banned!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n - Press Enter to continue... ");
                            Console.ReadLine();
                            continue;
                        }

                        db.Read(id, out var data);
                        Console.WriteLine(" ---[ MINECRAFT VERSION ]---");
                        ConsoleUtils.Info($"Current version is [{data["MinecraftVersion"]}]!");
                        ConsoleUtils.Info($"First");
                        var a = ConsoleUtils.InputVersionOrNull();
                        ConsoleUtils.Info($"Last");
                        var b = ConsoleUtils.InputVersionOrNull();
                        a = a ?? ((ModMinecraftVersion)data["MinecraftVersion"]).First;
                        b = b ?? ((ModMinecraftVersion)data["MinecraftVersion"]).Last;
                        if (a > b)
                        {
                            var c = b;
                            b = a;
                            a = c;
                        }
                        switch (db.ChangeMinecraftVersionForMod(id, new((EntityVersion)a, (EntityVersion)b), out string newID))
                        {
                            case IsNotCorrectVersionResult.NoCorrectVersion:
                                ConsoleUtils.Warn("You entered an older version than the current one!");
                                break;
                            case IsNotCorrectVersionResult.Successful:
                                if (newID == id)
                                {
                                    ConsoleUtils.Info("Minecraft version for mod is changed!");
                                }
                                else
                                {
                                    ConsoleUtils.Info($"Minecraft version for mod is changed! Also changed ID! New ID is [{newID}]");
                                }
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
            case 10: // ban mod
                {
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    if (id != "")
                    {
                        switch (db.BanMod(id))
                        {
                            case IsBanResult.IsBan:
                                ConsoleUtils.Warn("Mod is already banned!");
                                break;
                            case IsBanResult.Successful:
                                ConsoleUtils.Info("Mod is banned!");
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
            case 11: // shadowban mod
                {
                    ConsoleUtils.PrintMods(db, db.GetListOfIDMods(), minecraftVersion);
                    Console.WriteLine();
                    string id = ConsoleUtils.InputExistIDOrEmptyString(db);
                    if (id != "")
                    {
                        switch (db.ShadowBan(id))
                        {
                            case IsBanResult.IsBan:
                                ConsoleUtils.Warn("Mod is already shadow banned!");
                                break;
                            case IsBanResult.Successful:
                                ConsoleUtils.Info("Mod is shadow banned!");
                                break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n - Press Enter to continue... ");
                    Console.ReadLine();
                }
                break;
        }
    }
}