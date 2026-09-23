using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            switch (Mainform.Database.Create(IDInput.Text, NameInput.Text, DescriptionInput.Text.Replace(Environment.NewLine, "\n"), AuthorInput.Text, new((Entity.TypeVersion)VersionTypeInput.SelectedIndex, (int)VersionAInput.Value, (int)VersionBInput.Value, (int)VersionCInput.Value), IsJavaInput.SelectedIndex == 0, (int)RankInput.Value, ModpackInput.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList()))
            {
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
