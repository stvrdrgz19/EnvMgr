namespace EnvMgr
{
    partial class ResetDBVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetDBVersion));
            this.checkTWO = new System.Windows.Forms.CheckBox();
            this.checkTWOMB = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkTWO
            // 
            this.checkTWO.AutoSize = true;
            this.checkTWO.Location = new System.Drawing.Point(13, 13);
            this.checkTWO.Name = "checkTWO";
            this.checkTWO.Size = new System.Drawing.Size(52, 17);
            this.checkTWO.TabIndex = 0;
            this.checkTWO.Text = "TWO";
            this.checkTWO.UseVisualStyleBackColor = true;
            // 
            // checkTWOMB
            // 
            this.checkTWOMB.AutoSize = true;
            this.checkTWOMB.Location = new System.Drawing.Point(13, 37);
            this.checkTWOMB.Name = "checkTWOMB";
            this.checkTWOMB.Size = new System.Drawing.Size(68, 17);
            this.checkTWOMB.TabIndex = 1;
            this.checkTWOMB.Text = "TWOMB";
            this.checkTWOMB.UseVisualStyleBackColor = true;
            this.checkTWOMB.CheckedChanged += new System.EventHandler(this.checkTWOMB_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(13, 61);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(253, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ResetDBVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 92);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.checkTWOMB);
            this.Controls.Add(this.checkTWO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResetDBVersion";
            this.Text = "Reset Database Version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkTWO;
        private System.Windows.Forms.CheckBox checkTWOMB;
        private System.Windows.Forms.Button btnRun;
    }
}