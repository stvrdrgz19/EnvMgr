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
    public partial class OverwriteBackup : Form
    {
        private Form1 _form1;
        public OverwriteBackup(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public static string selectedGPVersion = "";
        public static string dbToCreate = "";

        public void OverwriteDBThread(string dynamicsScript, string nonMBScript, string mbScript, string dbPath)
        {
            try
            {
                _form1.DisableDBControls(false);

                string bakDescription = tbDBBackupDescription.Text;

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
                        //Directory.Delete(dbPath, true);
                        File.Delete(dbPath + ".zip");
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
                using (StreamWriter sw = File.AppendText(dbPath + @"\Description.txt"))
                {
                    sw.WriteLine("===============================================================================");
                    sw.WriteLine("BACKUP - " + dbToCreate);
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(bakDescription);
                }
                using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
                {
                    sw.WriteLine("{" + DateTime.Now + "} - OVERWROTE: " + dbToCreate);
                }

                ZipFile.CreateFromDirectory(dbPath, dbPath + ".zip");

                string message = "Backup \"" + dbToCreate + "\" was overwritten successfully.";
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
            string dbPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGPVersion + "\\" + dbToCreate;
            string dynamicsDB = Convert.ToString(key.GetValue("Dynamics Database"));
            string nonMBDB = Convert.ToString(key.GetValue("Non-MB Database"));
            string mbDB = Convert.ToString(key.GetValue("MB Database"));
            string dynamicsScript = @"BACKUP DATABASE " + dynamicsDB + @" TO DISK='" + dbPath + "\\" + dynamicsDB + ".bak' WITH INIT";
            string nonMBScript = @"BACKUP DATABASE " + nonMBDB + @" TO DISK='" + dbPath + "\\" + nonMBDB + ".bak' WITH INIT";
            string mbScript = @"BACKUP DATABASE " + mbDB + @" TO DISK='" + dbPath + "\\" + mbDB + ".bak' WITH INIT";

            Thread overProcess = new Thread(() => OverwriteDBThread(dynamicsScript, nonMBScript, mbScript, dbPath));
            overProcess.Start();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
