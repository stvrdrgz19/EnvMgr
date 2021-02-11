using Dapper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class NewDBBackupSelect : Form
    {
        private Form1 _form1;
        public static bool stopProcess = false;
        public static string selectedGPVersion = "";

        public NewDBBackupSelect(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public void NewBackupThread(string dbPath, string[] selectedDBList, string bakName, string bakDescription)
        {
            _form1.DisableDBControls(false);
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
                foreach (string db in selectedDBList)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + @";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                        string backupScript = @"BACKUP DATABASE " + db + @" TO DISK='" + dbPath + "\\" + db + ".bak' WITH INIT";
                        SqlDataAdapter sqlBackup = new SqlDataAdapter(backupScript, sqlCon);
                        DataTable sqlBackupTable = new DataTable();
                        sqlBackup.Fill(sqlBackupTable);
                    }
                    catch (SqlException e)
                    {
                        Directory.Delete(dbPath, true);
                        stopProcess = true;

                        string errorMessage = "There was an error creating a new Database Backup. \n\nWould you like to view the exception?";
                        string errorCaption = "ERROR";
                        MessageBoxButtons errorButton = MessageBoxButtons.YesNo;
                        MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                        DialogResult errorResult;

                        errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                        this.Close();

                        if (errorResult == DialogResult.Yes)
                        {
                            _form1.DisableDBControls(true);
                            MessageBox.Show(Convert.ToString(e));
                            return;
                        }
                        if (errorResult == DialogResult.No)
                        {
                            _form1.DisableDBControls(true);
                            return;
                        }
                    }
                }
            }

            using (StreamWriter sw = File.AppendText(dbPath + @"\Description.txt"))
            {
                sw.WriteLine("===============================================================================");
                sw.WriteLine("BACKUP - " + bakName);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(bakDescription);
            }

            using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
            {
                sw.WriteLine("{" + DateTime.Now + "} - CREATED: " + bakName);
            }

            //Zip DB Folder
            ZipFile.CreateFromDirectory(dbPath, dbPath + ".zip");
            //Delete dbPath
            Directory.Delete(dbPath, true);

            string newMessage = "Backup \"" + bakName + "\" was created successfully.";
            string newCaption = "COMPLETE";
            MessageBoxButtons newButtons = MessageBoxButtons.OK;
            MessageBoxIcon newIcon = MessageBoxIcon.Exclamation;
            DialogResult newResult;

            newResult = MessageBox.Show(newMessage, newCaption, newButtons, newIcon);

            _form1.DisableDBControls(true);
        }

        private void LoadDatabaseList()
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
                SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + ";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                var databaseList = sqlCon.Query<string>("SELECT name FROM sys.databases WHERE name NOT IN ('master','tempdb','model','msdb')").AsList();
                foreach (string database in databaseList)
                {
                    lbDatabases.Items.Add(database);
                }
            }
        }

        private void NewDBBackupSelect_Load(object sender, EventArgs e)
        {
            LoadDatabaseList();
            return;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string backupName = tbDBName.Text;
            string backupDescription = tbDBDescription.Text;
            // Check to make sure the user entered a database backup name
            if (String.IsNullOrWhiteSpace(backupName))
            {
                MessageBox.Show("Please enter a Database name for your backup!");
                return;
            }
            // Check to make sure the user has databases selected to backup
            if (lbDatabases.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Database to backup.");
                return;
            }
            // Ask the user if they're sure they want to backup the selected databases.
            List<string> dbList = new List<string>();
            StringBuilder databaseList = new StringBuilder();
            foreach (string db in lbDatabases.SelectedItems)
            {
                dbList.Add(db);
            }
            foreach (string dbx in dbList)
            {
                databaseList.Append(dbx.ToString()).AppendLine();
            }
            string message = "Are you sure you want to backup the selected databases?\n\n" + databaseList.ToString();
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.No)
            {
                return;
            }
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder"));
            string dbPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGPVersion + "\\" + backupName;
            //string sqlServ = Convert.ToString(key.GetValue("SQL Server Name"));
            //string sqlUser = Convert.ToString(key.GetValue("SQL Username"));
            //string sqlPassword = Convert.ToString(key.GetValue("SQL Password"));

            if (Directory.Exists(dbPath))
            {
                MessageBox.Show("A backup called \"" + backupName + "\" already exists! Please enter a unique backup name to continue.");
                return;
            }

            List<string> listOfBadChars = new List<string>();
            StringBuilder builder = new StringBuilder();
            string badChars = @"\,/,:,*,?,"",<,>,|";
            string[] badCharsSplit = badChars.Split(',');
            foreach (string character in badCharsSplit)
            {
                if (backupName.Contains(character))
                {
                    listOfBadChars.Add(character);
                }
            }
            foreach (string str in listOfBadChars)
            {
                builder.Append(str.ToString()).AppendLine();
            }
            if (listOfBadChars.Count > 0)
            {
                string Message = "The following invalid characters are in the Database Backup name and are invalid. Please remove them: \n\n" + builder.ToString();
                string Caption = "";
                MessageBoxButtons Button = MessageBoxButtons.OK;
                MessageBoxIcon Icon = MessageBoxIcon.Error;
                DialogResult Result;

                Result = MessageBox.Show(Message, Caption, Button, Icon);
                return;
            }
            Directory.CreateDirectory(dbPath);
            List<string> listOfSelectedDBs = new List<string>();
            foreach (var database in lbDatabases.SelectedItems)
            {
                listOfSelectedDBs.Add(database.ToString());
            }
            Thread executeBackup = new Thread(() => NewBackupThread(dbPath, listOfSelectedDBs.ToArray(), backupName, backupDescription));
            executeBackup.Start();
            this.Close();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }
    }
}
