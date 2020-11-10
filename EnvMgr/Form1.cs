using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string dbDescLine1 = "===============================================================================";
        public static string dbDescLine2 = "=================== SELECTED DATABASE HAS NO DESCRIPTION ==================";
        public static string dbDescDefault = dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine2 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1 + "\n" + dbDescLine1;
        public static string gpInstallFolder = @"C:\Program Files (x86)\Microsoft Dynamics\";
        public static string sqlServer2012 = @"MSSQL$SQLSERVER2012";
        public static string sqlServer2014 = @"MSSQL$SQLSERVER2014";
        public static string sqlServer2016 = @"MSSQL$SQLSERVER2016";
        public static string sqlServer2017 = @"MSSQL$SQLSERVER2017";
        public static string sqlServer2019 = @"MSSQL$SQLSERVER2019";
        public static string dbToCreate = "";
        public static string selectedGPVersion = "";
        public static string selectedInstallProduct = "";
        public static string selectedProductVersion = "";
        public static string fullInstallerPath = "";
        public static string SPGPFilePath = "";
        public static string ProductFilePath = "";
        public static string ProductFileName = "";

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found:\n\n" + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void LoadInstalledGPList()
        {
            lbGPVersionsInstalled.Items.Clear();
            string[] gpFolders = Directory.GetDirectories(gpInstallFolder);
            foreach (string folder in gpFolders)
            {
                if (folder.Remove(0, gpInstallFolder.Length) != "Business Analyzer")
                {
                    lbGPVersionsInstalled.Items.Add(folder.Remove(0, gpInstallFolder.Length));
                }
            }
        }

        public static string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                localIP = ip.ToString();
            }
            return localIP;
        }

        private void SetIPAddress()
        {
            tbIPAddress.Text = GetLocalIPAddress();
        }

        public static string IsMFGEnabled(string gpVersionToCopy, bool tf)
        {
            string returnVal = "";
            if (tf == true)
            {
                returnVal = "Are you sure you want to install " + gpVersionToCopy + " with Manufacturing?";
            }
            if (tf == false)
            {
                returnVal = "Are you sure you want to install " + gpVersionToCopy + "?";
            }
            return returnVal;
        }

        public void InstallDynamics(string gpVersionToCopy, bool mfg)
        {
            if (mfg == true)
            {
                gpVersionToCopy += "Manufacturing";
            }
            string installDirectory = "C:\\Program Files (X86)\\Microsoft Dynamics\\" + gpVersionToCopy;
            string sourceDir = "\\\\sp-fileserv-01\\Shares\\Autotesting\\VM Setup\\Microsoft Dynamics\\" + gpVersionToCopy;
            try
            {
                DisableGPControls(false);
                DirectoryCopy(sourceDir, installDirectory, true);
            }
            catch (Exception e)
            {
                DisableGPControls(true);
                string exceptionMessage = "There was an issue copying " + gpVersionToCopy;
                throw new Exception(exceptionMessage, e);
            }
            DisableGPControls(true);
            LoadInstalledGPList();
        }

        public void DisableGPControls(bool tf)
        {
            checkManufacturingToggle.Enabled = tf;
            cbGPListToInstall.Enabled = tf;
            btnInstallGP.Enabled = tf;
        }

        public void DisableSQLControls(bool tf)
        {
            btnStartService.Enabled = tf;
            btnStopService.Enabled = tf;
            btnInstallService.Enabled = tf;
            btnStopAllServices.Enabled = tf;
        }

        public void DisableDBControls(bool tf)
        {
            btnRestoreDB.Enabled = tf;
            btnOverwriteDB.Enabled = tf;
            btnNewDB.Enabled = tf;
            btnDeleteBackup.Enabled = tf;
        }

        public void DisableInstallButton(bool tf)
        {
            btnInstallProduct.Enabled = tf;
            return;
        }

        private void LoadDatabaseList()
        {
            cbDatabaseList.Items.Clear();
            cbDatabaseList.Text = "Select a Database";
            tbDBDesc.Text = dbDescDefault;
            string selectedGP = cbSelectedGP.Text;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP;
            if (!Directory.Exists(dbFolderPath))
            {
                cbDatabaseList.Items.Clear();
                cbDatabaseList.Text = "Select a Database";
                tbDBDesc.Text = dbDescDefault;
                return;
            }
            try
            {
                string[] dbFolders = Directory.GetDirectories(dbFolderPath);
                foreach (string folder in dbFolders)
                {
                    cbDatabaseList.Items.Add(folder.Remove(0, dbFolderPath.Length + 1));
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void LoadDatabaseDescription(string database)
        {
            string selectedGP = cbSelectedGP.Text;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP;
            string dbDescription = File.ReadAllText(dbFolderPath + "\\" + database + @"\Description.txt");
            tbDBDesc.Text = dbDescription;
        }

        public List<string> InstalledSQLServers()
        {
            List<string> sqlServerList = new List<string>();
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        sqlServerList.Add(instanceName);
                    }
                }
            }
            return sqlServerList;
        }

        public List<string> GetServiceList()
        {
            List<string> listOfSQLServices = new List<string>();
            listOfSQLServices.Add("MSSQL$SQLSERVER2012");
            listOfSQLServices.Add("MSSQL$SQLSERVER2014");
            listOfSQLServices.Add("MSSQL$SQLSERVER2016");
            listOfSQLServices.Add("MSSQL$SQLSERVER2017");
            listOfSQLServices.Add("MSSQL$SQLSERVER2019");
            return listOfSQLServices;
        }

        public static string IsServiceRunning(string serviceName)
        {
            string varOutput = "NOT RUNNING";
            ServiceController selectedService = new ServiceController(serviceName);
            try
            {
                if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                {
                    varOutput = "RUNNING";
                }
            }
            catch
            {
                varOutput = "NOT INSTALLED";
            }
            return varOutput;
        }

        private void StartSQLServer(string service)
        {
            string serviceToSend = "";
            //StopAllServices();
            if (service == "SQLSERVER2012")
            {
                serviceToSend = sqlServer2012;
            }
            if (service == "SQLSERVER2014")
            {
                serviceToSend = sqlServer2014;
            }
            if (service == "SQLSERVER2016")
            {
                serviceToSend = sqlServer2016;
            }
            if (service == "SQLSERVER2017")
            {
                serviceToSend = sqlServer2017;
            }
            if (service == "SQLSERVER2019")
            {
                serviceToSend = sqlServer2019;
            }

            ServiceController serviceToStart = new ServiceController(serviceToSend);
            try
            {
                if (!serviceToStart.Status.Equals(ServiceControllerStatus.Running))
                {
                    serviceToStart.Start();
                    serviceToStart.WaitForStatus(ServiceControllerStatus.Running);
                }
            }
            catch (Exception e)
            {
                string message = e.ToString();
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
            }
        }

        public void LoadSQLServerListView()
        {
            lvInstalledSQLServers.Items.Clear();

            string val2012 = IsServiceRunning("MSSQL$SQLSERVER2012");
            string val2014 = IsServiceRunning("MSSQL$SQLSERVER2014");
            string val2016 = IsServiceRunning("MSSQL$SQLSERVER2016");
            string val2017 = IsServiceRunning("MSSQL$SQLSERVER2017");
            string val2019 = IsServiceRunning("MSSQL$SQLSERVER2019");


            ListViewItem item1 = new ListViewItem("SQLSERVER2012");
            switch (val2012)
            {
                case "NOT INSTALLED":
                    item1.ForeColor = Color.Gray;
                    item1.Font = new Font(this.Font, FontStyle.Italic);
                    break;
                case "NOT RUNNING":
                    item1.ForeColor = Color.Gray;
                    break;
                case "RUNNING":
                    item1.ForeColor = Color.Green;
                    item1.Font = new Font(this.Font, FontStyle.Bold);
                    break;
            }
            item1.SubItems.Add(val2012);
            ListViewItem item2 = new ListViewItem("SQLSERVER2014");
            switch (val2014)
            {
                case "NOT INSTALLED":
                    item2.ForeColor = Color.Gray;
                    item2.Font = new Font(this.Font, FontStyle.Italic);
                    break;
                case "NOT RUNNING":
                    item2.ForeColor = Color.Gray;
                    break;
                case "RUNNING":
                    item2.ForeColor = Color.Green;
                    item2.Font = new Font(this.Font, FontStyle.Bold);
                    break;
            }
            item2.SubItems.Add(val2014);
            ListViewItem item3 = new ListViewItem("SQLSERVER2016");
            switch (val2016)
            {
                case "NOT INSTALLED":
                    item3.ForeColor = Color.Gray;
                    item3.Font = new Font(this.Font, FontStyle.Italic);
                    break;
                case "NOT RUNNING":
                    item3.ForeColor = Color.Gray;
                    break;
                case "RUNNING":
                    item3.ForeColor = Color.Green;
                    item3.Font = new Font(this.Font, FontStyle.Bold);
                    break;
            }
            item3.SubItems.Add(val2016);
            ListViewItem item4 = new ListViewItem("SQLSERVER2017");
            switch (val2017)
            {
                case "NOT INSTALLED":
                    item4.ForeColor = Color.Gray;
                    item4.Font = new Font(this.Font, FontStyle.Italic);
                    break;
                case "NOT RUNNING":
                    item4.ForeColor = Color.Gray;
                    break;
                case "RUNNING":
                    item4.ForeColor = Color.Green;
                    item4.Font = new Font(this.Font, FontStyle.Bold);
                    break;
            }
            item4.SubItems.Add(val2017);
            ListViewItem item5 = new ListViewItem("SQLSERVER2019");
            switch (val2019)
            {
                case "NOT INSTALLED":
                    item5.ForeColor = Color.Gray;
                    item5.Font = new Font(this.Font, FontStyle.Italic);
                    break;
                case "NOT RUNNING":
                    item5.ForeColor = Color.Gray;
                    break;
                case "RUNNING":
                    item5.ForeColor = Color.Green;
                    item5.Font = new Font(this.Font, FontStyle.Bold);
                    break;
            }
            item5.SubItems.Add(val2019);
            lvInstalledSQLServers.Items.AddRange(new ListViewItem[] { item1, item2, item3, item4, item5 });
        }

        private void InstallSQLServer(string sqlVersion)
        {
            string installerPath = @"\\sp-fileserv-01\Shares\Autotesting\VM Setup\SQL Server Installation";
            string configFile = installerPath + @"\Installation";

            if (sqlVersion == "15")
            {
                MessageBox.Show("SQL Server 2019 isn't yet installable via Environment Manager.");
                return;
            }

            switch (sqlVersion)
            {
                case "9":
                    installerPath += @"\SQL 2005 Express With SP4\SQLEXPR.EXE";
                    configFile += @"\2005 ConfigurationFile.ini";
                    configFile = string.Format("/settings \"{0}\"", configFile);
                    break;
                case "10":
                    installerPath += @"\SQL Server 2008\setup.exe";
                    configFile += @"\2008 ConfigurationFile.ini";
                    configFile = string.Format("/ConfigurationFile=\"{0}\"", configFile);
                    break;
                case "11":
                    installerPath += @"\SQL Server 2012\setup.exe";
                    configFile += @"\2012 ConfigurationFile.ini";
                    configFile = string.Format("/ConfigurationFile=\"{0}\"", configFile);
                    break;
                case "12":
                    installerPath += @"\SQL Server 2014\setup.exe";
                    configFile += @"\2014 ConfigurationFile.ini";
                    configFile = string.Format("/ConfigurationFile=\"{0}\"", configFile);
                    break;
                case "13":
                    installerPath += @"\SQL Server 2016\setup.exe";
                    configFile += @"\2016 ConfigurationFile.ini";
                    configFile = string.Format("/ConfigurationFile=\"{0}\"", configFile);
                    break;
                case "14":
                    installerPath += @"\SQL Server 2017\setup.exe";
                    configFile += @"\2017 ConfigurationFile.ini";
                    configFile = string.Format("/ConfigurationFile=\"{0}\"", configFile);
                    break;
                default:
                    throw new ArgumentException(
                        string.Format(
                            "The given sql version {0} is not supported", sqlVersion));
            }
            try
            {
                Process.Start(installerPath, configFile);
            }
            catch (Win32Exception networkE)
            {
                bool error = ExceptionHandling.LogException(networkE.ToString(), "Error connectiong to Network. No VPN connection established.");
                if (!error)
                {
                    MessageBox.Show("There was an error logging the exception, no crashlog file could be found or generated. There was a problem connecting to the Network. Please ensure you're connected to the VPN and try again.");
                    return;
                }
                string message = "There was a problem connecting to the Network. Please ensure you're connected to the VPN and try again. \n\nWould you like to view the crashlog?";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    Process.Start(Environment.CurrentDirectory + @"\Files\Crashlog.txt");
                }
                return;
            }
            LoadSQLServerListView();
        }

        private void StopAllServices()
        {
            List<string> serviceList = GetServiceList();
            List<string> listOfServicesNotStopped = new List<string>();

            foreach (string service in serviceList)
            {
                ServiceController selectedService = new ServiceController(service);
                try
                {
                    if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                    {
                        selectedService.Stop();
                    }
                }
                catch
                {
                    List<string> installedServices = InstalledSQLServers();
                    if (installedServices.Contains(service))
                    {
                        listOfServicesNotStopped.Add(service);
                    }
                }
            }
            if (listOfServicesNotStopped.Count != 0)
            {
                string sqlServicesNotStopped = string.Join(Environment.NewLine, listOfServicesNotStopped.ToArray());
                string message = "The following SQL Services could not be stopped. Try again, or try manually stopping the service.\n\n" + sqlServicesNotStopped;
                string caption = "ERROR";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, button, icon);
            }
            LoadSQLServerListView();
        }
        public void LaunchBuildFolder(string projInstallPath)
        {
            try
            {
                Process.Start(projInstallPath);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Failed to launch folder, the following path does not exist:\n\n" + projInstallPath);
            }
        }

        private void RemoveSalesPad(string x86Path, string x64Path)
        {
            if (!String.IsNullOrWhiteSpace(x86Path) && Directory.Exists(x86Path))
            {
                string[] foldersx86 = Directory.GetDirectories(x86Path);
                foreach (string dir in foldersx86)
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (Exception ex86)
                    {
                        MessageBox.Show("The following build could not be deleted. It may be running.\n\n" + dir + "\n\nThe error is as follows:" + ex86);
                    }
                }
            }
            if (!String.IsNullOrWhiteSpace(x64Path) && Directory.Exists(x64Path))
            {
                string[] foldersx64 = Directory.GetDirectories(x64Path);
                foreach (string dir in foldersx64)
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (Exception ex64)
                    {
                        MessageBox.Show("The following build could not be deleted. It may be running.\n\n" + dir + "\n\nThe error is as follows:" + ex64);
                    }
                }
            }
        }

        private void RemoveOtherProducts(string buildPath)
        {
            if (!String.IsNullOrWhiteSpace(buildPath) && Directory.Exists(buildPath))
            {
                string[] folders = Directory.GetDirectories(buildPath);
                foreach (string dir in folders)
                {
                    try
                    {
                        Directory.Delete(dir, true);
                    }
                    catch (Exception exPath)
                    {
                        MessageBox.Show("The following build could not be deleted. It may be running.\n\n" + dir + "\n\nThe error is as follows:" + exPath);
                    }
                }
            }
        }

        //================================================================================================================================================
        // DATABASE MANAGEMENT METHODS
        //================================================================================================================================================
        public static bool IsDBSelected(string dbName)
        {
            bool tf = true;
            if (dbName == "Select a Database")
            {
                tf = false;
            }
            if (dbName != "Select a Database")
            {
                tf = true;
            }
            return tf;
        }

        public static bool DoesBackupExist(string dbName)
        {
            //
            bool tf = true;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder"));

            if (Directory.Exists(dbFolderPath + dbName))
            {
                tf = true;
            }
            if (!Directory.Exists(dbFolderPath + dbName))
            {
                tf = false;
            }
            return tf;
        }

        public void RestoreDB(string dbName, string gpVersion)
        {
            DisableDBControls(false);
            DisableSQLControls(false);
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string dbPath = Convert.ToString(key.GetValue("DB Folder")) + gpVersion + "\\" + dbName;
            string sqlServ = Convert.ToString(key.GetValue("SQL Server Name"));
            string sqlUser = Convert.ToString(key.GetValue("SQL Username"));
            string sqlPassword = Convert.ToString(key.GetValue("SQL Password"));
            string dynamicsDB = Convert.ToString(key.GetValue("Dynamics Database"));
            string nonMBDB = Convert.ToString(key.GetValue("Non-MB Database"));
            string mbDB = Convert.ToString(key.GetValue("MB Database"));
            string dynamicsScript = @"ALTER DATABASE " + dynamicsDB + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " + dynamicsDB + " FROM DISK='" + dbPath + "\\" + dynamicsDB + ".bak' WITH FILE = 1, NOUNLOAD, REPLACE; ALTER DATABASE " + dynamicsDB + " SET MULTI_USER;";
            string nonMBScript = @"ALTER DATABASE " + nonMBDB + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " + nonMBDB + " FROM DISK='" + dbPath + "\\" + nonMBDB + ".bak' WITH FILE = 1, NOUNLOAD, REPLACE; ALTER DATABASE " + nonMBDB + " SET MULTI_USER;";
            string mbScript = @"ALTER DATABASE " + mbDB + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " + mbDB + " FROM DISK='" + dbPath + "\\" + mbDB + ".bak' WITH FILE = 1, NOUNLOAD, REPLACE; ALTER DATABASE " + mbDB + " SET MULTI_USER;";

            try
            {
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
            }
            catch (SqlException)
            {
                string errorMessage = "Unable to restore database! Please check that your SQL Server is running and try again.";
                string errorCaption = "ERROR RESTORING";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                DisableDBControls(true);
                DisableSQLControls(true);
                return;
            }

            using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
            {
                sw.WriteLine("{" + DateTime.Now + "} - RESTORED: " + dbName);
            }
            string restoreMessage = "Backup \"" + dbName + "\" was successfully restored.";
            string restoreCaption = "COMPLETE";
            MessageBoxButtons restoreButtons = MessageBoxButtons.OK;
            MessageBoxIcon restoreIcon = MessageBoxIcon.Exclamation;
            DialogResult restoreResult;

            restoreResult = MessageBox.Show(restoreMessage, restoreCaption, restoreButtons, restoreIcon);
            DisableDBControls(true);
            DisableSQLControls(true);
        }
        //================================================================================================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInstalledGPList();
            SetIPAddress();
            tbDBDesc.Text = dbDescDefault;
            LoadSQLServerListView();
            return;
        }

        private void labelGPInstallationList_Click(object sender, EventArgs e)
        {
            LoadInstalledGPList();
            return;
        }

        private void btnLaunchSelectedGP_Click(object sender, EventArgs e)
        {
            string selectedGPFolder = lbGPVersionsInstalled.Text;
            if (String.IsNullOrWhiteSpace(selectedGPFolder))
            {
                return;
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                try
                {
                    Process.Start(gpInstallFolder + selectedGPFolder);
                }
                catch
                {
                    MessageBox.Show("There was an error launching the installed GP folder.");
                }
                return;
            }
            string selectedGP = lbGPVersionsInstalled.Text;
            Process.Start(gpInstallFolder + selectedGP + "\\Dynamics.exe", "\"" + gpInstallFolder + selectedGP + "\\DYNAMICS.SET\"");
            return;
        }

        private void btnLaunchGPUtils_Click(object sender, EventArgs e)
        {
            string selectedGPFolder = lbGPVersionsInstalled.Text;
            if (String.IsNullOrWhiteSpace(selectedGPFolder))
            {
                return;
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                try
                {
                    Process.Start(@"C:\Program Files\Microsoft SQL Server\MSSQL13.SQLSERVER2016\MSSQL\Backup");
                }
                catch
                {
                    MessageBox.Show("There was an error launching the Dynamics Database backup folder.");
                }
                return;
            }
            string selectedGP = lbGPVersionsInstalled.Text;
            Process.Start(gpInstallFolder + selectedGP + "\\DynUtils.exe", "\"" + gpInstallFolder + selectedGP + "\\DYNUTILS.SET\"");
            return;
        }

        private void btnInstallGP_Click(object sender, EventArgs e)
        {
            string gpVersion = cbGPListToInstall.Text;
            bool mfg = checkManufacturingToggle.Checked;
            if (gpVersion == "Select a GP Version to Install")
            {
                return;
            }
            string message = IsMFGEnabled(gpVersion, mfg);

            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, icon);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Thread installGP = new Thread(() => InstallDynamics(gpVersion, mfg));
                installGP.Start();
            }
            return;
        }

        private void labelSQLVersions_Click(object sender, EventArgs e)
        {
            LoadSQLServerListView();
            return;
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            string selectedService = lvInstalledSQLServers.SelectedItems[0].Text;
            string selectedServiceStatus = lvInstalledSQLServers.SelectedItems[0].SubItems[1].Text;
            if (String.IsNullOrWhiteSpace(selectedService))
            {
                return;
            }
            if (selectedServiceStatus == "NOT INSTALLED")
            {
                string message = "The selected Service \"" + selectedService + "\" could not be started because it isn't installed!";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                return;
            }
            DisableSQLControls(false);
            StartSQLServer(selectedService);
            DisableSQLControls(true);
            LoadSQLServerListView();
            return;
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            string selectedService = lvInstalledSQLServers.SelectedItems[0].Text;
            string selectedServiceStatus = lvInstalledSQLServers.SelectedItems[0].SubItems[1].Text;
            if (String.IsNullOrWhiteSpace(selectedService))
            {
                return;
            }
            if (selectedServiceStatus == "NOT INSTALLED")
            {
                string message = "The selected SQL Service \"" + selectedService + "\" is not installed!";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                LoadSQLServerListView();
                return;
            }
            if (selectedServiceStatus == "NOT RUNNING")
            {
                string message = "The selected SQL Service \"" + selectedService + "\" is not running!";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                LoadSQLServerListView();
                return;
            }
            ServiceController serviceToStop = new ServiceController("MSSQL$" + selectedService);
            try
            {
                if (serviceToStop.Status.Equals(ServiceControllerStatus.Running))
                {
                    serviceToStop.Stop();
                }
            }
            catch (Exception serviceException)
            {
                MessageBox.Show("There was an error attempting to stop the service: " + selectedService + "\n\n" + serviceException);
            }
            LoadSQLServerListView();
            return;
        }

        private void btnInstallService_Click(object sender, EventArgs e)
        {
            string selectedService = lvInstalledSQLServers.SelectedItems[0].Text;
            string selectedServiceStatus = lvInstalledSQLServers.SelectedItems[0].SubItems[1].Text;
            if (String.IsNullOrWhiteSpace(selectedService))
            {
                return;
            }
            if (selectedServiceStatus != "NOT INSTALLED")
            {
                string message = "The selected SQL Service \"" + selectedService + "\" is already installed!";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                return;
            }
            string messageConfirm = "Are you sure you want to install \"" + selectedService + "\"? This process can take some time.";
            string captionConfirm = "CONFIRM";
            MessageBoxButtons buttonsConfirm = MessageBoxButtons.YesNo;
            MessageBoxIcon iconConfirm = MessageBoxIcon.Question;
            DialogResult resultConfirm;
            resultConfirm = MessageBox.Show(messageConfirm, captionConfirm, buttonsConfirm, iconConfirm);

            if (resultConfirm == DialogResult.Yes)
            {
                switch (selectedService)
                {
                    case "SQLSERVER2012":
                        selectedService = "11";
                        break;
                    case "SQLSERVER2014":
                        selectedService = "12";
                        break;
                    case "SQLSERVER2016":
                        selectedService = "13";
                        break;
                    case "SQLSERVER2017":
                        selectedService = "14";
                        break;
                    case "SQLSERVER2019":
                        selectedService = "15";
                        break;
                }
                Thread installSQL = new Thread(() => InstallSQLServer(selectedService));
                installSQL.Start();
            }
            return;
        }

        private void btnStopAllServices_Click(object sender, EventArgs e)
        {
            StopAllServices();
            return;
        }

        private void cbSelectedGP_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatabaseList();
            return;
        }

        private void cbDatabaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedDB = cbDatabaseList.SelectedItem.ToString();
                LoadDatabaseDescription(selectedDB);
            }
            catch
            {
                tbDBDesc.Text = dbDescDefault;
            }
            return;
        }

        private void btnDBBackupFolder_Click(object sender, EventArgs e)
        {
            string selectedGP = cbSelectedGP.Text;
            string selectedBackup = cbDatabaseList.Text;
            bool isGPSelected = true;
            bool isDBSelected = true;
            if (selectedGP == "Select GP")
            {
                isGPSelected = false;
            }
            if (selectedBackup == "Select a Database")
            {
                isDBSelected = false;
            }
            if (isGPSelected == false || isDBSelected == false)
            {
                string message = "Please select both a GP Version and backup from the list to open it's folder.";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                return;
            }
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            if (Control.ModifierKeys == Keys.Shift)
            {
                cbDatabaseList.Items.Clear();
                string gpDBFolderPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP;
                if (!Directory.Exists(gpDBFolderPath))
                {
                    MessageBox.Show("The directory for the selected backup doesn't exist!");
                    return;
                }
                try
                {
                    Process.Start(gpDBFolderPath);
                    return;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                return;
            }
            string dbFolderPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP + "\\" + selectedBackup;
            if (!Directory.Exists(dbFolderPath))
            {
                MessageBox.Show("The directory for the selected backup doesn't exist!");
                return;
            }
            try
            {
                Process.Start(dbFolderPath);
                return;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            return;
        }

        private void btnDBBackupDescription_Click(object sender, EventArgs e)
        {
            //
            return;
        }

        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            string selectedDB = cbDatabaseList.Text;
            string gpVersion = cbSelectedGP.Text;
            bool isDBSelected = IsDBSelected(selectedDB);
            if (isDBSelected == false)
            {
                return;
            }
            string message = "Are you sure you want to restore \"" + selectedDB + "\" over your current environment?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Thread restoreDB = new Thread(() => RestoreDB(selectedDB, gpVersion));
                restoreDB.Start();
                return;
            }
            return;
        }

        private void btnOverwriteDB_Click(object sender, EventArgs e)
        {
            string selectedDB = cbDatabaseList.Text;
            selectedGPVersion = cbSelectedGP.Text;
            bool isDBSelected = IsDBSelected(selectedDB);
            if (isDBSelected == false)
            {
                return;
            }
            string Message = "Are you sure you want to overwrite the \"" + cbDatabaseList.Text + "\" backup with the current environment?";
            string Caption = "CONFIRM";
            MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon Icon = MessageBoxIcon.Question;
            DialogResult Result;

            Result = MessageBox.Show(Message, Caption, Buttons, Icon);
            if (Result == DialogResult.Yes)
            {
                dbToCreate = cbDatabaseList.Text;
                OverwriteBackup overwriteBackupForm = new OverwriteBackup(this);
                overwriteBackupForm.FormClosing += new FormClosingEventHandler(overwriteBackupFormClosing);
                overwriteBackupForm.Show();
            }
        }
        private void overwriteBackupFormClosing(object sender, FormClosingEventArgs e)
        {
            cbDatabaseList.Items.Clear();
            cbDatabaseList.Text = "Select a Database";
            tbDBDesc.Text = dbDescDefault;
            LoadDatabaseList();
        }

        private void btnNewDB_Click(object sender, EventArgs e)
        {
            selectedGPVersion = cbSelectedGP.Text;
            if (String.IsNullOrWhiteSpace(selectedGPVersion))
            {
                MessageBox.Show("Please select a GP version before creating a database backup.");
                return;
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                NewDBBackupSelect newDBBackupSelect = new NewDBBackupSelect(this);
                newDBBackupSelect.FormClosing += new FormClosingEventHandler(ClosingNewDBBackup);
                newDBBackupSelect.Show();
                return;
            }
            string Message = "Are you sure you want to create a new Database Backup??";
            string Caption = "CONFIRM";
            MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon Icon = MessageBoxIcon.Question;
            DialogResult Result;

            Result = MessageBox.Show(Message, Caption, Buttons, Icon);
            if (Result == DialogResult.Yes)
            {
                dbToCreate = cbDatabaseList.Text;
                NewDBBackup newDBBackup = new NewDBBackup(this);
                newDBBackup.FormClosing += new FormClosingEventHandler(ClosingNewDBBackup);
                newDBBackup.Show();
            }
        }
        private void ClosingNewDBBackup(object sender, FormClosingEventArgs e)
        {
            if (NewDBBackup.stopProcess == false)
            {
                cbDatabaseList.Items.Clear();
                cbSelectedGP.Text = "Select GP";
                cbDatabaseList.Text = "Select a Database";
                tbDBDesc.Text = dbDescDefault;
                return;
            }
            if (NewDBBackup.stopProcess == true)
            {
                return;
            }
            return;
        }

        private void btnDeleteBackup_Click(object sender, EventArgs e)
        {
            string selectedGP = cbSelectedGP.Text;
            string selectedDB = cbDatabaseList.Text;
            if (String.IsNullOrWhiteSpace(selectedDB))
            {
                MessageBox.Show("Please select a database to delete.");
                return;
            }
            string message = "Are you sure you want to delete the \"" + selectedDB + "\" backup?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                string dbFolderPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP + "\\" + selectedDB;
                Directory.Delete(dbFolderPath, true);
                LoadDatabaseList();

                using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\Database Log.txt"))
                {
                    sw.WriteLine("{" + DateTime.Now + "} - DELETED: " + selectedDB);
                }

                string messageComplete = "Backup \"" + selectedDB + "\" was successfully deleted.";
                string captionComplete = "COMPLETE";
                MessageBoxButtons buttonsComplete = MessageBoxButtons.OK;
                MessageBoxIcon iconComplete = MessageBoxIcon.Exclamation;
                DialogResult resultComplete;

                resultComplete = MessageBox.Show(messageComplete, captionComplete, buttonsComplete, iconComplete);
                return;
            }
            return;
        }

        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = cbProductList.Text;
            if (selectedProduct == "SalesPad Desktop")
            {
                cbSPGPVersion.Enabled = true;
            }
            else
            {
                cbSPGPVersion.Enabled = false;
            }
            return;
        }

        private void btnInstallProduct_Click(object sender, EventArgs e)
        {

            if (Control.ModifierKeys == Keys.Shift)
            {
                LastInstalled lastInstalled = new LastInstalled();
                lastInstalled.Show();
                return;
            }

            string product = cbProductList.Text;
            selectedProductVersion = cbSPGPVersion.Text;

            if (product == "Select a Product")
            {
                string errorMessage = "Please select a Product.";
                string errorCaption = "ERROR";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                return;
            }
            else if (product == "SalesPad Desktop")
            {
                string filePath = "";

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (selectedProductVersion == "x86" || selectedProductVersion == "Pre")
                    {
                        openFileDialog.Filter = "Executable Files (*.exe)|*x86.exe";
                    }
                    else
                    {
                        openFileDialog.Filter = "Executable Files (*.exe)|*x64.exe";
                    }
                    openFileDialog.InitialDirectory = @"\\sp-fileserv-01\Shares\Builds\SalesPad.GP\";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        fullInstallerPath = openFileDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
                SPGPFilePath = filePath;
                SPGPInstall SPGPform = new SPGPInstall(this);
                SPGPform.Show();
            }
            if (product == "SalesPad Mobile")
            {
                selectedInstallProduct = cbProductList.Text;

                using (OpenFileDialog installerSelect = new OpenFileDialog())
                {
                    installerSelect.Filter = "Executable Files (*.exe)|*.exe";
                    installerSelect.InitialDirectory = @"\\sp-fileserv-01\Shares\Builds\Ares\Mobile-Server\";
                    installerSelect.RestoreDirectory = true;

                    if (installerSelect.ShowDialog() == DialogResult.OK)
                    {
                        ProductFilePath = Path.GetDirectoryName(installerSelect.FileName);
                        ProductFileName = installerSelect.FileName;
                        OtherInstall InstallForm = new OtherInstall(this);
                        InstallForm.Show();
                    }
                    return;
                }
            }
            if (product == "DataCollection")
            {
                selectedInstallProduct = cbProductList.Text;

                using (OpenFileDialog installerSelect = new OpenFileDialog())
                {
                    installerSelect.Filter = "Executable Files (*.exe)|*.exe";
                    installerSelect.InitialDirectory = @"\\sp-fileserv-01\Shares\Builds\Ares\DataCollection\";
                    installerSelect.RestoreDirectory = true;

                    if (installerSelect.ShowDialog() == DialogResult.OK)
                    {
                        ProductFilePath = Path.GetDirectoryName(installerSelect.FileName);
                        ProductFileName = installerSelect.FileName;
                        OtherInstall InstallForm = new OtherInstall(this);
                        InstallForm.Show();
                    }
                    return;
                }
            }
            if (product == "ShipCenter")
            {
                selectedInstallProduct = cbProductList.Text;

                using (OpenFileDialog installerSelect = new OpenFileDialog())
                {
                    installerSelect.Filter = "Executable Files (*.exe)|*.exe";
                    installerSelect.InitialDirectory = @"\\sp-fileserv-01\Shares\Builds\ShipCenter\";
                    installerSelect.RestoreDirectory = true;

                    if (installerSelect.ShowDialog() == DialogResult.OK)
                    {
                        ProductFilePath = Path.GetDirectoryName(installerSelect.FileName);
                        ProductFileName = installerSelect.FileName;
                        OtherInstall InstallForm = new OtherInstall(this);
                        InstallForm.Show();
                    }
                    return;
                }
            }
        }

        private void btnLaunchProduct_Click(object sender, EventArgs e)
        {
            string selectedProduct = cbProductList.Text;
            selectedInstallProduct = cbProductList.Text;
            selectedProductVersion = cbSPGPVersion.Text;

            if (selectedProduct == "Select a Product")
            {
                string message = "Please select a product.";
                string caption = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                return;
            }
            if (selectedProduct == "SalesPad Desktop")
            {
                LaunchSPGP launchSPGPForm = new LaunchSPGP();
                launchSPGPForm.Show();
                return;
            }
            else
            {
                LaunchOtherProducts launchOtherProductsForm = new LaunchOtherProducts();
                launchOtherProductsForm.Show();
                return;
            }
        }

        private void btnDLLManager_Click(object sender, EventArgs e)
        {
            DLLManager dllManager = new DLLManager();
            dllManager.Show();
            return;
        }

        private void btnBuildFolder_Click(object sender, EventArgs e)
        {
            string product = cbProductList.Text;
            string prodVer = cbSPGPVersion.Text;

            if (product == "Select a Product")
            {
                string errorMessage = "Please select a Product.";
                string errorCaption = "ERROR";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                return;
            }
            if (product == "SalesPad Desktop" && prodVer == "x86")
            {
                LaunchBuildFolder(@"C:\Program Files (x86)\SalesPad.Desktop\");
            }
            if (product == "SalesPad Desktop" && prodVer == "Pre")
            {
                LaunchBuildFolder(@"C:\Program Files (x86)\SalesPad.Desktop\");
            }
            if (product == "SalesPad Desktop" && prodVer == "x64")
            {
                LaunchBuildFolder(@"C:\Program Files\SalesPad.Desktop\");
            }
            if (product == "SalesPad Mobile")
            {
                LaunchBuildFolder(@"C:\Program Files (x86)\SalesPad.GP.Mobile.Server\");
            }
            if (product == "DataCollection")
            {
                LaunchBuildFolder(@"C:\Program Files (x86)\DataCollection");
            }
            if (product == "ShipCenter")
            {
                LaunchBuildFolder(@"C:\Program Files (x86)\ShipCenter");
            }
        }

        private void cbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAlwaysOnTop.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
            return;
        }

        private void labelReloadIPAddress_Click(object sender, EventArgs e)
        {
            SetIPAddress();
            return;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.FormClosing += new FormClosingEventHandler(SettingsClose);
            settingsForm.Show();
        }
        private void SettingsClose(object sender, FormClosingEventArgs e)
        {
            LoadDatabaseList();
            return;
        }

        private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities launchUtilities = new Utilities();
            launchUtilities.Show();
            return;
        }

        private void resetDatabaseVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDBVersion resetDB = new ResetDBVersion();
            resetDB.Show();
            return;
        }

        private void salesPadDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string x86Path = Convert.ToString(key.GetValue("x86 SPGP Directory"));
            string x64Path = Convert.ToString(key.GetValue("x64 SPGP Directory"));
            string message = "Are you sure you want to delete all of your SalesPad Desktop builds?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Thread removeSPGP = new Thread(() => RemoveSalesPad(x86Path, x64Path));
                removeSPGP.Start();
            }
            return;
        }

        private void dataCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string buildPath = Convert.ToString(key.GetValue("DC Directory"));
            string message = "Are you sure you want to delete all of your DataCollection builds?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Thread removeProduct = new Thread(() => RemoveOtherProducts(buildPath));
                removeProduct.Start();
            }
            return;
        }

        private void mobileSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string buildPath = Convert.ToString(key.GetValue("SPM Directory"));
            string message = "Are you sure you want to delete all of your Mobile Server builds?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Thread removeProduct = new Thread(() => RemoveOtherProducts(buildPath));
                removeProduct.Start();
            }
            return;
        }

        private void shipCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string buildPath = Convert.ToString(key.GetValue("SC Directory"));
            string message = "Are you sure you want to delete all of your Ship Center builds?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Thread removeProduct = new Thread(() => RemoveOtherProducts(buildPath));
                removeProduct.Start();
            }
            return;
        }

        private void databaseLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to open the Database Log?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                Process.Start(Environment.CurrentDirectory + @"\Files\Database Log.txt");
            }
            return;
        }

        private void purgeCloudEnvironmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurgeCloud purgeCloud = new PurgeCloud();
            purgeCloud.Show();
            return;
        }

        private void backupBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupBackups backupBackups = new BackupBackups();
            backupBackups.Show();
            return;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int res1 = Test.Results1(5, 2);
            int res2 = Test.Results2(5, 2);
            MessageBox.Show(Convert.ToString(res1) + "\n" + Convert.ToString(res2));
            return;
        }
    }
}
