using System;
using System.Windows.Forms;
using BussinesLogic;

namespace DekstopApp
{
    public partial class NewModForm : Form
    {
        MainForm Mainform;
        public NewModForm(MainForm mainform)
        {
            InitializeComponent();
            Mainform = mainform;
            VersionTypeInput.SelectedIndex = 0;
            IsJavaInput.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (IsJavaInput.SelectedIndex == -1)
            {
                MessageBox.Show(null, $"Incorrect mod type \"{IsJavaInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (VersionTypeInput.SelectedIndex == -1)
            {
                MessageBox.Show(null, $"Incorrect mod version type \"{VersionTypeInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (Mainform.Database.Create(IDInput.Text, NameInput.Text, DescriptionInput.Text.Replace(Environment.NewLine, "\n"), AuthorInput.Text, new((TypeVersion)VersionTypeInput.SelectedIndex, (int)VersionAInput.Value, (int)VersionBInput.Value, (int)VersionCInput.Value), IsJavaInput.SelectedIndex == 0, (int)RankInput.Value, ModpackInput.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList()))
            {
                case BussinesLogic.IsExistResult.NotID:
                    MessageBox.Show(null, $"Incorrect id \"{IDInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case BussinesLogic.IsExistResult.IsExist:
                    MessageBox.Show(null, $"Mod with id \"{IDInput.Text}\" is exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case BussinesLogic.IsExistResult.Successful:
                    Close();
                    break;
            }
        }
    }
}
