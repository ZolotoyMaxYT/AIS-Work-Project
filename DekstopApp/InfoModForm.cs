using BussinesLogic;
using System;
using System.Windows.Forms;

namespace DekstopApp
{
    public partial class InfoModForm : Form
    {
        MainForm Mainform;
        string Mod;

        private void FormUpdate()
        {
            Mainform.Database.Read(Mod, out var mod);
            TitleText.Text = $"[{mod["Id"]}] {mod["Name"]}";
            AuthorText.Text = (string)mod["Author"];
            RankText.Text = ((int)mod["Rank"]).ToString();
            TypeText.Text = (bool)mod["IsJavaMod"] ? "Java Mod" : "Bedrock Mod";
            VersionText.Text = mod["Version"].ToString();
            DescriptionText.Text = ((string)mod["Description"]).Replace("\n", Environment.NewLine);
            ModpackText.Text = string.Join(Environment.NewLine, (List<string>)mod["ModPacks"]);
        }

        public InfoModForm(MainForm mainform, string mod)
        {
            InitializeComponent();
            Mainform = mainform;
            Mod = mod;
            FormUpdate();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            new EditModForm(Mainform, Mod).ShowDialog();
            FormUpdate();
            Mainform.MenuUpdate();
        }
    }
}
