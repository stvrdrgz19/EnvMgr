namespace EnvMgr
{
    partial class PurgeGPDatabases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurgeGPDatabases));
            this.lbDatabaseList = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPurge = new System.Windows.Forms.Button();
            this.cbSQLServer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbDatabaseList
            // 
            this.lbDatabaseList.FormattingEnabled = true;
            this.lbDatabaseList.Location = new System.Drawing.Point(3, 30);
            this.lbDatabaseList.Name = "lbDatabaseList";
            this.lbDatabaseList.Size = new System.Drawing.Size(304, 108);
            this.lbDatabaseList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(2, 140);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(152, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPurge
            // 
            this.btnPurge.Location = new System.Drawing.Point(156, 140);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(152, 23);
            this.btnPurge.TabIndex = 2;
            this.btnPurge.Text = "Purge";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // cbSQLServer
            // 
            this.cbSQLServer.FormattingEnabled = true;
            this.cbSQLServer.Location = new System.Drawing.Point(3, 6);
            this.cbSQLServer.Name = "cbSQLServer";
            this.cbSQLServer.Size = new System.Drawing.Size(304, 21);
            this.cbSQLServer.TabIndex = 3;
            this.cbSQLServer.SelectedIndexChanged += new System.EventHandler(this.cbSQLServer_SelectedIndexChanged);
            // 
            // PurgeGPDatabases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 165);
            this.Controls.Add(this.cbSQLServer);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbDatabaseList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurgeGPDatabases";
            this.Text = "Purge GP Databases";
            this.Load += new System.EventHandler(this.PurgeGPDatabases_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDatabaseList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPurge;
        private System.Windows.Forms.ComboBox cbSQLServer;
    }
}