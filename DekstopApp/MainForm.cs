using BussinesLogic;
using Model;
using Ninject;

namespace DekstopApp
{
    public partial class MainForm : Form
    {
        public IKernel NinjectKernel;
        public IBasicModDatabase ModDatabase;
        public EntityVersion MinecraftVersion = new(TypeVersion.Release, 1, 7, 10);

        private Label hiddenLabel = new()
        {
            AutoSize = false,
            Text = "",
            Height = 1
        };
        public MainForm()
        {
            InitializeComponent();
            NinjectKernel = new StandardKernel(new SimpleConfigModule());
            ModDatabase = NinjectKernel.Get<ModDatabase>();
            MenuUpdate();
            SizeChanged += ModList_SizeChange;
            MinecraftVersionButton.Text = $"Minecraft version is {MinecraftVersion} (click to change)";
        }

        public void MenuUpdate()
        {
            ModList.Controls.Clear();
            ModList.Controls.Add(hiddenLabel);
            foreach (var item in ((IModDatabaseModListManager)ModDatabase).GetListOfIDMods())
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
