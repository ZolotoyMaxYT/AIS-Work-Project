using BussinesLogic;

namespace DekstopApp
{
    public partial class MainForm : Form
    {
        private Label hiddenLabel = new()
        {
            AutoSize = false,
            Text = "",
            Height = 1
        };
        public MainForm()
        {
            InitializeComponent();
            Database.Create("ExempleMod", "Exemple mod",      
                "This is an exemple mod for Minecraft Java!\nYou can use it to create your own mod.", 
                "Mr. Coder", 
                new(Entity.TypeVersion.Release, 1, 0, 0), true, 100, ["coder pack", "mr coder", "open source"]);
            Database.Create("SmallMod",     "Small mod",
                "This is a very small mod for MinecraftJava! :D\nAnd... :p\nIt's my first mod! >w<", 
                "Ms. Coder",
                new(Entity.TypeVersion.Alpha, 1, 36, 114), true, 70, ["coder pack"]);
            Database.Create("AnotherMod", "Another mod",      
                "Another mod for Minecraft Java!\nPlay with your favorite monster!\nTime to play!", 
                "Mr. Coder", 
                new(Entity.TypeVersion.Beta, 25, 17, 231), true, 135, ["coder pack", "mr coder"]);
            Database.Create("VeryBadMod", "Very bad mod!", 
                "DON'T DOWNLOAD THIS MOD!!!!\nIT DESTROY YOUR MINECRAFT!!!\nNEW 2.1.0 VERSION!!!!", 
                "Mr. Virus", 
                new(Entity.TypeVersion.Alpha, 2, 1, 0), true, -5261, []);
            MenuUpdate();
            ModList_SizeChange(null, null);
            SizeChanged += ModList_SizeChange;
        }

        public void MenuUpdate()
        {
            ModList.Controls.Clear();
            ModList.Controls.Add(hiddenLabel);
            foreach (var item in Database.ListOfMods())
            {
                var a = new ModListItem(this, item)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Width = ModList.Width - 50,
                };
                ModList.Controls.Add(a);
            }
        }

        public ModDatabase Database = new();

        private void CreateButton_Click(object sender, EventArgs e)
        {
            new NewModForm(this).ShowDialog();
            MenuUpdate();
        }

        private void ModList_SizeChange(object sender, EventArgs e)
        {
            if (ModList.VerticalScroll.Visible)
            {
                hiddenLabel.Width = ModList.Width - 25;
            }
            else
            {
                hiddenLabel.Width = ModList.Width - 10;
            }
        }
    }
}
