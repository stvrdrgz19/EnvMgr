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
    public partial class SettingsPop : Form
    {
        public static bool cancelPressed = false;
        public static string newSettingValue = "";

        public SettingsPop()
        {
            InitializeComponent();
        }

        private void SettingsPop_Load(object sender, EventArgs e)
        {
            tbSettingValue.Text = Settings.settingValToSend;
            return;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            newSettingValue = tbSettingValue.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelPressed = true;
            this.Close();
        }
    }
}
