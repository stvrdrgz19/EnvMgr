namespace EnvMgr
{
    partial class SPGPInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPGPInstall));
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkAutomationAgentDLLs = new System.Windows.Forms.CheckBox();
            this.checkEDIDLL = new System.Windows.Forms.CheckBox();
            this.checkTPGDLLs = new System.Windows.Forms.CheckBox();
            this.checkExpressPointDLLs = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbCustomDLLList = new System.Windows.Forms.ListBox();
            this.lbExtendedDLLList = new System.Windows.Forms.ListBox();
            this.tbInstallLocation = new System.Windows.Forms.TextBox();
            this.tbSelectedBuild = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkRunDBUpdate = new System.Windows.Forms.CheckBox();
            this.checkPlaceholder = new System.Windows.Forms.CheckBox();
            this.checkOpenInstallFolder = new System.Windows.Forms.CheckBox();
            this.checkLaunchAfterInstall = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(464, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAutomationAgentDLLs);
            this.groupBox1.Controls.Add(this.checkEDIDLL);
            this.groupBox1.Controls.Add(this.checkTPGDLLs);
            this.groupBox1.Controls.Add(this.checkExpressPointDLLs);
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 78);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common Projects";
            // 
            // checkAutomationAgentDLLs
            // 
            this.checkAutomationAgentDLLs.AutoSize = true;
            this.checkAutomationAgentDLLs.Location = new System.Drawing.Point(157, 43);
            this.checkAutomationAgentDLLs.Name = "checkAutomationAgentDLLs";
            this.checkAutomationAgentDLLs.Size = new System.Drawing.Size(138, 17);
            this.checkAutomationAgentDLLs.TabIndex = 9;
            this.checkAutomationAgentDLLs.Text = "Automation Agent DLLs";
            this.checkAutomationAgentDLLs.UseVisualStyleBackColor = true;
            this.checkAutomationAgentDLLs.CheckedChanged += new System.EventHandler(this.checkAutomationAgentDLLs_CheckedChanged);
            // 
            // checkEDIDLL
            // 
            this.checkEDIDLL.AutoSize = true;
            this.checkEDIDLL.Location = new System.Drawing.Point(157, 19);
            this.checkEDIDLL.Name = "checkEDIDLL";
            this.checkEDIDLL.Size = new System.Drawing.Size(67, 17);
            this.checkEDIDLL.TabIndex = 8;
            this.checkEDIDLL.Text = "EDI DLL";
            this.checkEDIDLL.UseVisualStyleBackColor = true;
            this.checkEDIDLL.CheckedChanged += new System.EventHandler(this.checkEDIDLL_CheckedChanged);
            // 
            // checkTPGDLLs
            // 
            this.checkTPGDLLs.AutoSize = true;
            this.checkTPGDLLs.Location = new System.Drawing.Point(7, 44);
            this.checkTPGDLLs.Name = "checkTPGDLLs";
            this.checkTPGDLLs.Size = new System.Drawing.Size(76, 17);
            this.checkTPGDLLs.TabIndex = 7;
            this.checkTPGDLLs.Text = "TPG DLLs";
            this.checkTPGDLLs.UseVisualStyleBackColor = true;
            this.checkTPGDLLs.CheckedChanged += new System.EventHandler(this.checkTPGDLLs_CheckedChanged);
            // 
            // checkExpressPointDLLs
            // 
            this.checkExpressPointDLLs.AutoSize = true;
            this.checkExpressPointDLLs.Location = new System.Drawing.Point(7, 20);
            this.checkExpressPointDLLs.Name = "checkExpressPointDLLs";
            this.checkExpressPointDLLs.Size = new System.Drawing.Size(114, 17);
            this.checkExpressPointDLLs.TabIndex = 6;
            this.checkExpressPointDLLs.Text = "Expresspoint DLLs";
            this.checkExpressPointDLLs.UseVisualStyleBackColor = true;
            this.checkExpressPointDLLs.CheckedChanged += new System.EventHandler(this.checkExpressPointDLLs_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(545, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // lbCustomDLLList
            // 
            this.lbCustomDLLList.FormattingEnabled = true;
            this.lbCustomDLLList.Location = new System.Drawing.Point(322, 110);
            this.lbCustomDLLList.Name = "lbCustomDLLList";
            this.lbCustomDLLList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCustomDLLList.Size = new System.Drawing.Size(300, 199);
            this.lbCustomDLLList.TabIndex = 28;
            this.lbCustomDLLList.SelectedIndexChanged += new System.EventHandler(this.lbCustomDLLList_SelectedIndexChanged);
            // 
            // lbExtendedDLLList
            // 
            this.lbExtendedDLLList.FormattingEnabled = true;
            this.lbExtendedDLLList.Location = new System.Drawing.Point(12, 110);
            this.lbExtendedDLLList.Name = "lbExtendedDLLList";
            this.lbExtendedDLLList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExtendedDLLList.Size = new System.Drawing.Size(300, 199);
            this.lbExtendedDLLList.TabIndex = 27;
            this.lbExtendedDLLList.SelectedIndexChanged += new System.EventHandler(this.lbExtendedDLLList_SelectedIndexChanged);
            // 
            // tbInstallLocation
            // 
            this.tbInstallLocation.Location = new System.Drawing.Point(12, 56);
            this.tbInstallLocation.Name = "tbInstallLocation";
            this.tbInstallLocation.Size = new System.Drawing.Size(609, 20);
            this.tbInstallLocation.TabIndex = 26;
            // 
            // tbSelectedBuild
            // 
            this.tbSelectedBuild.Location = new System.Drawing.Point(12, 30);
            this.tbSelectedBuild.Name = "tbSelectedBuild";
            this.tbSelectedBuild.ReadOnly = true;
            this.tbSelectedBuild.Size = new System.Drawing.Size(609, 20);
            this.tbSelectedBuild.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Extended";
            // 
            // checkRunDBUpdate
            // 
            this.checkRunDBUpdate.AutoSize = true;
            this.checkRunDBUpdate.Enabled = false;
            this.checkRunDBUpdate.Location = new System.Drawing.Point(157, 19);
            this.checkRunDBUpdate.Name = "checkRunDBUpdate";
            this.checkRunDBUpdate.Size = new System.Drawing.Size(133, 17);
            this.checkRunDBUpdate.TabIndex = 10;
            this.checkRunDBUpdate.Text = "Run Database Update";
            this.checkRunDBUpdate.UseVisualStyleBackColor = true;
            // 
            // checkPlaceholder
            // 
            this.checkPlaceholder.AutoSize = true;
            this.checkPlaceholder.Enabled = false;
            this.checkPlaceholder.Location = new System.Drawing.Point(157, 43);
            this.checkPlaceholder.Name = "checkPlaceholder";
            this.checkPlaceholder.Size = new System.Drawing.Size(82, 17);
            this.checkPlaceholder.TabIndex = 13;
            this.checkPlaceholder.Text = "Placeholder";
            this.checkPlaceholder.UseVisualStyleBackColor = true;
            // 
            // checkOpenInstallFolder
            // 
            this.checkOpenInstallFolder.AutoSize = true;
            this.checkOpenInstallFolder.Enabled = false;
            this.checkOpenInstallFolder.Location = new System.Drawing.Point(7, 19);
            this.checkOpenInstallFolder.Name = "checkOpenInstallFolder";
            this.checkOpenInstallFolder.Size = new System.Drawing.Size(114, 17);
            this.checkOpenInstallFolder.TabIndex = 12;
            this.checkOpenInstallFolder.Text = "Open Install Folder";
            this.checkOpenInstallFolder.UseVisualStyleBackColor = true;
            // 
            // checkLaunchAfterInstall
            // 
            this.checkLaunchAfterInstall.AutoSize = true;
            this.checkLaunchAfterInstall.Enabled = false;
            this.checkLaunchAfterInstall.Location = new System.Drawing.Point(7, 44);
            this.checkLaunchAfterInstall.Name = "checkLaunchAfterInstall";
            this.checkLaunchAfterInstall.Size = new System.Drawing.Size(117, 17);
            this.checkLaunchAfterInstall.TabIndex = 11;
            this.checkLaunchAfterInstall.Text = "Launch After Install";
            this.checkLaunchAfterInstall.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Custom";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkPlaceholder);
            this.groupBox2.Controls.Add(this.checkOpenInstallFolder);
            this.groupBox2.Controls.Add(this.checkLaunchAfterInstall);
            this.groupBox2.Controls.Add(this.checkRunDBUpdate);
            this.groupBox2.Location = new System.Drawing.Point(322, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 78);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Build Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Please enter the location you would like to install the following build to:";
            // 
            // SPGPInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 436);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbCustomDLLList);
            this.Controls.Add(this.lbExtendedDLLList);
            this.Controls.Add(this.tbInstallLocation);
            this.Controls.Add(this.tbSelectedBuild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SPGPInstall";
            this.Text = "SPGPInstall";
            this.Load += new System.EventHandler(this.SPGPInstall_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkAutomationAgentDLLs;
        private System.Windows.Forms.CheckBox checkEDIDLL;
        private System.Windows.Forms.CheckBox checkTPGDLLs;
        private System.Windows.Forms.CheckBox checkExpressPointDLLs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbCustomDLLList;
        private System.Windows.Forms.ListBox lbExtendedDLLList;
        private System.Windows.Forms.TextBox tbInstallLocation;
        private System.Windows.Forms.TextBox tbSelectedBuild;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkRunDBUpdate;
        private System.Windows.Forms.CheckBox checkPlaceholder;
        private System.Windows.Forms.CheckBox checkOpenInstallFolder;
        private System.Windows.Forms.CheckBox checkLaunchAfterInstall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}