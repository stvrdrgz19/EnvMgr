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
    public partial class RestoreDB : Form
    {
        private Form1 _form1;
        public RestoreDB(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public void RestoreDatabase(string[] selectedFiles, string filePath, string backupName)
        {
            _form1.DisableDBControls(false);
            _form1.DisableSQLControls(false);
            List<string> runningSQLServer = SQLManagement.GetRunningSQLServers();
            if (runningSQLServer.Count > 1)
            {
                MessageBox.Show("There are multiple sql servers running. Please stop any sql servers not being used. Environment Manager will target the remaining running sql server.");
                _form1.DisableDBControls(true);
                _form1.DisableSQLControls(true);
                return;
            }
            if (runningSQLServer.Count == 0)
            {
                MessageBox.Show("There are no sql servers running. Please start a sql server and try again.");
                _form1.DisableDBControls(true);
                _form1.DisableSQLControls(true);
                return;
            }
            foreach (string server in runningSQLServer)
            {
                try
                {
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + @";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                    foreach (string file in selectedFiles)
                    {
                        string restoreScript = @"ALTER DATABASE " + file + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " + file + " FROM DISK='" + filePath + "\\" + file + ".bak' WITH FILE = 1, NOUNLOAD, REPLACE; ALTER DATABASE " + file + " SET MULTI_USER;";
                        try
                        {
                            SqlDataAdapter restoreDynScript = new SqlDataAdapter(restoreScript, sqlCon);
                            DataTable restoreDynTable = new DataTable();
                            restoreDynScript.Fill(restoreDynTable);
                        }
                        catch (Exception restoreError)
                        {
                            string errorMessage = "There was an error restoring \"" + file + "\".";
                            ExceptionHandling.LogException(restoreError.ToString(), errorMessage);
                            MessageBox.Show(errorMessage);
                            _form1.DisableDBControls(true);
                            _form1.DisableSQLControls(true);
                            return;
                        }
                    }
                }
                catch (Exception sqlConnectionError)
                {
                    string errorMessage = "Could not connect to the SQL Server. Please verify your SQL Server is running and try again.";
                    ExceptionHandling.LogException(sqlConnectionError.ToString(), errorMessage);
                    MessageBox.Show(errorMessage);
                    _form1.DisableDBControls(true);
                    _form1.DisableSQLControls(true);
                    return;
                }
            }

            using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
            {
                sw.WriteLine("{" + DateTime.Now + "} - RESTORED: " + backupName);
            }
            string message = "Backup \"" + backupName + "\" was successfully restored.";
            string caption = "COMPLETE";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            _form1.DisableDBControls(true);
            _form1.DisableSQLControls(true);
        }

        private void RestoreDB_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + Form1.dbToRestore;
            string[] selectedBackup = Directory.GetFiles(dbFolderPath);
            foreach (string file in selectedBackup)
            {
                if (file.Contains(".bak"))
                {
                    lbDatabaseList.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string filePath = Convert.ToString(key.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + Form1.dbToRestore;
            string backupName = Form1.dbToRestore;

            if (lbDatabaseList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one backup file to restore");
                return;
            }

            List<string> listOfSelectedFiles = new List<string>();
            foreach (var file in lbDatabaseList.SelectedItems)
            {
                listOfSelectedFiles.Add(file.ToString());
            }

            Thread executeRestore = new Thread(() => RestoreDatabase(listOfSelectedFiles.ToArray(), filePath, backupName));
            executeRestore.Start();
            this.Close();
            return;
        }
    }
}
