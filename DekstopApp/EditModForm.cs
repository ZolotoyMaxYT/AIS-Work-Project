using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class EditModForm : Form
    {
        MainForm Mainform;
        string Mod;
        public EditModForm(MainForm mainform, string mod)
        {
            InitializeComponent();
            Mainform = mainform;
            Mod = mod;
            Mainform.Database.Read(Mod, out var data);
            IDText.Text = (string)data["Id"];
            NameInput.Text = (string)data["Name"];
            AuthorInput.Text = (string)data["Author"];
            DescriptionInput.Text = ((string)data["Description"]).Replace("\n", Environment.NewLine);
            VersionAInput.Value = ((ModVersion)data["Version"]).A;
            VersionBInput.Value = ((ModVersion)data["Version"]).B;
            VersionCInput.Value = ((ModVersion)data["Version"]).C;
            VersionTypeInput.SelectedIndex = (int)((ModVersion)data["Version"]).Type;
            TypeText.Text = (bool)data["IsJavaMod"] ? "Java mod" : "Bedrock mod";
            RankInput.Value = (int)data["Rank"];
            ModpackInput.Text = String.Join(Environment.NewLine, (List<string>)data["ModPacks"]);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (VersionTypeInput.SelectedIndex == -1)
            {
                MessageBox.Show(null, $"Incorrect mod version type \"{VersionTypeInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Mainform.Database.Update(Mod, NameInput.Text, DescriptionInput.Text.Replace(Environment.NewLine, "\n"), AuthorInput.Text,
                new((TypeVersion)VersionTypeInput.SelectedIndex, (int)VersionAInput.Value, (int)VersionBInput.Value, (int)VersionCInput.Value),
                (int)RankInput.Value, ModpackInput.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList());
            Close();
        }
    }
}
