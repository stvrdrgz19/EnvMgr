namespace EnvMgr
{
    partial class PurgeCloud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurgeCloud));
            this.lbEnvironments = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPurge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEnvironments
            // 
            this.lbEnvironments.FormattingEnabled = true;
            this.lbEnvironments.Location = new System.Drawing.Point(12, 12);
            this.lbEnvironments.Name = "lbEnvironments";
            this.lbEnvironments.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbEnvironments.Size = new System.Drawing.Size(400, 199);
            this.lbEnvironments.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(11, 218);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(198, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPurge
            // 
            this.btnPurge.Location = new System.Drawing.Point(215, 218);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(198, 23);
            this.btnPurge.TabIndex = 2;
            this.btnPurge.Text = "Purge";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // PurgeCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 248);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lbEnvironments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurgeCloud";
            this.Text = "Purge Cloud Environments";
            this.Load += new System.EventHandler(this.PurgeCloud_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbEnvironments;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPurge;
    }
}