using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    public struct EntityVersion
    {
        public TypeVersion Type;
        public int A;
        public int B;
        public int C;

        public EntityVersion(TypeVersion type, int a, int b, int c)
        {
            Type = type;
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"v{A}.{B}.{C} ({Type})";
        }

        public static bool operator ==(EntityVersion x, EntityVersion y)
        {
            return x.Type == y.Type && x.A == y.A && x.B == y.B && x.C == y.C;
        }
        public static bool operator !=(EntityVersion x, EntityVersion y)
        {
            return x.Type != y.Type || x.A != y.A || x.B != y.B || x.C != y.C;
        }
        public static bool operator >(EntityVersion x, EntityVersion y)
        {
            return x.Type > y.Type || (x.Type == y.Type && x.A > y.A) || (x.Type == y.Type && x.A == y.A && x.B > y.B) || (x.Type == y.Type && x.A == y.A && x.B == y.B && x.C > y.C);
        }
        public static bool operator <(EntityVersion x, EntityVersion y)
        {
            return x.Type < y.Type || (x.Type == y.Type && x.A < y.A) || (x.Type == y.Type && x.A == y.A && x.B < y.B) || (x.Type == y.Type && x.A == y.A && x.B == y.B && x.C < y.C);
        }
        public static bool operator >=(EntityVersion x, EntityVersion y)
        {
            return x > y || x == y;
        }
        public static bool operator <=(EntityVersion x, EntityVersion y)
        {
            return x < y || x == y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not null && obj is EntityVersion vers)
            {
                return this == vers;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() + A.GetHashCode() + B.GetHashCode() + C.GetHashCode();
        }

        /// <summary>
        /// FORMAT: [v]1.0.0[(]{alpha|a, beta|b, release|r}[)]<br/>
        /// FULL: v1.0.0 (alpha)<br/>
        /// NORMAL: v1.0.0 beta<br/>
        /// SHORTER: v1.0.0r<br/>
        /// SHORTEST: 1.0.0a
        /// </summary>
        /// <param name="data">string view of version</param>
        /// <param name="result">result version</param>
        /// <returns>Parse is successful or not</returns>
        public static bool TryParse(string data, out EntityVersion result)
        {
            result = new();
            string text = data.ToLower().Replace(" ", "").Replace("(", "").Replace(")", "");
            if (text[0] == 'v') text = text.Substring(1);
            string[] args = text.Split('.');
            if (args.Length == 3 && int.TryParse(args[0], out int a) && int.TryParse(args[1], out int b))
            {
                text = "";
                var regex = new Regex(@"[^0-9]");
                for (int i = 0; i < args[2].Length; i++)
                {
                    text += args[2][i];
                    if (regex.Match(text).Success)
                    {
                        if (int.TryParse(text.Substring(0, text.Length - 1), out int c))
                        {
                            text = args[2].Substring(text.Length - 1);
                            switch (text)
                            {
                                case "r":
                                case "release":
                                    result = new EntityVersion(TypeVersion.Release, a, b, c);
                                    return true;
                                case "b":
                                case "beta":
                                    result = new EntityVersion(TypeVersion.Beta, a, b, c);
                                    return true;
                                case "a":
                                case "alpha":
                                    result = new EntityVersion(TypeVersion.Alpha, a, b, c);
                                    return true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
