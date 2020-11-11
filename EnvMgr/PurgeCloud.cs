using Dapper;
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
    public partial class PurgeCloud : Form
    {
        public PurgeCloud()
        {
            InitializeComponent();
        }

        public static string sqlScript = "";

        public void LoadEnvironments()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string tenantName = Convert.ToString(key.GetValue("Tenant Name"));
            SqlConnection sqlCon1 = new SqlConnection(@"Data Source=sp-devsql-01;Initial Catalog=MASTER;User ID=sa;Password=sa;");
            var availableDatabases = sqlCon1.Query<string>("SELECT NAME FROM sys.databases WHERE NAME LIKE '%" + tenantName + "%'").AsList();
            lbEnvironments.Items.Clear();
            foreach (string database in availableDatabases)
            {
                lbEnvironments.Items.Add(database);
                //if (database.Contains(tenantName))
                //{
                //    lbEnvironments.Items.Add(database);
                //}
            }
            return;
        }

        public void DeleteEnvironment(string environment)
        {
            if (environment.Contains("_Intacct") || environment.Contains("_Tenantless"))
            {
                sqlScript = @"DROP DATABASE [" + environment + "]";
            }
            else
            {
                sqlScript = @"ALTER DATABASE [" + environment + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [" + environment + "]";
            }
            SqlConnection sqlCon = new SqlConnection(@"Data Source=sp-devsql-01;Initial Catalog=MASTER;User ID=sa;Password=sa;");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlScript, sqlCon);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
        }

        private void PurgeCloud_Load(object sender, EventArgs e)
        {
            LoadEnvironments();
            return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEnvironments();
            return;
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            if (lbEnvironments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select databases to delete.");
                return;
            }
            StringBuilder envList = new StringBuilder();
            foreach (var environment in lbEnvironments.SelectedItems)
            {
                envList.Append(environment.ToString()).AppendLine();
            }
            string message = "Are you sure you want to delete the following databases?\n\n" + envList.ToString();
            string caption = "CONFIRM";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == DialogResult.Yes)
            {
                foreach (var environment in lbEnvironments.SelectedItems)
                {
                    DeleteEnvironment(environment.ToString());
                }
                LoadEnvironments();
                MessageBox.Show("The selected databases were successfully deleted.");
            }
            return;
        }
    }
}
