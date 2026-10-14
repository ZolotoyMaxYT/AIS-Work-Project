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
                new(TypeVersion.Release, 1, 0, 0), new(new(TypeVersion.Release, 1, 7, 0), new(TypeVersion.Release, 1, 7, 10)), true, 100, ["coder pack", "mr coder", "open source"]);
            Database.Create("SmallMod", "Small mod",
                "This is a very small mod for MinecraftJava! :D\nAnd... :p\nIt's my first mod! >w<",
                "Ms. Coder",
                new(TypeVersion.Alpha, 1, 36, 114), new(new(TypeVersion.Release, 1, 7, 0), new(TypeVersion.Release, 1, 7, 10)), true, 70, ["coder pack"]);
            Database.Create("AnotherMod", "Another mod",
                "Another mod for Minecraft Java!\nPlay with your favorite monster!\nTime to play!",
                "Mr. Coder",
                new(TypeVersion.Beta, 25, 17, 231), new(new(TypeVersion.Release, 1, 8, 0), new(TypeVersion.Release, 1, 8, 8)), true, 135, ["coder pack", "mr coder"]);
            Database.Create("VeryBadMod", "Very bad mod!",
                "DON'T DOWNLOAD THIS MOD!!!!\nIT DESTROY YOUR MINECRAFT!!!\nNEW 2.1.0 VERSION!!!!",
                "Mr. Virus",
                new(TypeVersion.Alpha, 2, 1, 0), new(new(TypeVersion.Release, 1, 13, 0), new(TypeVersion.Release, 1, 16, 2)), false, -5261, []);
            MenuUpdate();
            SizeChanged += ModList_SizeChange;
            MinecraftVersionButton.Text = $"Minecraft version is {MinecraftVersion} (click to change)";
        }

        public void MenuUpdate()
        {
            ModList.Controls.Clear();
            ModList.Controls.Add(hiddenLabel);
            foreach (var item in Database.GetListOfIDMods())
            {
                var a = new ModListItem(this, item)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Width = ModList.Width - 50,
                };
                ModList.Controls.Add(a);
            }
            ModList_SizeChange(null, new());
        }

        public void ModVersionUpdate()
        {
            MenuUpdate();
            MinecraftVersionButton.Text = $"Minecraft version is {MinecraftVersion} (click to change)";
        }

        public ModDatabase Database = new();
        public EntityVersion MinecraftVersion = new(TypeVersion.Release, 1, 7, 10);

        private void CreateButton_Click(object? sender, EventArgs e)
        {
            new NewModForm(this).ShowDialog();
            MenuUpdate();
        }

        private void ModList_SizeChange(object? sender, EventArgs e)
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

        private void MinecraftVersionButton_Click(object sender, EventArgs e)
        {
            new MinecraftVersionEdit(this).ShowDialog();
        }

        private void BanButton_Click(object sender, EventArgs e)
        {
            new BanForm(this, ModStatus.Banned).ShowDialog();
        }

        private void ShadowBanButton_Click(object sender, EventArgs e)
        {
            new BanForm(this, ModStatus.ShadowBanned).ShowDialog();
        }
    }
}
