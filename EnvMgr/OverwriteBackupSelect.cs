using Dapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class OverwriteBackupSelect : Form
    {
        private Form1 _form1;
        public OverwriteBackupSelect(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void LoadDatabases()
        {
            List<string> runningSQLServer = SQLManagement.GetRunningSQLServers();
            if (runningSQLServer.Count > 1)
            {
                MessageBox.Show("There are multiple sql servers running. Please stop any sql servers not being used. Environment Manager will target the remaining running sql server.");
                return;
            }
            if (runningSQLServer.Count == 0)
            {
                MessageBox.Show("There are no sql servers running. Please start a sql server and try again.");
                return;
            }
            foreach (string server in runningSQLServer)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + ";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                    var sqlQuery = sqlCon.Query<string>("SELECT NAME FROM sys.databases WHERE NAME NOT IN ('master','tempdb','model','msdb')").AsList();
                    lbDatabaseFiles.Items.Clear();
                    foreach (string database in sqlQuery)
                    {
                        lbDatabaseFiles.Items.Add(database);
                    }
                }
                catch (Exception sqlError)
                {
                    string errorMessage = "There was an error retrieving the existing databases.";
                    ExceptionHandling.LogException(sqlError.ToString(), errorMessage);
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void LoadBackupFiles()
        {
            lbExistingDatabases.Items.Clear();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbPath = Convert.ToString(key.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + Form1.dbToOverwrite;
            string[] backupFiles = Directory.GetFiles(dbPath, "*.bak");
            foreach (string file in backupFiles)
            {
                lbExistingDatabases.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void OverwriteDatabases(string[] databases, string path, string bakName, string bakDescription)
        {
            _form1.DisableDBControls(false);
            List<string> runningSQLServer = SQLManagement.GetRunningSQLServers();
            if (runningSQLServer.Count > 1)
            {
                MessageBox.Show("There are multiple sql servers running. Please stop any sql servers not being used. Environment Manager will target the remaining running sql server.");
                return;
            }
            if (runningSQLServer.Count == 0)
            {
                MessageBox.Show("There are no sql servers running. Please start a sql server and try again.");
                return;
            }
            foreach (string server in runningSQLServer)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + ";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                    foreach (string db in databases)
                    {
                        string sqlScript = @"BACKUP DATABASE " + db + @" TO DISK='" + path + "\\" + db + ".bak' WITH INIT";
                        SqlDataAdapter overwriteDB = new SqlDataAdapter(sqlScript, sqlCon);
                        DataTable overwriteDbTab = new DataTable();
                        overwriteDB.Fill(overwriteDbTab);

                        using (StreamWriter sw = File.AppendText(path + @"\Description.txt"))
                        {
                            sw.WriteLine("===============================================================================");
                            sw.WriteLine("BACKUP - " + bakName);
                            sw.WriteLine(DateTime.Now);
                            sw.WriteLine(bakDescription);
                        }
                        using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
                        {
                            sw.WriteLine("{" + DateTime.Now + "} - OVERWROTE: " + bakName);
                        }
                        string message = "Backup \"" + Form1.dbToCreate + "\" was overwritten successfully.";
                        string caption = "COMPLETE";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Exclamation;
                        DialogResult Result;

                        Result = MessageBox.Show(message, caption, button, icon);
                        _form1.DisableDBControls(true);
                        this.Close();
                        return;
                    }
                }
                catch (Exception error)
                {
                    string errorMessage = "An exception was encountered while attempting to overwrite \"" + bakName + "\".";
                    ExceptionHandling.LogException(error.ToString(), errorMessage);
                    MessageBox.Show(errorMessage);
                    return;
                }
            }
        }

        private void OverwriteBackupSelect_Load(object sender, EventArgs e)
        {
            LoadDatabases();
            LoadBackupFiles();
            return;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbExistingDatabases.Items.Count == 0)
            {
                MessageBox.Show("Please select a database or databases to overwrite with.");
                return;
            }
            string backupDescription = tbDescription.Text;
            List<string> selectedDatabases = new List<string>();
            foreach (string database in lbExistingDatabases.SelectedItems)
            {
                selectedDatabases.Add(database);
            }
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string path = Convert.ToString(key.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + Form1.dbToOverwrite + "\\";
            foreach (string database in lbExistingDatabases.SelectedItems)
            {
                string filePath = path + database;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            Thread overProcess = new Thread(() => OverwriteDatabases(selectedDatabases.ToArray(), path, Form1.dbToOverwrite, backupDescription));
            overProcess.Start();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
