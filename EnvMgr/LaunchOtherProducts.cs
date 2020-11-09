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
    public partial class LaunchOtherProducts : Form
    {
        public LaunchOtherProducts()
        {
            InitializeComponent();
        }
        private void LoadBuildList(string baseFolder, string executableFile)
        {
            string[] buildPath = Directory.GetFiles(baseFolder, executableFile, SearchOption.AllDirectories);
            foreach (string build in buildPath)
            {
                string pathWithoutExe = Path.GetDirectoryName(build);
                lbInstalledBuilds.Items.Add(pathWithoutExe);
            }
        }

        private void LaunchOtherProducts_Load(object sender, EventArgs e)
        {
            if (Form1.selectedInstallProduct == "SalesPad Mobile")
            {
                LoadBuildList(@"C:\Program Files (x86)\SalesPad.GP.Mobile.Server\", "*SalesPad.GP.Mobile.Server.exe");
                return;
            }
            if (Form1.selectedInstallProduct == "DataCollection")
            {
                LoadBuildList(@"C:\Program Files (x86)\DataCollection\", "*DataCollection Extended Warehouse.exe");
                return;
            }
            if (Form1.selectedInstallProduct == "ShipCenter")
            {
                LoadBuildList(@"C:\Program Files (x86)\ShipCenter\", "*SalesPad.ShipCenter.exe");
                return;
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(lbInstalledBuilds.Text))
            {
                string errorMessage = "Please select a build to launch.";
                string errorCaption = "ERROR";
                MessageBoxButtons errorButton = MessageBoxButtons.OK;
                MessageBoxIcon errorIcon = MessageBoxIcon.Error;
                DialogResult errorResult;

                errorResult = MessageBox.Show(errorMessage, errorCaption, errorButton, errorIcon);
                return;
            }
            if (Form1.selectedInstallProduct == "SalesPad Mobile")
            {
                string selectedBuild = lbInstalledBuilds.Text.ToString();
                Process.Start(selectedBuild + @"\SalesPad.GP.Mobile.Server.exe");
                this.Close();
            }
            if (Form1.selectedInstallProduct == "DataCollection")
            {
                string selectedBuild = lbInstalledBuilds.Text.ToString();
                Process.Start(selectedBuild + @"\DataCollection Extended Warehouse.exe");
                this.Close();
            }
            if (Form1.selectedInstallProduct == "ShipCenter")
            {
                string selectedBuild = lbInstalledBuilds.Text.ToString();
                Process.Start(selectedBuild + @"\SalesPad.ShipCenter.exe");
                this.Close();
            }
            if (Form1.selectedInstallProduct == "Card Control")
            {
                string selectedBuild = lbInstalledBuilds.Text.ToString();
                Process.Start(selectedBuild + @"\CardControl.exe");
                this.Close();
            }
        }
    }
}
