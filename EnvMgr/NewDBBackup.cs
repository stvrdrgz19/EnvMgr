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
    public partial class NewDBBackup : Form
    {
        private Form1 _form1;
        public static bool stopProcess = false;

        public NewDBBackup(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public void NewBackupThread(string dynamicsScript, string nonMBScript, string mbScript, string dbPath, string bakName, string bakDescription)
        {
            _form1.DisableDBControls(false);
            try
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
                        Directory.Delete(dbPath, true);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Failed deleting the selected db backup " + dbPath + "\n\n" + e1);
                        return;
                    }
                    try
                    {
                        Directory.CreateDirectory(dbPath);
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("Failed creating the following directory " + dbPath + "\n\n" + e2);
                        return;
                    }
                    SqlConnection sqlCon = new SqlConnection(@"Data Source=" + Environment.MachineName + "\\" + server + @";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                    SqlDataAdapter restoreDynScript = new SqlDataAdapter(dynamicsScript, sqlCon);
                    DataTable restoreDynTable = new DataTable();
                    restoreDynScript.Fill(restoreDynTable);

                    SqlDataAdapter restoreNonMBScript = new SqlDataAdapter(nonMBScript, sqlCon);
                    DataTable restoreNonMBTable = new DataTable();
                    restoreNonMBScript.Fill(restoreNonMBTable);

                    SqlDataAdapter restoreMBScript = new SqlDataAdapter(mbScript, sqlCon);
                    DataTable restoreMBTable = new DataTable();
                    restoreMBScript.Fill(restoreMBTable);
                }
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
                }
                if (errorResult == DialogResult.No)
                {
                    _form1.DisableDBControls(true);
                }
                return;
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
            string newMessage = "Backup \"" + bakName + "\" was created successfully.";
            string newCaption = "COMPLETE";
            MessageBoxButtons newButtons = MessageBoxButtons.OK;
            MessageBoxIcon newIcon = MessageBoxIcon.Exclamation;
            DialogResult newResult;

            newResult = MessageBox.Show(newMessage, newCaption, newButtons, newIcon);

            _form1.DisableDBControls(true);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string backupName = tbDatabaseName.Text;
            string backupDescription = tbDatabaseDescription.Text;
            if (String.IsNullOrWhiteSpace(backupName))
            {
                MessageBox.Show("Please enter a Database name for your backup!");
                return;
            }
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder"));

            if (Directory.Exists(dbFolderPath + Form1.selectedGPVersion + "\\" + backupName))
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

            RegistryKey key2 = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbPath = Convert.ToString(key2.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + backupName;
            string dynamicsDB = Convert.ToString(key2.GetValue("Dynamics Database"));
            string nonMBDB = Convert.ToString(key2.GetValue("Non-MB Database"));
            string mbDB = Convert.ToString(key2.GetValue("MB Database"));
            string dynamicsScript = @"BACKUP DATABASE " + dynamicsDB + @" TO DISK='" + dbPath + "\\" + dynamicsDB + ".bak' WITH INIT";
            string nonMBScript = @"BACKUP DATABASE " + nonMBDB + @" TO DISK='" + dbPath + "\\" + nonMBDB + ".bak' WITH INIT";
            string mbScript = @"BACKUP DATABASE " + mbDB + @" TO DISK='" + dbPath + "\\" + mbDB + ".bak' WITH INIT";
            Directory.CreateDirectory(dbPath);
            this.Close();

            Thread newDBBak = new Thread(() => NewBackupThread(dynamicsScript, nonMBScript, mbScript, dbPath, backupName, backupDescription));
            newDBBak.Start();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
