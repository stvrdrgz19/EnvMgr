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
    public partial class OverwriteBackup : Form
    {
        private Form1 _form1;
        public OverwriteBackup(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public void OverwriteDBThread(string dynamicsScript, string nonMBScript, string mbScript, string dbPath, string sqlServ, string sqlUser, string sqlPassword)
        {
            try
            {
                _form1.DisableDBControls(false);

                string bakDescription = tbDBBackupDescription.Text;

                SqlConnection sqlCon = new SqlConnection(@"Data Source=" + sqlServ + @";Initial Catalog=MASTER;User ID=" + sqlUser + @";Password=" + sqlPassword + @";");

                SqlDataAdapter restoreDynScript = new SqlDataAdapter(dynamicsScript, sqlCon);
                DataTable restoreDynTable = new DataTable();
                restoreDynScript.Fill(restoreDynTable);

                SqlDataAdapter restoreNonMBScript = new SqlDataAdapter(nonMBScript, sqlCon);
                DataTable restoreNonMBTable = new DataTable();
                restoreNonMBScript.Fill(restoreNonMBTable);

                SqlDataAdapter restoreMBScript = new SqlDataAdapter(mbScript, sqlCon);
                DataTable restoreMBTable = new DataTable();
                restoreMBScript.Fill(restoreMBTable);

                using (StreamWriter sw = File.AppendText(dbPath + @"\Description.txt"))
                {
                    sw.WriteLine("===============================================================================");
                    sw.WriteLine("BACKUP - " + Form1.dbToCreate);
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(bakDescription);
                }
                using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
                {
                    sw.WriteLine("{" + DateTime.Now + "} - OVERWROTE: " + Form1.dbToCreate);
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
            catch (Exception x1)
            {
                MessageBox.Show("There was an exception preforming the backup SQL \n\n" + x1);
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string bakDescription = tbDBBackupDescription.Text;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbPath = Convert.ToString(key.GetValue("DB Folder")) + Form1.selectedGPVersion + "\\" + Form1.dbToCreate;
            string sqlServ = Convert.ToString(key.GetValue("SQL Server Name"));
            string sqlUser = Convert.ToString(key.GetValue("SQL Username"));
            string sqlPassword = Convert.ToString(key.GetValue("SQL Password"));
            string dynamicsDB = Convert.ToString(key.GetValue("Dynamics Database"));
            string nonMBDB = Convert.ToString(key.GetValue("Non-MB Database"));
            string mbDB = Convert.ToString(key.GetValue("MB Database"));
            string dynamicsScript = @"BACKUP DATABASE " + dynamicsDB + @" TO DISK='" + dbPath + "\\" + dynamicsDB + ".bak' WITH INIT";
            string nonMBScript = @"BACKUP DATABASE " + nonMBDB + @" TO DISK='" + dbPath + "\\" + nonMBDB + ".bak' WITH INIT";
            string mbScript = @"BACKUP DATABASE " + mbDB + @" TO DISK='" + dbPath + "\\" + mbDB + ".bak' WITH INIT";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=" + sqlServ + @";Initial Catalog=MASTER;User ID=" + sqlUser + @";Password=" + sqlPassword + @";");

            try
            {
                sqlCon.Open();
            }
            catch (SqlException)
            {
                string errorMessage = "Unable to overwrite the selected database! Please check that your SQL Server is running and try again.";
                string errorCaption = "ERROR OVERWRITING";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                this.Close();
                return;
            }

            try
            {
                Directory.Delete(dbPath, true);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Failed deleting the selected db backup " + dbPath + "\n\n" + e1);
            }
            try
            {
                Directory.CreateDirectory(dbPath);
            }
            catch (Exception e2)
            {
                MessageBox.Show("Failed creating the following directory " + dbPath + "\n\n" + e2);
            }

            Thread overProcess = new Thread(() => OverwriteDBThread(dynamicsScript, nonMBScript, mbScript, dbPath, sqlServ, sqlUser, sqlPassword));
            overProcess.Start();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
