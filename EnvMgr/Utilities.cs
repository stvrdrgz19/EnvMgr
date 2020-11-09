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
    public partial class Utilities : Form
    {
        public Utilities()
        {
            InitializeComponent();
        }

        public static string scriptPath = @"C:\Users\steve.rodriguez\Desktop\Scripts\";
        public static string notePath = @"C:\Users\steve.rodriguez\Desktop\Scripts\NoteText.txt";
        public static string noteDivider = "==============================================";

        private void LoadNotes()
        {
            tbNotes.Clear();
            string noteFileContents = File.ReadAllText(notePath);
            tbNotes.Text = noteFileContents;
        }

        private void LoadScripts()
        {
            lbScriptList.Items.Clear();
            string[] scriptList = Directory.GetFiles(scriptPath);
            foreach (string script in scriptList)
            {
                lbScriptList.Items.Add(script.Remove(0, scriptPath.Length));
            }
        }

        private void Utilities_Load(object sender, EventArgs e)
        {
            LoadNotes();
            LoadScripts();
            return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotes();
            return;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbNotesToAdd.Text))
            {
                using (StreamWriter sw = File.AppendText(notePath))
                {
                    sw.WriteLine(noteDivider + "\n" + tbNotesToAdd.Text);
                }
                tbNotesToAdd.Clear();
                LoadNotes();
            }
            return;
        }

        private void btnScriptRefresh_Click(object sender, EventArgs e)
        {
            LoadScripts();
            return;
        }

        private void btnScriptRun_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lbScriptList.Text))
            {
                Process.Start(scriptPath + lbScriptList.Text);
            }
            return;
        }

        private void checkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAlwaysOnTop.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
    }
}
