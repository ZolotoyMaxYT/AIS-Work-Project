using Model;
using BussinesLogic;

namespace ConsoleApp
{
    internal static class StringUtilities
    {
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
        
    }
}
