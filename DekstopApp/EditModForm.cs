using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class EditModForm : Form
    {
        MinecraftMod Mod;
        public EditModForm(MinecraftMod mod)
        {
            InitializeComponent();
            Mod = mod;
            IDText.Text = Mod.Id;
            NameInput.Text = Mod.Name;
            AuthorInput.Text = Mod.Author;
            DescriptionInput.Text = Mod.Description.Replace("\n", Environment.NewLine);
            VersionAInput.Value = Mod.Version.A;
            VersionBInput.Value = Mod.Version.B;
            VersionCInput.Value = Mod.Version.C;
            VersionTypeInput.SelectedIndex = (int)Mod.Version.Type;
            TypeText.Text = Mod.IsJavaMod ? "Java mod" : "Bedrock mod";
            RankInput.Value = Mod.Rank;
            ModpackInput.Text = String.Join(Environment.NewLine, Mod.ModPacks);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Mod.Name = NameInput.Text;
            Mod.Author = AuthorInput.Text;
            Mod.Description = DescriptionInput.Text.Replace(Environment.NewLine, "\n");
            Mod.Version.A = (int)VersionAInput.Value;
            Mod.Version.B = (int)VersionBInput.Value;
            Mod.Version.C = (int)VersionCInput.Value;
            Mod.Version.Type = (TypeVersion)VersionTypeInput.SelectedIndex;
            Mod.Rank = (int)RankInput.Value; 
            Mod.ModPacks = ModpackInput.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
            Close();
        }
    }
}
