using ArchIS;

// Пример работы в консоли

void Print(Dictionary<string, object>? data)
{
    if (data is null)
        Console.WriteLine("[UNDEFINED]");
    else foreach (var item in data)
        Console.WriteLine($"| {item.Value.GetType().Name} {item.Key} : {item.Value}");
}
void Create(List<MinecraftMod> database, Dictionary<string, object> data)
{
    Console.Write($"[INFO]: Create a [{data["Id"]}] is ");
    Console.WriteLine(Logic.Create(database, data));
}

var l = new List<MinecraftMod>();
Logic.Create(l, new() { { "Id", "SimpleMod" }, { "Author", "Ivan" }, { "Version", 1 }, { "IsPublic", true } });
Logic.Create(l, new() { { "Id", "AnotherMod" }, { "Author", "Ivan" }, { "Version", 3 }, { "IsPublic", false } });
Create(l, new() { { "Id", "CoolMod" }, { "Author", "Oleg" }, { "Version", 5 }, { "IsPublic", false } });
Create(l, new() { { "Id", "BadMod" }, { "Author", "Vlad" }, { "Version", 7 }, { "IsPublic", false } });
Create(l, new() { { "Id", "BadMod" }, { "Author", "VladCopy" }, { "Version", 3 }, { "IsPublic", false } });

void a()
{
    Console.WriteLine("+---[SimpleMod]---");
    Print(Logic.Read(l, "SimpleMod"));
    Console.WriteLine("+---[AnotherMod]---");
    Print(Logic.Read(l, "AnotherMod"));
    Console.WriteLine("+---[CoolMod]---");
    Print(Logic.Read(l, "CoolMod"));
    Console.WriteLine("+---[BadMod]---");
    Print(Logic.Read(l, "BadMod"));
    Console.WriteLine();
}

a();
Logic.Delete(l, "BadMod");
a();
Logic.SetPublic(l, "CoolMod");
a();