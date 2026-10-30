using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class ModListItem : UserControl
    {
        string Mod;
        MainForm Mainform;
        public ModListItem(MainForm mainform, string mod)
        {
            InitializeComponent();
            Mod = mod;
            Mainform = mainform;
            Mainform.ModDatabase.GetStringMod(mod, out string result);
            Title.Text = result;
            Mainform.ModDatabase.GetAllTags(mod, out string[] tags);
            Tags.Text = String.Join(", ", tags);
            (Mainform.ModDatabase).IsCorrectForMinecraftVersion(mod, mainform.MinecraftVersion, out bool versionIsCorrect);
            if (versionIsCorrect)
            {
                BackColor = SystemColors.ControlLightLight;
                Tags.BackColor = SystemColors.Control;
            }
            else
            {
                BackColor = SystemColors.ControlLight;
                Tags.BackColor = SystemColors.ScrollBar;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            new InfoModForm(Mainform, Mod).ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Mainform.ModDatabase.Delete(Mod);
            Mainform.MenuUpdate();
        }
    }
}
