using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class ModListItem : UserControl
    {
        MinecraftMod Mod;
        MainForm Mainform;
        public ModListItem(MainForm mainform, MinecraftMod mod)
        {
            InitializeComponent();
            Mod = mod;
            Mainform = mainform;
            Title.Text = mod.ToString();
            Modpacks.Text = String.Join(", ", mod.ModPacks);
        }
        public ModListItem()
        {
            InitializeComponent();
            Mod = null;
            Mainform = null;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            new InfoModForm(Mainform, Mod).ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Mainform.Database.Delete(Mod.Id);
            Mainform.MenuUpdate();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
