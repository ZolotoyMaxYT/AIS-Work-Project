using BussinesLogic;

namespace DekstopApp
{
    public partial class VersionInput : UserControl
    {
        public EntityVersion Version;
        public VersionInput()
        {
            InitializeComponent();
            VersionTypeInput.SelectedIndex = 0;
        }

        public void UpdateValues()
        {
            VersionAInput.Value = Version.A;
            VersionBInput.Value = Version.B;
            VersionCInput.Value = Version.C;
            VersionTypeInput.SelectedIndex = (int)Version.Type;
        }
        public void UpdateChanges()
        {
            Version.A = (int)VersionAInput.Value;
            Version.B = (int)VersionBInput.Value;
            Version.C = (int)VersionCInput.Value;
            Version.Type = (TypeVersion)VersionTypeInput.SelectedIndex;
        }

        private void VersionTypeInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VersionTypeInput.SelectedIndex == -1)
            {
                MessageBox.Show(null, $"Incorrect mod version type \"{VersionTypeInput.Text}\"!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Version.Type = (TypeVersion)VersionTypeInput.SelectedIndex;
        }

        private void VersionAInput_ValueChanged(object sender, EventArgs e)
        {
            Version.A = (int)VersionAInput.Value;
        }

        private void VersionBInput_ValueChanged(object sender, EventArgs e)
        {
            Version.B = (int)VersionAInput.Value;
        }

        private void VersionCInput_ValueChanged(object sender, EventArgs e)
        {
            Version.C = (int)VersionAInput.Value;
        }
    }
}
