using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
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
    }
}
