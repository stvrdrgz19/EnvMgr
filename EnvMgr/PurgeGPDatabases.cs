using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class PurgeGPDatabases : Form
    {
        private Form1 _form1;
        public PurgeGPDatabases(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void LoadDatabases(string service)
        {
            if (service == "Please select a SQL Server...")
            {
                return;
            }
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=STEVERODRIGUEZ\" + service + ";Initial Catalog=MASTER;User ID=sa;Password=sa;");
                var sqlQuery = sqlCon.Query<string>("SELECT NAME FROM sys.databases WHERE name NOT IN ('master','tempdb','model','msdb')").AsList();
                lbDatabaseList.Items.Clear();
                foreach (string database in sqlQuery)
                {
                    lbDatabaseList.Items.Add(database);
                }
            }
            catch (Exception errorThrown)
            {
                string errorMessage = "There was an exception connecting to the selected SQL Service. Please ensure the selected Sql Service is still running and try again.";
                ExceptionHandling.LogException(errorThrown.ToString(), errorMessage);
                MessageBox.Show(errorMessage);
            }
        }

        private void PurgeGPDatabases_Load(object sender, EventArgs e)
        {
            List<string> sqlServers =_form1.InstalledSQLServers();
            foreach (string server in sqlServers)
            {
                ServiceController selectedService = new ServiceController("MSSQL$" + server);
                if (selectedService.Status.Equals(ServiceControllerStatus.Running))
                {
                    cbSQLServer.Items.Add(server);
                }
            }
            cbSQLServer.Text = "Please select a SQL Server...";
            return;
        }

        private void cbSQLServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatabases(cbSQLServer.Text);
            return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDatabases(cbSQLServer.Text);
            return;
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            if (lbDatabaseList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select databases to delete.");
                return;
            }
            List<string> dbsToDelete = new List<string>();
            foreach (string database in lbDatabaseList.SelectedItems)
            {
                dbsToDelete.Add(database);
            }
            string message = "Are you sure you want to delete the following databases?\n\n" + dbsToDelete.ToString();
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                foreach (string database in lbDatabaseList.SelectedItems)
                {
                    //foreach (selectedItem) DeleteMethod
                }
                LoadDatabases(cbSQLServer.Text);
                MessageBox.Show("The selected databases were successfully deleted.");
            }
            return;
        }
    }
}
