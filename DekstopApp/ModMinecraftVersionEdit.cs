using Model;
using BussinesLogic;

namespace DekstopApp
{
    public partial class ModMinecraftVersionEdit : Form
    {
        IModDatabaseMinecraftVersionManager Database;
        public string Mod { get; private set; }
        ModMinecraftVersion Version;
        public ModMinecraftVersionEdit(IModDatabaseMinecraftVersionManager db, string mod, ModMinecraftVersion version)
        {
            InitializeComponent();
            Database = db;
            Mod = mod;
            Version = version;
            versionInput1.Version = Version.First;
            versionInput1.UpdateValues();
            versionInput2.Version = Version.Last;
            versionInput2.UpdateValues();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            versionInput1.UpdateChanges();
            versionInput2.UpdateChanges();

            switch (Database.ChangeMinecraftVersionForMod(Mod, new(versionInput1.Version, versionInput2.Version), out string newID))
            {
                case IsNotCorrectVersionResult.NoCorrectVersion:
                    MessageBox.Show(null, $"Incorrect minecraft version!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case IsNotCorrectVersionResult.Successful:
                    Mod = newID;
                    Close();
                    break;
            }
        }
    }
}
