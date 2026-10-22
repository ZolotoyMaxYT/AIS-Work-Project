using Model;
using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class InfoModForm : Form
    {
        MainForm Mainform;
        string Mod;

        private void FormUpdate()
        {
            Mainform.Database.Read(Mod, out var mod);
            TitleText.Text = $"[{mod["Id"]}] {mod["Name"]}";
            AuthorText.Text = (string)mod["Author"];
            RankText.Text = ((int)mod["Rank"]).ToString();
            TypeText.Text = (bool)mod["IsJavaMod"] ? "Java Mod" : "Bedrock Mod";
            VersionText.Text = mod["Version"].ToString();
            MinecraftVersionText.Text = mod["MinecraftVersion"].ToString();
            DescriptionText.Text = ((string)mod["Description"]).Replace("\n", Environment.NewLine);
            TagsText.Text = string.Join(Environment.NewLine, (string[])mod["Tags"]);

            Mainform.Database.CheckStatusMod(Mod, out ModStatus status);
            if (status == ModStatus.Banned)
            {
                ChangeButton.Enabled = false;
                MinecraftVersionEdit.Enabled = false;
            }
            else
            {
                ChangeButton.Enabled = true;
                MinecraftVersionEdit.Enabled = true;
            }
        }

        public InfoModForm(MainForm mainform, string mod)
        {
            InitializeComponent();
            Mainform = mainform;
            Mod = mod;
            FormUpdate();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            new EditModForm(Mainform, Mod).ShowDialog();
            FormUpdate();
            Mainform.MenuUpdate();
        }

        private void MinecraftVersionEdit_Click(object sender, EventArgs e)
        {
            Mainform.Database.Read(Mod, out var mod);
            var nnve = new ModMinecraftVersionEdit(Mainform.Database, Mod, (ModMinecraftVersion)mod["MinecraftVersion"]);
            nnve.ShowDialog();
            Mod = nnve.Mod;
            FormUpdate();
            Mainform.MenuUpdate();
        }
    }
}
