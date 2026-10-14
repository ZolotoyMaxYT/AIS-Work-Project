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
        MainForm MainForm;

        public MinecraftVersionEdit(MainForm mainform)
        {
            InitializeComponent();
            MainForm = mainform;
            versionInput1.Version = MainForm.MinecraftVersion;
            versionInput1.UpdateValues();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            versionInput1.UpdateChanges();
            MainForm.MinecraftVersion = versionInput1.Version;
            MainForm.ModVersionUpdate();
        }
    }
}
