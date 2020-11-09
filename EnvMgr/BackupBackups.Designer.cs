namespace EnvMgr
{
    partial class BackupBackups
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBackedFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbDBsToBak = new System.Windows.Forms.ListBox();
            this.lbBackedDBs = new System.Windows.Forms.ListBox();
            this.cbGPVersion = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGPVersion);
            this.groupBox1.Controls.Add(this.lbDBsToBak);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Databases To Backup";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(6, 199);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(523, 23);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Backup Selected Databases";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbBackedDBs);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.tbBackedFolder);
            this.groupBox2.Location = new System.Drawing.Point(2, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 231);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backed Up Databases";
            // 
            // tbBackedFolder
            // 
            this.tbBackedFolder.Location = new System.Drawing.Point(7, 22);
            this.tbBackedFolder.Name = "tbBackedFolder";
            this.tbBackedFolder.ReadOnly = true;
            this.tbBackedFolder.Size = new System.Drawing.Size(497, 20);
            this.tbBackedFolder.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(505, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbDBsToBak
            // 
            this.lbDBsToBak.FormattingEnabled = true;
            this.lbDBsToBak.Location = new System.Drawing.Point(7, 46);
            this.lbDBsToBak.Name = "lbDBsToBak";
            this.lbDBsToBak.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDBsToBak.Size = new System.Drawing.Size(521, 147);
            this.lbDBsToBak.TabIndex = 2;
            // 
            // lbBackedDBs
            // 
            this.lbBackedDBs.FormattingEnabled = true;
            this.lbBackedDBs.Location = new System.Drawing.Point(7, 48);
            this.lbBackedDBs.Name = "lbBackedDBs";
            this.lbBackedDBs.Size = new System.Drawing.Size(521, 173);
            this.lbBackedDBs.TabIndex = 3;
            // 
            // cbGPVersion
            // 
            this.cbGPVersion.FormattingEnabled = true;
            this.cbGPVersion.Items.AddRange(new object[] {
            "GP10",
            "GP2010",
            "GP2013",
            "GP2015",
            "GP2016",
            "GP2018",
            "GP2019"});
            this.cbGPVersion.Location = new System.Drawing.Point(7, 20);
            this.cbGPVersion.Name = "cbGPVersion";
            this.cbGPVersion.Size = new System.Drawing.Size(68, 21);
            this.cbGPVersion.TabIndex = 3;
            this.cbGPVersion.Text = "GP2016";
            this.cbGPVersion.SelectedIndexChanged += new System.EventHandler(this.cbGPVersion_SelectedIndexChanged);
            // 
            // BackupBackups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BackupBackups";
            this.Text = "BackupBackups";
            this.Load += new System.EventHandler(this.BackupBackups_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbBackedFolder;
        private System.Windows.Forms.ListBox lbDBsToBak;
        private System.Windows.Forms.ListBox lbBackedDBs;
        private System.Windows.Forms.ComboBox cbGPVersion;
    }
}