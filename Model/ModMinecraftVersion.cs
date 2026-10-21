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

        public static EntityVersion GetCorrectLastVersion(EntityVersion first, EntityVersion last)
        {
            // first is [1.8.0r; 1.13.0r)   ->   last is [1.8.0r; 1.13.0r)
            if (first >= new EntityVersion(TypeVersion.Release, 1, 8, 0) && first < new EntityVersion(TypeVersion.Release, 1, 13, 0) && last >= new EntityVersion(TypeVersion.Release, 1, 13, 0))
                return new EntityVersion(TypeVersion.Release, 1, 12, 100);
            // first is [x; 1.8.0r)   ->   last is [x; 1.8.0r)
            if (first < new EntityVersion(TypeVersion.Release, 1, 8, 0) && last >= new EntityVersion(TypeVersion.Release, 1, 8, 0))
                return new EntityVersion(TypeVersion.Release, 1, 7, 10);
            // fine
            return last;
        }
    }
}
