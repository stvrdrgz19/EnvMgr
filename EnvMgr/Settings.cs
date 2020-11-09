﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class Settings : Form
    {
        public static string startingDBFolder = "";
        public static string startingServName = "";
        public static string startingUserName = "";
        public static string startingPassword = "";
        public static string startingDynamics = "";
        public static string startingNonMB = "";
        public static string startingMB = "";
        public static string settingValToSend = "";
        public static string startingSPGPx86 = "";
        public static string startingSPGPx64 = "";
        public static string startingDC = "";
        public static string startingSPM = "";
        public static string startingSC = "";
        public static string startingTenantName = "";

        public Settings()
        {
            InitializeComponent();
        }

        public static bool CheckForUnsavedChanges(string dbBak, string SQLServer, string SQLUser, string SQLPassword, string dynamicsDB, string twoDB, string twombDB, string x86SP, string x64SP, string DC, string SPM, string SC, string tenantName)
        {
            bool changesMade = false;
            if (startingDBFolder != dbBak)
            {
                changesMade = true;
            }
            if (startingServName != SQLServer)
            {
                changesMade = true;
            }
            if (startingUserName != SQLUser)
            {
                changesMade = true;
            }
            if (startingPassword != SQLPassword)
            {
                changesMade = true;
            }
            if (startingDynamics != dynamicsDB)
            {
                changesMade = true;
            }
            if (startingNonMB != twoDB)
            {
                changesMade = true;
            }
            if (startingMB != twombDB)
            {
                changesMade = true;
            }
            if (startingSPGPx86 != x86SP)
            {
                changesMade = true;
            }
            if (startingSPGPx64 != x64SP)
            {
                changesMade = true;
            }
            if (startingDC != DC)
            {
                changesMade = true;
            }
            if (startingSPM != SPM)
            {
                changesMade = true;
            }
            if (startingSC != SC)
            {
                changesMade = true;
            }
            if (startingTenantName != tenantName)
            {
                changesMade = true;
            }
            return changesMade;
        }

        private void SaveSettings()
        {
            string DBFolder = tbDBDirectory.Text;
            string SQLServerName = tbSQLServerName.Text;
            string SQLServerUsername = tbSQLServerUsername.Text;
            string SQLServerPassword = tbSQLServerPassword.Text;
            string DynamicsDB = tbDynamicsDB.Text;
            string NonMBDB = tbNonMBDB.Text;
            string MBDB = tbMBDB.Text;
            string SPGPx86 = tbSPGPx86Directory.Text;
            string SPGPx64 = tbSPGPx64Directory.Text;
            string DC = tbDCDirectory.Text;
            string SPM = tbSPMDirectory.Text;
            string SC = tbSCDirectory.Text;
            string TenantName = tbTenantName.Text;
            startingDBFolder = tbDBDirectory.Text;
            startingServName = tbSQLServerName.Text;
            startingUserName = tbSQLServerUsername.Text;
            startingPassword = tbSQLServerPassword.Text;
            startingDynamics = tbDynamicsDB.Text;
            startingNonMB = tbNonMBDB.Text;
            startingMB = tbMBDB.Text;
            startingSPGPx86 = tbSPGPx86Directory.Text;
            startingSPGPx64 = tbSPGPx64Directory.Text;
            startingDC = tbDCDirectory.Text;
            startingSPM = tbSPMDirectory.Text;
            startingSC = tbSCDirectory.Text;
            startingTenantName = tbTenantName.Text;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            key.SetValue("DB Folder", DBFolder);
            key.SetValue("SQL Server Name", SQLServerName);
            key.SetValue("SQL Username", SQLServerUsername);
            key.SetValue("SQL Password", SQLServerPassword);
            key.SetValue("Dynamics Database", DynamicsDB);
            key.SetValue("Non-MB Database", NonMBDB);
            key.SetValue("MB Database", MBDB);
            key.SetValue("x86 SPGP Directory", SPGPx86);
            key.SetValue("x64 SPGP Directory", SPGPx64);
            key.SetValue("DC Directory", DC);
            key.SetValue("SPM Directory", SPM);
            key.SetValue("SC Directory", SC);
            key.SetValue("Tenant Name", TenantName);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            tbDBDirectory.Text = Convert.ToString(key.GetValue("DB Folder"));
            tbSQLServerName.Text = Convert.ToString(key.GetValue("SQL Server Name"));
            tbSQLServerUsername.Text = Convert.ToString(key.GetValue("SQL Username"));
            tbSQLServerPassword.Text = Convert.ToString(key.GetValue("SQL Password"));
            tbDynamicsDB.Text = Convert.ToString(key.GetValue("Dynamics Database"));
            tbNonMBDB.Text = Convert.ToString(key.GetValue("Non-MB Database"));
            tbMBDB.Text = Convert.ToString(key.GetValue("MB Database"));
            tbSPGPx86Directory.Text = Convert.ToString(key.GetValue("x86 SPGP Directory"));
            tbSPGPx64Directory.Text = Convert.ToString(key.GetValue("x64 SPGP Directory"));
            tbDCDirectory.Text = Convert.ToString(key.GetValue("DC Directory"));
            tbSPMDirectory.Text = Convert.ToString(key.GetValue("SPM Directory"));
            tbSCDirectory.Text = Convert.ToString(key.GetValue("SC Directory"));
            tbTenantName.Text = Convert.ToString(key.GetValue("Tenant Name"));

            startingDBFolder = tbDBDirectory.Text;
            startingServName = tbSQLServerName.Text;
            startingUserName = tbSQLServerUsername.Text;
            startingPassword = tbSQLServerPassword.Text;
            startingDynamics = tbDynamicsDB.Text;
            startingNonMB = tbNonMBDB.Text;
            startingMB = tbMBDB.Text;
            startingSPGPx86 = tbSPGPx86Directory.Text;
            startingSPGPx64 = tbSPGPx64Directory.Text;
            startingDC = tbDCDirectory.Text;
            startingSPM = tbSPMDirectory.Text;
            startingSC = tbSCDirectory.Text;
            startingTenantName = tbTenantName.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool changesMade = CheckForUnsavedChanges(tbDBDirectory.Text, tbSQLServerName.Text, tbSQLServerUsername.Text, tbSQLServerPassword.Text, tbDynamicsDB.Text, tbNonMBDB.Text, tbMBDB.Text, tbSPGPx86Directory.Text, tbSPGPx64Directory.Text, tbDCDirectory.Text, tbSPMDirectory.Text, tbSCDirectory.Text, tbTenantName.Text);
            if (changesMade == true)
            {
                string saveChangesMessage = "There are un-saved changes, do you want to save these changes?";
                string saveChangesCaption = "UNSAVED CHANGES";
                MessageBoxButtons saveChangesButtons = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon saveChangesIcon = MessageBoxIcon.Question;
                DialogResult saveChangesResult;

                saveChangesResult = MessageBox.Show(saveChangesMessage, saveChangesCaption, saveChangesButtons, saveChangesIcon);
                if (saveChangesResult == DialogResult.Yes)
                {
                    string DBFolder = tbDBDirectory.Text;
                    string SQLServerName = tbSQLServerName.Text;
                    string SQLServerUsername = tbSQLServerUsername.Text;
                    string SQLServerPassword = tbSQLServerPassword.Text;
                    string DynamicsDB = tbDynamicsDB.Text;
                    string NonMBDB = tbNonMBDB.Text;
                    string MBDB = tbMBDB.Text;
                    string SPGPx86 = tbSPGPx86Directory.Text;
                    string SPGPx64 = tbSPGPx64Directory.Text;
                    string DC = tbDCDirectory.Text;
                    string SPM = tbSPMDirectory.Text;
                    string SC = tbSCDirectory.Text;
                    string TenantName = tbTenantName.Text;

                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                    key.SetValue("DB Folder", DBFolder);
                    key.SetValue("SQL Server Name", SQLServerName);
                    key.SetValue("SQL Username", SQLServerUsername);
                    key.SetValue("SQL Password", SQLServerPassword);
                    key.SetValue("Dynamics Database", DynamicsDB);
                    key.SetValue("Non-MB Database", NonMBDB);
                    key.SetValue("MB Database", MBDB);
                    key.SetValue("x86 SPGP Directory", SPGPx86);
                    key.SetValue("x64 SPGP Directory", SPGPx64);
                    key.SetValue("DC Directory", DC);
                    key.SetValue("SPM Directory", SPM);
                    key.SetValue("SC Directory", SC);
                    key.SetValue("Tenant Name", TenantName);
                }
                if (saveChangesResult == DialogResult.No)
                {
                    this.Close();
                }
                else if (saveChangesResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.Close();
        }

        private void btnDBBackupDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog selectDBFolder = new FolderBrowserDialog())
            {
                selectDBFolder.SelectedPath = @"C:\";

                if (selectDBFolder.ShowDialog() == DialogResult.OK)
                {
                    tbDBDirectory.Text = selectDBFolder.SelectedPath + "\\";
                }
                else
                {
                    return;
                }
            }
        }

        private void btnSQLServerName_Click(object sender, EventArgs e)
        {
            settingValToSend = tbSQLServerName.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(SQLServerNameClose);
            SettingsPop.Show();
        }
        private void SQLServerNameClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbSQLServerName.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnSQLUsername_Click(object sender, EventArgs e)
        {
            settingValToSend = tbSQLServerUsername.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(SQLServerUserameClose);
            SettingsPop.Show();
        }
        private void SQLServerUserameClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbSQLServerUsername.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnSQLPassword_Click(object sender, EventArgs e)
        {
            settingValToSend = tbSQLServerPassword.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(SQLServerPasswordClose);
            SettingsPop.Show();
        }
        private void SQLServerPasswordClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbSQLServerPassword.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnDynamicsDB_Click(object sender, EventArgs e)
        {
            settingValToSend = tbDynamicsDB.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(DynamicsDBClose);
            SettingsPop.Show();
        }
        private void DynamicsDBClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbDynamicsDB.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnNonMBDB_Click(object sender, EventArgs e)
        {
            settingValToSend = tbNonMBDB.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(NonMBDBClose);
            SettingsPop.Show();
        }
        private void NonMBDBClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbNonMBDB.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnMBDB_Click(object sender, EventArgs e)
        {
            settingValToSend = tbMBDB.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(MBDBClose);
            SettingsPop.Show();
        }
        private void MBDBClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbMBDB.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnSPGPx86Directory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog selectSPGPx86 = new FolderBrowserDialog())
            {
                selectSPGPx86.SelectedPath = @"C:\";
                if (selectSPGPx86.ShowDialog() == DialogResult.OK)
                {
                    tbSPGPx86Directory.Text = selectSPGPx86.SelectedPath + "\\";
                }
                return;
            }
        }

        private void btnSPGPx64Directory_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog selectSPGPx64 = new FolderBrowserDialog())
            {
                selectSPGPx64.SelectedPath = @"C:\";
                if (selectSPGPx64.ShowDialog() == DialogResult.OK)
                {
                    tbSPGPx64Directory.Text = selectSPGPx64.SelectedPath + "\\";
                }
                return;
            }
        }

        private void btnDCDirectory_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog selectDC = new FolderBrowserDialog())
            {
                selectDC.SelectedPath = @"C:\";
                if (selectDC.ShowDialog() == DialogResult.OK)
                {
                    tbDCDirectory.Text = selectDC.SelectedPath + "\\";
                }
                return;
            }
        }

        private void btnSPMDirectory_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog selectSPM = new FolderBrowserDialog())
            {
                selectSPM.SelectedPath = @"C:\";
                if (selectSPM.ShowDialog() == DialogResult.OK)
                {
                    tbSPMDirectory.Text = selectSPM.SelectedPath + "\\";
                }
                return;
            }
        }

        private void btnSCDirectory_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog selectSC = new FolderBrowserDialog())
            {
                selectSC.SelectedPath = @"C:\";
                if (selectSC.ShowDialog() == DialogResult.OK)
                {
                    tbSCDirectory.Text = selectSC.SelectedPath + "\\";
                }
                return;
            }
        }

        private void btnTenantName_Click(object sender, EventArgs e)
        {
            settingValToSend = tbTenantName.Text;
            SettingsPop SettingsPop = new SettingsPop();
            SettingsPop.FormClosing += new FormClosingEventHandler(TenantNameClose);
            SettingsPop.Show();
        }
        private void TenantNameClose(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SettingsPop.newSettingValue) || SettingsPop.cancelPressed == true)
            {
                return;
            }
            tbTenantName.Text = SettingsPop.newSettingValue;
            return;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            bool unsavedChanges = CheckForUnsavedChanges(tbDBDirectory.Text, tbSQLServerName.Text, tbSQLServerUsername.Text, tbSQLServerPassword.Text, tbDynamicsDB.Text, tbNonMBDB.Text, tbMBDB.Text, tbSPGPx86Directory.Text, tbSPGPx64Directory.Text, tbDCDirectory.Text, tbSPMDirectory.Text, tbSCDirectory.Text, tbTenantName.Text);
            if (unsavedChanges == true)
            {
                string message = "You must save changes made to Settings before Exporting. Do you want to Save and Export?";
                string caption = "CONFIRM";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                    //Code the Export action here.
                }
                return;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to import over your current settings? This action can't be undone.";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                //Code the Settings Import stuff
            }
            //Save here or reword the prompt.
            return;
        }
    }
}