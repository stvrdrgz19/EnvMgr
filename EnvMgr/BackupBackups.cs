using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class BackupBackups : Form
    {
        public BackupBackups()
        {
            InitializeComponent();
        }

        static string coreBackupPath = @"C:\#BAKs\";
        static string gpVersion = "";

        public void LoadDBsToBack(string path)
        {
            lbDBsToBak.Items.Clear();
            string[] dbList = Directory.GetDirectories(path);
            foreach (string folder in dbList)
            {
                lbDBsToBak.Items.Add(folder.Remove(0, path.Length + 1));
            }
        }

        public void LoadBackedDBs(string path)
        {
            lbBackedDBs.Items.Clear();
            string[] backList = Directory.GetFiles(path);
            foreach (string file in backList)
            {
                if (file.Contains(".zip"))
                {
                    lbBackedDBs.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void BackupBackups_Load(object sender, EventArgs e)
        {
            gpVersion = cbGPVersion.Text;
            LoadDBsToBack(coreBackupPath + gpVersion);
            tbBackedFolder.Text = @"C:\#BAKs\GP2016\";
            LoadBackedDBs(tbBackedFolder.Text);
            return;
        }

        private void cbGPVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gpVersion = cbGPVersion.Text;
            LoadDBsToBack(coreBackupPath + gpVersion);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (lbDBsToBak.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a database/databases to back up.");
                return;
            }
            foreach (string path in lbDBsToBak.SelectedItems)
            {
                gpVersion = cbGPVersion.Text;
                string dbPath = coreBackupPath + gpVersion + "\\" + path;
                string zipFile = tbBackedFolder.Text + path + ".zip";
                //ZipFile.CreateFromDirectory(dbPath, zipFile);
                //MessageBox.Show(dbPath + "\n\n" + zipFile);
                try
                {
                    ZipFile.CreateFromDirectory(dbPath, zipFile);
                }
                catch (IOException)
                {
                    MessageBox.Show("The following file already exists.\n\n" + zipFile);
                }
            }
            LoadBackedDBs(tbBackedFolder.Text);
            return;
        }
    }
}
