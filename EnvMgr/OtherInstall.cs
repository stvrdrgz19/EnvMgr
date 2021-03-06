﻿using Microsoft.Win32;
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

        public static string selectedInstallProduct = "";
        public static string ProductFileName = "";
        public static string ProductFilePath = "";

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
                sw.WriteLine("{" + DateTime.Now + "} - " + selectedInstallProduct + ": " + fromLocation);
            }

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            if (selectedInstallProduct == "SalesPad Mobile")
            {
                Process.Start(toLocation + "\\SalesPad.GP.Mobile.Server.exe");
                key.SetValue("zLastSPMobileInstall", fromLocation);
                key.SetValue("zLastSPMobileInstallLocal", toLocation);
            }
            if (selectedInstallProduct == "DataCollection")
            {
                string DCLaunchPath = toLocation + "\\DataCollection Extended Warehouse.exe";
                ExecuteAsAdmin(DCLaunchPath);
                key.SetValue("zLastDCInstall", fromLocation);
                key.SetValue("zLastDCInstallLocal", toLocation);
            }
            if (selectedInstallProduct == "ShipCenter")
            {
                Process.Start(toLocation + "\\SalesPad.ShipCenter.exe");
                key.SetValue("zLastSCInstall", fromLocation);
                key.SetValue("zLastSCInstallLocal", toLocation);
            }
            if (selectedInstallProduct == "Card Control")
            {
                Process.Start(toLocation + "\\CardControl.exe");
                key.SetValue("zLastCCInstall", fromLocation);
                key.SetValue("zLastCCInstallLocal", toLocation);
            }
            _form1.DisableInstallButton(true);
        }

        private void OtherInstall_Load(object sender, EventArgs e)
        {
            tbFromLocation.Text = ProductFilePath;
            string pathToSplit = Path.GetDirectoryName(ProductFileName);
            if (selectedInstallProduct == "SalesPad Mobile")
            {
                string splitPath = pathToSplit.Remove(0, 50);
                tbToLocation.Text = @"C:\Program Files (x86)\SalesPad.GP.Mobile.Server\" + splitPath;
            }
            else if (selectedInstallProduct == "DataCollection")
            {
                string splitPath = pathToSplit.Remove(0, 51);
                tbToLocation.Text = @"C:\Program Files (x86)\DataCollection\" + splitPath;
            }
            else if (selectedInstallProduct == "ShipCenter")
            {
                string splitPath = pathToSplit.Remove(0, 42);
                tbToLocation.Text = @"C:\Program Files (x86)\ShipCenter\" + splitPath;
            }
            else if (selectedInstallProduct == "Card Control")
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
            string fileNamePath = ProductFileName;
            string fileName = Path.GetFileName(fileNamePath);
            string filePath = ProductFilePath;
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
                    if (existsResult == DialogResult.Yes)
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
