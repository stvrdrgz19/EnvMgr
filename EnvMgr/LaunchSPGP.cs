using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class LaunchSPGP : Form
    {
        public LaunchSPGP()
        {
            InitializeComponent();
        }

        public static string selectedProductVersion = "";

        private void LaunchSPGP_Load(object sender, EventArgs e)
        {
            if (selectedProductVersion == "x86" || selectedProductVersion == "Pre")
            {
                string[] text = Directory.GetFiles(@"C:\Program Files (x86)\SalesPad.Desktop\", @"*SalesPad.exe", SearchOption.AllDirectories);
                foreach (string t in text)
                {
                    string pathWithoutExe = Path.GetDirectoryName(t);
                    InstalledBuilds.Items.Add(pathWithoutExe);
                }
            }
            else if (selectedProductVersion == "x64")
            {
                string[] text = Directory.GetFiles(@"C:\Program Files\SalesPad.Desktop\", @"*SalesPad.exe", SearchOption.AllDirectories);
                foreach (string t in text)
                {
                    string pathWithoutExe = Path.GetDirectoryName(t);
                    InstalledBuilds.Items.Add(pathWithoutExe);
                }
            }
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(InstalledBuilds.Text))
            {
                string errorMessage = "Please select a build to launch.";
                string errorCaption = "ERROR";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                return;
            }
            string selectedBuild = InstalledBuilds.Text.ToString();
            Process.Start(selectedBuild + @"\SalesPad.exe");
            this.Close();
            return;
        }

        private void CopyLabels_Click(object sender, EventArgs e)
        {
            List<string> selectedDLLList = new List<string>();
            StringBuilder builder = new StringBuilder();
            foreach (string dll in SelectedBuildDLLs.SelectedItems)
            {
                selectedDLLList.Add(dll);
            }
            foreach (string str in selectedDLLList)
            {
                builder.Append(str.ToString()).AppendLine();
            }
            try
            {
                Clipboard.SetText(builder.ToString());
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please select DLLs to copy.");
                return;
            }
            string copyMessage = "The following dll's have been copied to the clipboard: \n\n" + builder.ToString();
            string copyCaption = "COPIED";
            MessageBoxButtons copyButton = MessageBoxButtons.OK;
            MessageBoxIcon copyIcon = MessageBoxIcon.Exclamation;
            DialogResult copyResult;

            copyResult = MessageBox.Show(copyMessage, copyCaption, copyButton, copyIcon);
            return;
        }

        private void RemoveDLLs_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SelectedBuildDLLs.Text))
            {
                MessageBox.Show("Please select DLLs to delete.");
                return;
            }
            string selectedBuild = InstalledBuilds.Text + @"\";
            foreach (string dll in SelectedBuildDLLs.SelectedItems)
            {
                List<string> selectedDLLList = new List<string>();
                StringBuilder builder = new StringBuilder();
                foreach (string deleteDLL in SelectedBuildDLLs.SelectedItems)
                {
                    selectedDLLList.Add(deleteDLL);
                }
                foreach (string str in selectedDLLList)
                {
                    builder.Append(str.ToString()).AppendLine();
                }
                string deletePromptMessage = "Are you sure you want to delete the selected dll's? \n\n" + builder.ToString();
                string deletePromptCaption = "ARE YOU SURE?";
                MessageBoxButtons deletePromptButtons = MessageBoxButtons.YesNo;
                MessageBoxIcon deletePromptIcon = MessageBoxIcon.Warning;
                DialogResult deletePromptResult;

                deletePromptResult = MessageBox.Show(deletePromptMessage, deletePromptCaption, deletePromptButtons, deletePromptIcon);

                if (deletePromptResult == DialogResult.Yes)
                {
                    foreach (string deleteDLL in SelectedBuildDLLs.SelectedItems)
                    {
                        File.SetAttributes(selectedBuild + deleteDLL, FileAttributes.Normal);
                        File.Delete(selectedBuild + deleteDLL);
                    }
                    SelectedBuildDLLs.Items.Clear();
                    string dllCompareListFile = @"C:\Users\steve.rodriguez\Desktop\Scripts\Projects\LaunchSPGPBuild\DLLList.txt";

                    string dllCompareList = File.ReadAllText(dllCompareListFile);
                    string[] dllList = Directory.GetFiles(selectedBuild, "SalesPad.Module.*.dll");
                    foreach (string dllx in dllList)
                    {
                        if (!dllCompareList.Contains(Path.GetFileName(dllx)))
                        {
                            string dllTrimmed = Path.GetFileName(dllx);
                            SelectedBuildDLLs.Items.Add(dllTrimmed);
                        }
                    }
                    MessageBox.Show("DLLs have been successfully Deleted!");
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        private void InstalledBuilds_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dllIgnoreList = new List<string>();
            dllIgnoreList.Add("SalesPad.Module.App.dll");
            dllIgnoreList.Add("SalesPad.Module.ARTransactionEntry.dll");
            dllIgnoreList.Add("SalesPad.Module.AvaTax.dll");
            dllIgnoreList.Add("SalesPad.Module.CCHSalesTaxOffice.dll");
            dllIgnoreList.Add("SalesPad.Module.CCHSalesTaxOnlineWS.dll");
            dllIgnoreList.Add("SalesPad.Module.Ccp.dll");
            dllIgnoreList.Add("SalesPad.Module.CRM.dll");
            dllIgnoreList.Add("SalesPad.Module.Dashboard.dll");
            dllIgnoreList.Add("SalesPad.Module.DistributionBOM.dll");
            dllIgnoreList.Add("SalesPad.Module.DocumentManagement.dll");
            dllIgnoreList.Add("SalesPad.Module.EquipmentManagement.dll");
            dllIgnoreList.Add("SalesPad.Module.FedExServiceManager.dll");
            dllIgnoreList.Add("SalesPad.Module.GP2010.dll");
            dllIgnoreList.Add("SalesPad.Module.GP2010SP2.dll");
            dllIgnoreList.Add("SalesPad.Module.GP2013.dll");
            dllIgnoreList.Add("SalesPad.Module.GP2013R2.dll");
            dllIgnoreList.Add("SalesPad.Module.Inventory.dll");
            dllIgnoreList.Add("SalesPad.Module.NodusPayFabric.dll");
            dllIgnoreList.Add("SalesPad.Module.Printing.dll");
            dllIgnoreList.Add("SalesPad.Module.Purchasing.dll");
            dllIgnoreList.Add("SalesPad.Module.QuickReports.dll");
            dllIgnoreList.Add("SalesPad.Module.Reporting.dll");
            dllIgnoreList.Add("SalesPad.Module.ReturnsManagement.dll");
            dllIgnoreList.Add("SalesPad.Module.Sales.dll");
            dllIgnoreList.Add("SalesPad.Module.SalesEntryQuickPick.dll");
            dllIgnoreList.Add("SalesPad.Module.SignaturePad.dll");
            dllIgnoreList.Add("SalesPad.Module.GP2015.dll");

            SelectedBuildDLLs.Items.Clear();
            string selectedBuild = InstalledBuilds.Text + @"\";
            string[] dllList = Directory.GetFiles(selectedBuild, "SalesPad.Module.*.dll");
            foreach (string dll in dllList)
            {
                if (!dllIgnoreList.Contains(Path.GetFileName(dll)))
                {
                    string dllTrimmed = Path.GetFileName(dll);
                    SelectedBuildDLLs.Items.Add(dllTrimmed);
                }
            }
        }
    }
}
