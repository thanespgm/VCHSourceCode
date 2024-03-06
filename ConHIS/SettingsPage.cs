using ConHIS.Properties;
using System;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class SettingsPage : Form
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            GeneralPage gn = new GeneralPage();
            this.LoadPageSettins(gn);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void LoadPageSettins(UserControl ucl)
        {
            if (this.pnSpace != null)
            {
                ucl.Dock = DockStyle.Fill;
                this.pnSpace.Controls.Clear();
                this.pnSpace.Controls.Add(ucl);
            }
            else
            {
                ucl.Dock = DockStyle.Fill;
                this.pnSpace.Controls.Add(ucl);
            }
        }

        private void SaveSettings()
        {
            Settings.Default.onStartLoadtext = Variable.OnStartTextFile;
            Settings.Default.Save();
            this.Close();
        }

        private void Tv_MenuSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (this.tv_MenuSettings.SelectedNode.Name)
            {
                case "n_general":
                    this.gbPanel.Text = "ทั่วไป";
                    GeneralPage gn = new GeneralPage();
                    this.LoadPageSettins(gn);
                    break;

                case "n_database":
                    this.gbPanel.Text = "ฐานข้อมูลของโปรแกรม";
                    DatabaSepage db = new DatabaSepage();
                    this.LoadPageSettins(db);
                    break;

                case "n_pathfile":
                    this.gbPanel.Text = "ที่อยู่จัดเก็บไฟล์ข้อมูล";
                    PathFilePage pf = new PathFilePage();
                    this.LoadPageSettins(pf);
                    break;
            }
        }
    }
}