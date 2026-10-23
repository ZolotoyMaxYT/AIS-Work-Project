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
            return first.Type != last.Type ? new EntityVersion(first.Type, 255, 255, 255) : last;
        }
    }
}
