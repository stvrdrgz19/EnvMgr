namespace EnvMgr
{
    partial class LastInstalled
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LastInstalled));
            this.btnInstallLog = new System.Windows.Forms.Button();
            this.btnWEB = new System.Windows.Forms.Button();
            this.btnAPI = new System.Windows.Forms.Button();
            this.btnCC = new System.Windows.Forms.Button();
            this.btnSC = new System.Windows.Forms.Button();
            this.btnDCCAB = new System.Windows.Forms.Button();
            this.btnDC = new System.Windows.Forms.Button();
            this.btnSPM = new System.Windows.Forms.Button();
            this.btnSPGP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInstallLog
            // 
            this.btnInstallLog.Location = new System.Drawing.Point(12, 13);
            this.btnInstallLog.Name = "btnInstallLog";
            this.btnInstallLog.Size = new System.Drawing.Size(206, 23);
            this.btnInstallLog.TabIndex = 9;
            this.btnInstallLog.Text = "Launch Install Log";
            this.btnInstallLog.UseVisualStyleBackColor = true;
            this.btnInstallLog.Click += new System.EventHandler(this.btnInstallLog_Click);
            // 
            // btnWEB
            // 
            this.btnWEB.Enabled = false;
            this.btnWEB.Location = new System.Drawing.Point(118, 129);
            this.btnWEB.Name = "btnWEB";
            this.btnWEB.Size = new System.Drawing.Size(100, 23);
            this.btnWEB.TabIndex = 17;
            this.btnWEB.Text = "GP Web";
            this.btnWEB.UseVisualStyleBackColor = true;
            // 
            // btnAPI
            // 
            this.btnAPI.Enabled = false;
            this.btnAPI.Location = new System.Drawing.Point(118, 100);
            this.btnAPI.Name = "btnAPI";
            this.btnAPI.Size = new System.Drawing.Size(100, 23);
            this.btnAPI.TabIndex = 16;
            this.btnAPI.Text = "GP Web API";
            this.btnAPI.UseVisualStyleBackColor = true;
            // 
            // btnCC
            // 
            this.btnCC.Enabled = false;
            this.btnCC.Location = new System.Drawing.Point(118, 71);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(100, 23);
            this.btnCC.TabIndex = 15;
            this.btnCC.Text = "Card Control";
            this.btnCC.UseVisualStyleBackColor = true;
            // 
            // btnSC
            // 
            this.btnSC.Location = new System.Drawing.Point(118, 42);
            this.btnSC.Name = "btnSC";
            this.btnSC.Size = new System.Drawing.Size(100, 23);
            this.btnSC.TabIndex = 14;
            this.btnSC.Text = "ShipCenter";
            this.btnSC.UseVisualStyleBackColor = true;
            this.btnSC.Click += new System.EventHandler(this.btnSC_Click);
            // 
            // btnDCCAB
            // 
            this.btnDCCAB.Enabled = false;
            this.btnDCCAB.Location = new System.Drawing.Point(12, 129);
            this.btnDCCAB.Name = "btnDCCAB";
            this.btnDCCAB.Size = new System.Drawing.Size(100, 23);
            this.btnDCCAB.TabIndex = 13;
            this.btnDCCAB.Text = "DC Cab";
            this.btnDCCAB.UseVisualStyleBackColor = true;
            // 
            // btnDC
            // 
            this.btnDC.Location = new System.Drawing.Point(12, 100);
            this.btnDC.Name = "btnDC";
            this.btnDC.Size = new System.Drawing.Size(100, 23);
            this.btnDC.TabIndex = 12;
            this.btnDC.Text = "DataCollection";
            this.btnDC.UseVisualStyleBackColor = true;
            this.btnDC.Click += new System.EventHandler(this.btnDC_Click);
            // 
            // btnSPM
            // 
            this.btnSPM.Location = new System.Drawing.Point(12, 71);
            this.btnSPM.Name = "btnSPM";
            this.btnSPM.Size = new System.Drawing.Size(100, 23);
            this.btnSPM.TabIndex = 11;
            this.btnSPM.Text = "SalesPad Mobile";
            this.btnSPM.UseVisualStyleBackColor = true;
            this.btnSPM.Click += new System.EventHandler(this.btnSPM_Click);
            // 
            // btnSPGP
            // 
            this.btnSPGP.Location = new System.Drawing.Point(12, 42);
            this.btnSPGP.Name = "btnSPGP";
            this.btnSPGP.Size = new System.Drawing.Size(100, 23);
            this.btnSPGP.TabIndex = 10;
            this.btnSPGP.Text = "SalesPad GP";
            this.btnSPGP.UseVisualStyleBackColor = true;
            this.btnSPGP.Click += new System.EventHandler(this.btnSPGP_Click);
            // 
            // LastInstalled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 164);
            this.Controls.Add(this.btnInstallLog);
            this.Controls.Add(this.btnWEB);
            this.Controls.Add(this.btnAPI);
            this.Controls.Add(this.btnCC);
            this.Controls.Add(this.btnSC);
            this.Controls.Add(this.btnDCCAB);
            this.Controls.Add(this.btnDC);
            this.Controls.Add(this.btnSPM);
            this.Controls.Add(this.btnSPGP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LastInstalled";
            this.Text = "Build Paths";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstallLog;
        private System.Windows.Forms.Button btnWEB;
        private System.Windows.Forms.Button btnAPI;
        private System.Windows.Forms.Button btnCC;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.Button btnDCCAB;
        private System.Windows.Forms.Button btnDC;
        private System.Windows.Forms.Button btnSPM;
        private System.Windows.Forms.Button btnSPGP;
    }
}