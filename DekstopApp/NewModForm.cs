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
            IsJavaInput.SelectedIndex = 0;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (IsJavaInput.SelectedIndex == -1)
            {
                MessageBox.Show(null, $"Incorrect mod type \"{IsJavaInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (MinecraftVersionFirstInput.Version > MinecraftVersionLastInput.Version)
            {
                MessageBox.Show(null, $"Incorrect minecraft version! First bigger than last!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MinecraftVersionFirstInput.UpdateChanges();
            MinecraftVersionLastInput.UpdateChanges();
            switch (Mainform.Database.Create(IDInput.Text, NameInput.Text, DescriptionInput.Text.Replace(Environment.NewLine, "\n"), AuthorInput.Text, VersionInput.Version, new(MinecraftVersionFirstInput.Version, MinecraftVersionLastInput.Version), IsJavaInput.SelectedIndex == 0, (int)RankInput.Value, TagsInput.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList()))
            {
                case IsExistResult.NotID:
                    MessageBox.Show(null, $"Incorrect id \"{IDInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case IsExistResult.IsExist:
                    MessageBox.Show(null, $"Mod with id \"{IDInput.Text}\" is exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case IsExistResult.Successful:
                    Close();
                    break;
            }
        }

        private void VersionButton_Click(object sender, EventArgs e)
        {

        }
    }
}
