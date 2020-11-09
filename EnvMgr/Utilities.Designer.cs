namespace EnvMgr
{
    partial class Utilities
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utilities));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tbNotesToAdd = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.checkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.btnScriptRefresh = new System.Windows.Forms.Button();
            this.btnScriptRun = new System.Windows.Forms.Button();
            this.lbScriptList = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.tbNotesToAdd);
            this.tabPage1.Controls.Add(this.tbNotes);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(318, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbScriptList);
            this.tabPage2.Controls.Add(this.btnScriptRun);
            this.tabPage2.Controls.Add(this.btnScriptRefresh);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(318, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scripts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(6, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(7, 37);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.ReadOnly = true;
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotes.Size = new System.Drawing.Size(304, 272);
            this.tbNotes.TabIndex = 1;
            // 
            // tbNotesToAdd
            // 
            this.tbNotesToAdd.Location = new System.Drawing.Point(7, 315);
            this.tbNotesToAdd.Multiline = true;
            this.tbNotesToAdd.Name = "tbNotesToAdd";
            this.tbNotesToAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotesToAdd.Size = new System.Drawing.Size(304, 90);
            this.tbNotesToAdd.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(237, 411);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // checkAlwaysOnTop
            // 
            this.checkAlwaysOnTop.AutoSize = true;
            this.checkAlwaysOnTop.Location = new System.Drawing.Point(6, 472);
            this.checkAlwaysOnTop.Name = "checkAlwaysOnTop";
            this.checkAlwaysOnTop.Size = new System.Drawing.Size(98, 17);
            this.checkAlwaysOnTop.TabIndex = 1;
            this.checkAlwaysOnTop.Text = "Always On Top";
            this.checkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkAlwaysOnTop_CheckedChanged);
            // 
            // btnScriptRefresh
            // 
            this.btnScriptRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptRefresh.Image")));
            this.btnScriptRefresh.Location = new System.Drawing.Point(7, 7);
            this.btnScriptRefresh.Name = "btnScriptRefresh";
            this.btnScriptRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnScriptRefresh.TabIndex = 0;
            this.btnScriptRefresh.UseVisualStyleBackColor = true;
            this.btnScriptRefresh.Click += new System.EventHandler(this.btnScriptRefresh_Click);
            // 
            // btnScriptRun
            // 
            this.btnScriptRun.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptRun.Image")));
            this.btnScriptRun.Location = new System.Drawing.Point(32, 7);
            this.btnScriptRun.Name = "btnScriptRun";
            this.btnScriptRun.Size = new System.Drawing.Size(23, 23);
            this.btnScriptRun.TabIndex = 1;
            this.btnScriptRun.UseVisualStyleBackColor = true;
            this.btnScriptRun.Click += new System.EventHandler(this.btnScriptRun_Click);
            // 
            // lbScriptList
            // 
            this.lbScriptList.FormattingEnabled = true;
            this.lbScriptList.Location = new System.Drawing.Point(7, 37);
            this.lbScriptList.Name = "lbScriptList";
            this.lbScriptList.Size = new System.Drawing.Size(304, 394);
            this.lbScriptList.TabIndex = 2;
            // 
            // Utilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 493);
            this.Controls.Add(this.checkAlwaysOnTop);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Utilities";
            this.Text = "Utilities";
            this.Load += new System.EventHandler(this.Utilities_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbNotesToAdd;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox checkAlwaysOnTop;
        private System.Windows.Forms.ListBox lbScriptList;
        private System.Windows.Forms.Button btnScriptRun;
        private System.Windows.Forms.Button btnScriptRefresh;
    }
}