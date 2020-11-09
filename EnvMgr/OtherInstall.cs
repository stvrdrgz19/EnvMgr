using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class OtherInstall : Form
    {
        private Form1 _form1;
        public OtherInstall(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        public string Product = Form1.selectedInstallProduct;

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        public void NewOtherIntsallThread(string fileNamePath, string tempInstallPath, string toLocation, string fromLocation)
        {
            _form1.DisableInstallButton(false);

            File.Copy(fileNamePath, tempInstallPath, true);

            Process productInstall = new Process();
            productInstall.StartInfo.FileName = fileNamePath;
            productInstall.StartInfo.Arguments = @"/S /D=" + toLocation;
            productInstall.Start();
            productInstall.WaitForExit();

            File.Delete(tempInstallPath);

            //LOG INSTALL
            using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
            {
                sw.WriteLine("{" + DateTime.Now + "} - " + Product + ": " + fromLocation);
            }

            if (Product == "SalesPad Mobile")
            {
                Process.Start(toLocation + "\\SalesPad.GP.Mobile.Server.exe");
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                key.SetValue("zLastSPMobileInstall", fromLocation);
            }
            if (Product == "DataCollection")
            {
                string DCLaunchPath = toLocation + "\\DataCollection Extended Warehouse.exe";
                ExecuteAsAdmin(DCLaunchPath);
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                key.SetValue("zLastDCInstall", fromLocation);
            }
            if (Product == "ShipCenter")
            {
                Process.Start(toLocation + "\\SalesPad.ShipCenter.exe");
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                key.SetValue("zLastSCInstall", fromLocation);
            }
            if (Product == "Card Control")
            {
                Process.Start(toLocation + "\\CardControl.exe");
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                key.SetValue("zLastCCInstall", fromLocation);
            }

            _form1.DisableInstallButton(true);
        }

        private void OtherInstall_Load(object sender, EventArgs e)
        {
            tbFromLocation.Text = Form1.ProductFilePath;
            string pathToSplit = Path.GetDirectoryName(Form1.ProductFileName);
            if (Form1.selectedInstallProduct == "SalesPad Mobile")
            {
                string splitPath = pathToSplit.Remove(0, 50);
                tbToLocation.Text = @"C:\Program Files (x86)\SalesPad.GP.Mobile.Server\" + splitPath;
            }
            else if (Form1.selectedInstallProduct == "DataCollection")
            {
                string splitPath = pathToSplit.Remove(0, 51);
                tbToLocation.Text = @"C:\Program Files (x86)\DataCollection\" + splitPath;
            }
            else if (Form1.selectedInstallProduct == "ShipCenter")
            {
                string splitPath = pathToSplit.Remove(0, 42);
                tbToLocation.Text = @"C:\Program Files (x86)\ShipCenter\" + splitPath;
            }
            else if (Form1.selectedInstallProduct == "Card Control")
            {
                string splitPath = pathToSplit.Remove(0, 36);
                tbToLocation.Text = @"C:\Program Files (x86)\CardControl\" + splitPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory + @"\Installers");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            string fromLocation = tbFromLocation.Text;
            string toLocation = tbToLocation.Text;
            string fileNamePath = Form1.ProductFileName;
            string fileName = Path.GetFileName(fileNamePath);
            string filePath = Form1.ProductFilePath;
            string tempInstallPath = Environment.CurrentDirectory + @"\Installers\" + fileName;

            if (toLocation == @"C:\Program Files (x86)\SalesPad.GP.Mobile.Server\" || toLocation == @"C:\Program Files (x86)\DataCollection\" || toLocation == @"C:\Program Files (x86)\ShipCenter\" || toLocation == @"C:\Program Files (x86)\CardControl\")
            {
                string defaultMessage = "Please enter an install location different than the default value: \n\n" + toLocation;
                string defaultCaption = "ERROR";
                MessageBoxButtons defaultButtons = MessageBoxButtons.OK;
                MessageBoxIcon defaultIcon = MessageBoxIcon.Error;
                DialogResult defaultResult;

                defaultResult = MessageBox.Show(defaultMessage, defaultCaption, defaultButtons, defaultIcon);
                return;
            }
            if (Directory.Exists(toLocation))
            {
                string existsMessage = "The selected product is already installed in the specified location. Do you want to overwrite this install?";
                string existsCaption = "EXISTS";
                MessageBoxButtons existsButtons = MessageBoxButtons.YesNo;
                MessageBoxIcon existsIcon = MessageBoxIcon.Warning;
                DialogResult existsResult;

                existsResult = MessageBox.Show(existsMessage, existsCaption, existsButtons, existsIcon);
                {
                    if (existsResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        Directory.Delete(toLocation, true);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            this.Close();

            Thread newOtherInstl = new Thread(() => NewOtherIntsallThread(fileNamePath, tempInstallPath, toLocation, fromLocation));
            newOtherInstl.Start();
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
