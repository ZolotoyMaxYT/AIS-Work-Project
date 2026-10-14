using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinesLogic;

namespace DekstopApp
{
    public partial class BanForm : Form
    {
        MainForm Mainform;
        ModStatus NewModStatus;
        string[] Mods;
        public BanForm(MainForm mainform, ModStatus banStatus)
        {
            InitializeComponent();

            // This is ban form (not unban)
            if (banStatus == ModStatus.Active) Close();

            NewModStatus = banStatus;
            Mainform = mainform;
            InputUpdate();
        }

        private void InputUpdate()
        {
            IdInput.Items.Clear();
            string[] mods = Mainform.Database.GetFullListOfIDMods();
            List<string> ids = new();

            for (int i = 0; i < mods.Length; i++)
            {
                Mainform.Database.CheckStatusMod(mods[i], out ModStatus status);
                if (status == NewModStatus) continue;
                ids.Add(mods[i]);
                Mainform.Database.GetStringMod(mods[i], out string result);
                IdInput.Items.Add(result);
            }

            Mods = ids.ToArray();
        }

        private void BanButton_Click(object sender, EventArgs e)
        {
            if (IdInput.SelectedIndex == -1) return;
            switch (NewModStatus)
            {
                case ModStatus.Banned:
                    Mainform.Database.BanMod(Mods[IdInput.SelectedIndex]);
                    break;
                case ModStatus.ShadowBanned:
                    Mainform.Database.ShadowBan(Mods[IdInput.SelectedIndex]);
                    break;
            }
            Mainform.MenuUpdate();
            InputUpdate();
        }
    }
}
