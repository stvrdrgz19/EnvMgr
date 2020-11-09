using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class LastInstalled : Form
    {
        public LastInstalled()
        {
            InitializeComponent();
        }

        private void btnInstallLog_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + @"\Files\InstallLog.txt");
            }
            catch
            {
                MessageBox.Show("No log file! Please create a text file called \"InstallLog.txt\" at " + Environment.CurrentDirectory + "\\Files\" to be able to write and read Product Install logs.");
            }
            this.Close();
        }

        private void btnSPGP_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            try
            {
                string lastSPGP = Convert.ToString(key.GetValue("zLastSPGPInstall"));
                Clipboard.SetText(lastSPGP);
            }
            catch
            {
                MessageBox.Show("You haven't logged any SalesPad GP installs yet!");
            }
            this.Close();
        }

        private void btnSPM_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            try
            {
                string lastSPMobile = Convert.ToString(key.GetValue("zLastSPMobileInstall"));
                Clipboard.SetText(lastSPMobile);
            }
            catch
            {
                MessageBox.Show("You haven't logged any SalesPad Mobile Server installs yet!");
            }
            this.Close();
        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            try
            {
                string lastDC = Convert.ToString(key.GetValue("zLastDCInstall"));
                Clipboard.SetText(lastDC);
            }
            catch
            {
                MessageBox.Show("You haven't logged any DataCollection Server installs yet!");
            }
            this.Close();
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            try
            {
                string lastSC = Convert.ToString(key.GetValue("zLastSCInstall"));
                Clipboard.SetText(lastSC);
            }
            catch
            {
                MessageBox.Show("You haven't logged any Ship Center installs yet!");
            }
            this.Close();
        }
    }
}
