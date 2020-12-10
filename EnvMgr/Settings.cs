using Microsoft.Win32;
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
        public static bool startingDBMethod = false;
        public static string startingDynamics = "";
        public static string startingNonMB = "";
        public static string startingMB = "";
        public static string settingValToSend = "";
        public static string startingSPGPx86 = "";
        public static string startingSPGPx64 = "";
        public static string startingDC = "";
        public static string startingSPM = "";
        public static string startingSC = "";
        public static bool startingAutoInstall = false;
        public static bool startingAutoOverwrite = false;
        public static string startingTenantName = "";

        public Settings()
        {
            InitializeComponent();
        }

        public static bool CheckForUnsavedChanges(string dbBak, bool dbMethod, string dynamicsDB, string twoDB, string twombDB, string x86SP, string x64SP, string DC, string SPM, string SC, bool autoInstall, bool autoOverwrite, string tenantName)
        {
            bool changesMade = false;
            if (startingDBFolder != dbBak)
            {
                changesMade = true;
            }
            if (startingDBMethod != dbMethod)
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
            if (startingAutoInstall != autoInstall)
            {
                changesMade = true;
            }
            if (startingAutoOverwrite != autoOverwrite)
            {
                changesMade = true;
            }
            if (startingTenantName != tenantName)
            {
                changesMade = true;
            }
            return changesMade;
        }

        public void SetStartingValue()
        {
            startingDBFolder = tbDBDirectory.Text;
            startingDBMethod = cbDBMethod.Checked;
            startingDynamics = tbDynamicsDB.Text;
            startingNonMB = tbNonMBDB.Text;
            startingMB = tbMBDB.Text;
            startingSPGPx86 = tbSPGPx86Directory.Text;
            startingSPGPx64 = tbSPGPx64Directory.Text;
            startingDC = tbDCDirectory.Text;
            startingSPM = tbSPMDirectory.Text;
            startingSC = tbSCDirectory.Text;
            startingAutoInstall = cbAutoInstall.Checked;
            startingAutoOverwrite = cbAutoOverwrite.Checked;
            startingTenantName = tbTenantName.Text;
        }

        private void SaveSettings()
        {
            string DBFolder = tbDBDirectory.Text;
            bool DBMethod = cbDBMethod.Checked;
            string DynamicsDB = tbDynamicsDB.Text;
            string NonMBDB = tbNonMBDB.Text;
            string MBDB = tbMBDB.Text;
            string SPGPx86 = tbSPGPx86Directory.Text;
            string SPGPx64 = tbSPGPx64Directory.Text;
            string DC = tbDCDirectory.Text;
            string SPM = tbSPMDirectory.Text;
            string SC = tbSCDirectory.Text;
            bool AutoInstall = cbAutoInstall.Checked;
            bool AutoOverwrite = cbAutoOverwrite.Checked;
            string TenantName = tbTenantName.Text;
            SetStartingValue();

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            key.SetValue("DB Folder", DBFolder);
            key.SetValue("DB Method", DBMethod);
            key.SetValue("Dynamics Database", DynamicsDB);
            key.SetValue("Non-MB Database", NonMBDB);
            key.SetValue("MB Database", MBDB);
            key.SetValue("x86 SPGP Directory", SPGPx86);
            key.SetValue("x64 SPGP Directory", SPGPx64);
            key.SetValue("DC Directory", DC);
            key.SetValue("SPM Directory", SPM);
            key.SetValue("SC Directory", SC);
            key.SetValue("Auto Install Product", AutoInstall);
            key.SetValue("Auto Overwrite Install", AutoOverwrite);
            key.SetValue("Tenant Name", TenantName);
        }

        private void DBControlsEnabled(bool tf)
        {
            tbDynamicsDB.Enabled = tf;
            tbNonMBDB.Enabled = tf;
            tbMBDB.Enabled = tf;
            btnDynamicsDB.Enabled = tf;
            btnNonMBDB.Enabled = tf;
            btnMBDB.Enabled = tf;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            tbDBDirectory.Text = Convert.ToString(key.GetValue("DB Folder"));
            cbDBMethod.Checked = Convert.ToBoolean(key.GetValue("DB Method"));
            tbDynamicsDB.Text = Convert.ToString(key.GetValue("Dynamics Database"));
            tbNonMBDB.Text = Convert.ToString(key.GetValue("Non-MB Database"));
            tbMBDB.Text = Convert.ToString(key.GetValue("MB Database"));
            tbSPGPx86Directory.Text = Convert.ToString(key.GetValue("x86 SPGP Directory"));
            tbSPGPx64Directory.Text = Convert.ToString(key.GetValue("x64 SPGP Directory"));
            tbDCDirectory.Text = Convert.ToString(key.GetValue("DC Directory"));
            tbSPMDirectory.Text = Convert.ToString(key.GetValue("SPM Directory"));
            tbSCDirectory.Text = Convert.ToString(key.GetValue("SC Directory"));
            cbAutoInstall.Checked = Convert.ToBoolean(key.GetValue("Auto Install Product"));
            cbAutoOverwrite.Checked = Convert.ToBoolean(key.GetValue("Auto Overwrite Install"));
            tbTenantName.Text = Convert.ToString(key.GetValue("Tenant Name"));

            SetStartingValue();

            if (cbDBMethod.Checked)
            {
                DBControlsEnabled(false);
            }
            return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool changesMade = CheckForUnsavedChanges(tbDBDirectory.Text, cbDBMethod.Checked, tbDynamicsDB.Text, tbNonMBDB.Text, tbMBDB.Text, tbSPGPx86Directory.Text, tbSPGPx64Directory.Text, tbDCDirectory.Text, tbSPMDirectory.Text, tbSCDirectory.Text, cbAutoInstall.Checked, cbAutoOverwrite.Checked, tbTenantName.Text);
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
                    SaveSettings();
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
            bool unsavedChanges = CheckForUnsavedChanges(tbDBDirectory.Text, cbDBMethod.Checked, tbDynamicsDB.Text, tbNonMBDB.Text, tbMBDB.Text, tbSPGPx86Directory.Text, tbSPGPx64Directory.Text, tbDCDirectory.Text, tbSPMDirectory.Text, tbSCDirectory.Text, cbAutoInstall.Checked, cbAutoOverwrite.Checked, tbTenantName.Text);
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

        private void cbDBMethod_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDBMethod.Checked)
            {
                DBControlsEnabled(false);
            }
            if (!cbDBMethod.Checked)
            {
                DBControlsEnabled(true);
            }
            return;
        }
    }
}
