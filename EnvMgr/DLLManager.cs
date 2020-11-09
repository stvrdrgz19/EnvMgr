using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class DLLManager : Form
    {
        public DLLManager()
        {
            InitializeComponent();
        }

        public string version = "x86";
        public string extendedPath = "";
        public string customPath = "";
        public string toPath = "";
        public bool versionBool = false;

        private void SetToDLLList(string path)
        {
            lbDLLs.Items.Clear();

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

            string[] dllList = Directory.GetFiles(path, "SalesPad.Module.*.dll");
            foreach (string dll in dllList)
            {
                if (!dllIgnoreList.Contains(Path.GetFileName(dll)))
                {
                    string dllTrimmed = Path.GetFileName(dll);
                    lbDLLs.Items.Add(dllTrimmed);
                }
            }
        }

        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fromBuild = tbFromBuild.Text;
            if (versionBool == false)
            {
                if (!String.IsNullOrWhiteSpace(fromBuild))
                {
                    string message = "Are you sure you want to change the version? Doing so will clear out the From Build and DLL Lists.";
                    string caption = "CONFIRM";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        tbFromBuild.Text = "";
                        lbExtended.Items.Clear();
                        lbCustom.Items.Clear();
                    }
                    if (result == DialogResult.No)
                    {
                        versionBool = true;
                        cbVersion.Text = version;
                        versionBool = false;
                    }
                    version = cbVersion.Text;
                }
                return;
            }
            return;
        }

        private void btnGetFromBuild_Click(object sender, EventArgs e)
        {
            version = cbVersion.Text;
            using (var fromFolder = new FolderBrowserDialog())
            {
                fromFolder.SelectedPath = @"\\sp-fileserv-01\Shares\Builds\SalesPad.GP";
                fromFolder.Description = "Select a folder to pull DLLs from:";
                DialogResult result = fromFolder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fromFolder.SelectedPath))
                {
                    lbExtended.Items.Clear();
                    lbCustom.Items.Clear();
                    tbFromBuild.Text = fromFolder.SelectedPath;
                }
                else
                {
                    return;
                }

                switch (version)
                {
                    case "x86":
                        extendedPath = @"\ExtModules\x86";
                        customPath = @"\CustomModules\x86";
                        break;
                    case "x64":
                        extendedPath = @"\ExtModules\x64";
                        customPath = @"\CustomModules\x64";
                        break;
                    case "Pre":
                        extendedPath = @"\ExtModules\WithOutCardControl";
                        customPath = @"\CustomModules\WithOutCardControl";
                        break;
                }
                string extendedDLLPath = fromFolder.SelectedPath + extendedPath;
                string customDLLPath = fromFolder.SelectedPath + customPath;

                try
                {
                    string[] extendedDLLList = Directory.GetFiles(extendedDLLPath);
                    foreach (string dll in extendedDLLList)
                    {
                        lbExtended.Items.Add(dll.Remove(0, extendedDLLPath.Length + 17));
                    }
                    string[] customDLLList = Directory.GetFiles(customDLLPath);
                    foreach (string dll in customDLLList)
                    {
                        lbCustom.Items.Add(dll.Remove(0, customDLLPath.Length + 17));
                    }
                }
                catch (Exception)
                {
                    string message = "The selected SalesPad build doesn't support the selected version. Please try again.";
                    string caption = "ERROR";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;

                    MessageBox.Show(message, caption, buttons, icon);
                    tbFromBuild.Text = "";
                    return;
                }
            }
            return;
        }

        private void btnGetToBuild_Click(object sender, EventArgs e)
        {
            version = cbVersion.Text;
            switch (version)
            {
                case "x86":
                    toPath = @"C:\Program Files (x86)";
                    break;
                case "x64":
                    toPath = @"C:\Program Files";
                    break;
                case "Pre":
                    toPath = @"C:\Program Files (x86)";
                    break;
            }
            using (var toFolder = new FolderBrowserDialog())
            {
                toFolder.SelectedPath = toPath;
                toFolder.Description = "Select a SalesPad install folder to add DLLs to:";
                DialogResult result = toFolder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(toFolder.SelectedPath))
                {
                    lbDLLs.Items.Clear();
                    tbToBuild.Text = toFolder.SelectedPath;
                }
                else
                {
                    return;
                }
                SetToDLLList(toFolder.SelectedPath);
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            string spgpToLaunch = tbToBuild.Text;
            if (!String.IsNullOrWhiteSpace(spgpToLaunch))
            {
                string message = "Are you sure you want to launch the selected SalesPad GP build?";
                string caption = "CONFIRM";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(spgpToLaunch + @"\SalesPad.exe");
                    }
                    catch (Exception launchError)
                    {
                        MessageBox.Show("There was an error launching the selected build:\n\n" + launchError);
                    }
                }
                return;
            }
            MessageBox.Show("There is no build selected to launch.");
            return;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(lbDLLs.Text))
            {
                MessageBox.Show("Please select some DLLs to copy.");
                return;
            }
            List<string> selectedDLLsToCopy = new List<string>();
            StringBuilder builder = new StringBuilder();
            foreach (string dll in lbDLLs.SelectedItems)
            {
                selectedDLLsToCopy.Add(dll);
            }
            foreach (string str in selectedDLLsToCopy)
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

            MessageBox.Show(copyMessage, copyCaption, copyButton, copyIcon);
            return;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string buildPath = tbToBuild.Text + "\\";
            if (String.IsNullOrWhiteSpace(lbDLLs.Text))
            {
                MessageBox.Show("Please select some DLLs to remove.");
                return;
            }
            List<string> toRemoveDLLList = new List<string>();
            StringBuilder builder = new StringBuilder();
            foreach (string removeDLL in lbDLLs.SelectedItems)
            {
                toRemoveDLLList.Add(removeDLL);
            }
            foreach (string str in toRemoveDLLList)
            {
                builder.Append(str.ToString()).AppendLine();
            }
            string message = "Are you sure you want to delete the selected DLL's?\n\n" + builder.ToString();
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                foreach (string deleteDLL in lbDLLs.SelectedItems)
                {
                    File.Delete(buildPath + deleteDLL);
                }
            }
            SetToDLLList(buildPath);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            version = cbVersion.Text;
            string fromBuild = tbFromBuild.Text;
            string toBuild = tbToBuild.Text;
            switch (version)
            {
                case "x86":
                    extendedPath = @"\ExtModules\x86\SalesPad.Module.";
                    customPath = @"\CustomModules\x86\SalesPad.Module.";
                    break;
                case "x64":
                    extendedPath = @"\ExtModules\x64\SalesPad.Module.";
                    customPath = @"\CustomModules\x64\SalesPad.Module.";
                    break;
                case "Pre":
                    extendedPath = @"\ExtModules\WithOutCardControl\SalesPad.Module.";
                    customPath = @"\CustomModules\WithOutCardControl\SalesPad.Module.";
                    break;
            }

            if (String.IsNullOrWhiteSpace(tbToBuild.Text))
            {
                MessageBox.Show("Please select a build to add DLLs to.");
                return;
            }
            if (String.IsNullOrWhiteSpace(lbExtended.Text) && String.IsNullOrWhiteSpace(lbCustom.Text))
            {
                MessageBox.Show("Please select DLLs to add to the selected build.");
                return;
            }
            List<string> extendedList = new List<string>();
            StringBuilder extList = new StringBuilder();
            foreach (string extDLL in lbExtended.SelectedItems)
            {
                extendedList.Add(extDLL);
            }
            foreach (string extStr in extendedList)
            {
                extList.Append(extStr.ToString()).AppendLine();
            }
            List<string> customList = new List<string>();
            StringBuilder custList = new StringBuilder();
            foreach (string custDLL in lbCustom.SelectedItems)
            {
                customList.Add(custDLL);
            }
            foreach (string custStr in customList)
            {
                custList.Append(custStr.ToString()).AppendLine();
            }
            string message = "Are you sure you want to add the following DLLs to the selected SalesPad GP Installation?\n\nEXTENDED:\n" + extList.ToString() + "\nCUSTOM:\n" + custList.ToString();
            string caption = "CONFIRM?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                foreach (string exDLL in lbExtended.SelectedItems)
                {
                    File.Copy(fromBuild + extendedPath + exDLL, toBuild + "\\SalesPad.Module." + exDLL, true);
                    ZipFile.ExtractToDirectory(toBuild + "\\SalesPad.Module." + exDLL, toBuild);
                    File.Delete(toBuild + "\\SalesPad.Module." + exDLL);
                }
                foreach (string custDLL in lbCustom.SelectedItems)
                {
                    File.Copy(fromBuild + customPath + custDLL, toBuild + "\\SalesPad.Module." + custDLL, true);
                    ZipFile.ExtractToDirectory(toBuild + "\\SalesPad.Module." + custDLL, toBuild);
                    File.Delete(toBuild + "\\SalesPad.Module." + custDLL);
                }
            }
            SetToDLLList(toBuild);
            return;
        }
    }
}
