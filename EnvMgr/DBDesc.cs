using Microsoft.Win32;
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
    public partial class DBDesc : Form
    {
        public DBDesc()
        {
            InitializeComponent();
        }

        public static string selectedGP = "";
        public static string dbName = "";
        public static bool newDescExist = false;
        public static string dbDescLine1 = "===============================================================================";

        public static bool NewDescExists(string newDesc)
        {
            bool tf = false;
            if (String.IsNullOrWhiteSpace(newDesc))
            {
                tf = false;
            }
            else
            {
                tf = true;
            }
            return tf;
        }

        public static string existingDesc = "";

        private void DBDesc_Load(object sender, EventArgs e)
        {
            tbExistingDescription.Text = existingDesc;
            return;
        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            string newDesc = tbNewDescription.Text;
            newDescExist = NewDescExists(newDesc);
            if (newDescExist)
            {
                string message = "Are you sure you want to overwrite the existing backup description with the new backup description? Otherwise you can append to the existing description instead, using the \"Add to Description\" button.";
                string caption = "CONFIRM";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    // Code to overwrite the description.
                    // May require unzipping/deleting the file/re-creating the file/re-zipping
                    //ZipArchiveEntry.Delete
                    //ZipArchiveEntry.CreateEntry
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                    string zipPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP + "\\" + dbName + ".zip";
                    try
                    {
                        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
                        {
                            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry delDescEntry = archive.GetEntry("Description.txt");
                                if (delDescEntry != null)
                                {
                                    delDescEntry.Delete();
                                }
                                ZipArchiveEntry descEntry = archive.CreateEntry("Description.txt");
                                using (StreamWriter writer = new StreamWriter(descEntry.Open()))
                                {
                                    writer.WriteLine(dbDescLine1);
                                    writer.WriteLine("BACKUP - " + dbName);
                                    writer.WriteLine(DateTime.Now);
                                    writer.WriteLine(newDesc);
                                }
                                archive.Dispose();
                            }
                        }
                    }
                    catch (Exception eD)
                    {
                        MessageBox.Show("There was an error opening the description file for the selected backup: \n\n" + eD.ToString());
                        return;
                    }
                }
            }
            this.Close();
            return;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newDesc = tbNewDescription.Text;
            newDescExist = NewDescExists(newDesc);
            if (newDescExist)
            {
                string message = "Are you sure you want to append the new description information to the existing description?";
                string caption = "CONFIRM";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, icon);
                if (result == DialogResult.Yes)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                    string zipPath = Convert.ToString(key.GetValue("DB Folder")) + selectedGP + "\\" + dbName + ".zip";
                    try
                    {
                        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
                        {
                            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry descEntry = archive.CreateEntry("Description.txt");
                                using (StreamWriter writer = new StreamWriter(descEntry.Open()))
                                {
                                    writer.WriteLine(dbDescLine1);
                                    writer.WriteLine("BACKUP - " + dbName);
                                    writer.WriteLine(DateTime.Now);
                                    writer.WriteLine(newDesc);
                                }
                                archive.Dispose();
                            }
                        }
                    }
                    catch (Exception eD)
                    {
                        MessageBox.Show("There was an error opening the description file for the selected backup: \n\n" + eD.ToString());
                        return;
                    }
                }
            }
            this.Close();
            return;
        }
    }
}
