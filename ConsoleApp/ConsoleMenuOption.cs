using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp;

public delegate void ConsoleMenuAction();
public struct ConsoleMenuOption
{
    public string Title;
    public ConsoleMenuAction Action;

    public ConsoleMenuOption(string title, ConsoleMenuAction action)
    {
        Title = title;
        Action = action;
    }
}
