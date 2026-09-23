using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class InfoModForm : Form
    {
        MainForm Mainform; 
        MinecraftMod Mod;

        private void FormUpdate()
        {
            TitleText.Text = $"[{Mod.Id}] {Mod.Name}";
            AuthorText.Text = Mod.Author;
            RankText.Text = Mod.Rank.ToString();
            TypeText.Text = Mod.IsJavaMod ? "Java Mod" : "Bedrock Mod";
            VersionText.Text = Mod.Version.ToString();
            DescriptionText.Text = Mod.Description.Replace("\n", Environment.NewLine);
            ModpackText.Text = string.Join(Environment.NewLine, Mod.ModPacks);
        }

        public InfoModForm(MainForm mainform, MinecraftMod mod)
        {
            InitializeComponent();
            Mainform = mainform;
            Mod = mod;
            FormUpdate();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            new EditModForm(Mod).ShowDialog();
            FormUpdate();
            Mainform.MenuUpdate();
        }
    }
}
