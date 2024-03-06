using System;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class PathFilePage : UserControl
    {
        //Variable And Objects

        private Pathfile_config p = new Pathfile_config();

        //Constuctor
        public PathFilePage()
        {
            InitializeComponent();
        }

        //Event Form
        private void PathFilePage_Load(object sender, EventArgs e)
        {
            if (p.CheckDictoryFileConfig() == false)
            {
                this.LoadDefaultForm();
            }
            else
            {
                this.LoadPathFileConfig();
            }
        }

        //function Browse for Folder path
        private string BrowseForFolderPath(string description)
        {
            string result = "";
            try
            {
                FolderBrowserDialog folderBrowSepath = new FolderBrowserDialog
                {
                    Description = description
                };
                if (folderBrowSepath.ShowDialog() == DialogResult.OK)
                {
                    result = folderBrowSepath.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return result;
        }

        //function load default form
        private void LoadDefaultForm()
        {
            this.tbPathSourceLocation.Text = @"C:\ConHIS_Interfrace\";
            this.tbPathDestinationLocation.Text = @"C:\ConHIS_Interfrace\ConHIS_Text\";
            this.tbPathLogs.Text = @"C:\ConHIS_Interfrace\Logs\";
            this.tbPathProgramBackup.Text = @"C:\ConHIS_Interfrace\Program_Backup\";
            this.tbPathDatabaseBackup.Text = @"C:\ConHIS_Interfrace\Database_Backup\";
        }

        //function Path File load
        private void LoadPathFileConfig()
        {
            try
            {
                if (p.ReadPathfile_config() == true)
                {
                    this.tbPathSourceLocation.Text = p.PathFileHost;
                    this.tbPathDestinationLocation.Text = p.PathFileLocal;
                    this.tbPathLogs.Text = p.PathLogFile;
                    this.tbPathProgramBackup.Text = p.PathProgramBackUp;
                    this.tbPathDatabaseBackup.Text = p.PathDatabaseBackUp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event Browse Button
        private void BtnBrowSepathSource_Click(object sender, EventArgs e)
        {
            this.tbPathSourceLocation.Text = this.BrowseForFolderPath("Source Location Path");
            p.PathFileHost = this.tbPathSourceLocation.Text.Trim() + @"\";
            p.WritedPathfile_config();
        }

        private void BtnBrowSepathDestination_Click(object sender, EventArgs e)
        {
            this.tbPathDestinationLocation.Text = this.BrowseForFolderPath("Destination Location Path");
            p.PathFileLocal = this.tbPathDestinationLocation.Text.Trim() + @"\";
            p.WritedPathfile_config();
        }

        private void BtnBrowSepathLogs_Click(object sender, EventArgs e)
        {
            this.tbPathLogs.Text = this.BrowseForFolderPath("Logs System Location Path");
            p.PathLogFile = this.tbPathLogs.Text.Trim() + @"\";
            p.WritedPathfile_config();
        }

        private void BtnBrowSeprogramPathBackup_Click(object sender, EventArgs e)
        {
            this.tbPathProgramBackup.Text = this.BrowseForFolderPath("Program Backup Location Path");
            p.PathProgramBackUp = this.tbPathProgramBackup.Text.Trim() + @"\";
            p.WritedPathfile_config();
        }

        private void BtnBrowseDatabaSepathBackup_Click(object sender, EventArgs e)
        {
            this.tbPathDatabaseBackup.Text = this.BrowseForFolderPath("Database Backup Loaction Path");
            p.PathDatabaseBackUp = this.tbPathDatabaseBackup.Text.Trim() + @"\";
            p.WritedPathfile_config();
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            this.LoadDefaultForm();
            p.WritedPathfile_config();
        }
    }
}