using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class ResetDBVersion : Form
    {
        public ResetDBVersion()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTWO.Checked)
            {
                checkTWO.Checked = false;
            }
            return;
        }

        private void checkTWOMB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTWOMB.Checked)
            {
                checkTWOMB.Checked = false;
            }
            return;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to reset the database version for the selected database?";
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string script = "";
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                string sqlServ = Convert.ToString(key.GetValue("SQL Server Name"));
                string sqlUser = Convert.ToString(key.GetValue("SQL Username"));
                string sqlPassword = Convert.ToString(key.GetValue("SQL Password"));
                string nonMBDB = Convert.ToString(key.GetValue("Non-MB Database"));
                string mbDB = Convert.ToString(key.GetValue("MB Database"));

                if (checkTWO.Checked)
                {
                    script = @"USE [" + nonMBDB + @"] EXEC dbo.sppResetDatabase";
                }
                if (checkTWOMB.Checked)
                {
                    script = @"USE [" + mbDB + @"] EXEC dbo.sppResetDatabase";
                }

                SqlConnection sqlCon = new SqlConnection(@"Data Source=" + sqlServ + @";Initial Catalog=MASTER;User ID=" + sqlUser + @";Password=" + sqlPassword + @";");
                SqlDataAdapter restoreDynScript = new SqlDataAdapter(script, sqlCon);
                DataTable restoreDynTable = new DataTable();
                restoreDynScript.Fill(restoreDynTable);

                this.Close();
            }
            return;
        }
    }
}
