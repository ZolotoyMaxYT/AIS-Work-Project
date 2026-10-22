using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public struct ModMinecraftVersion
    {
        public EntityVersion First;
        public EntityVersion Last;

        public ModMinecraftVersion(EntityVersion first, EntityVersion last)
        {

            if (first > last)
            {
                First = last;
                Last = GetCorrectLastVersion(last, first);
            }
            else
            {
                First = first;
                Last = GetCorrectLastVersion(first, last);
            }
        }

        public override string ToString()
        {
            return $"{First} - {Last}";
        }
        public static string ToString(TypeVersion ftype, int fa, int fb, int fc, TypeVersion ltype, int la, int lb, int lc)
        {
            return $"{EntityVersion.ToString(ftype, fa, fb, fc)} - {EntityVersion.ToString(ltype, la, lb, lc)}";
        }

        public static EntityVersion GetCorrectLastVersion(EntityVersion first, EntityVersion last)
        {
            // [1.0.0a; 1.0.0b)
            if (first < new EntityVersion(TypeVersion.Beta, 1, 0, 0) && last >= new EntityVersion(TypeVersion.Beta, 1, 0, 0))
                return new EntityVersion(TypeVersion.Alpha, 1, 100, 100);
            // [1.0.0b; 1.0.0r)
            if (first < new EntityVersion(TypeVersion.Release, 1, 0, 0) && last >= new EntityVersion(TypeVersion.Release, 1, 0, 0))
                return new EntityVersion(TypeVersion.Beta, 1, 100, 100);
            // fine
            return last;
        }
    }
}
