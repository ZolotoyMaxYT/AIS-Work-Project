using Model;
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
