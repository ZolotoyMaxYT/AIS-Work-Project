using BussinesLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class MinecraftVersionEdit : Form
    {
        ModDatabase Database;
        string Mod;
        MinecraftVersion Version;
        public MinecraftVersionEdit(ModDatabase db, string mod, MinecraftVersion version)
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

        private void MinecraftVersionEdit_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            versionInput1.UpdateChanges();
            versionInput2.UpdateChanges();

            switch (Database.ChangeMinecraftVersionForMod(Mod, new(versionInput1.Version, versionInput2.Version)))
            {
                case IsNotCorrectVersionResult.NoCorrectVersion:
                    MessageBox.Show(null, $"Incorrect minecraft version!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case IsNotCorrectVersionResult.Successful:
                    Close();
                    break;
            }
        }
    }
}
