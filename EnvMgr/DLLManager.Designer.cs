namespace EnvMgr
{
    partial class DLLManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DLLManager));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDLLs = new System.Windows.Forms.ListBox();
            this.btnGetToBuild = new System.Windows.Forms.Button();
            this.tbToBuild = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCustom = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbExtended = new System.Windows.Forms.ListBox();
            this.btnGetFromBuild = new System.Windows.Forms.Button();
            this.tbFromBuild = new System.Windows.Forms.TextBox();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnCopy);
            this.groupBox2.Controls.Add(this.btnLaunch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbDLLs);
            this.groupBox2.Controls.Add(this.btnGetToBuild);
            this.groupBox2.Controls.Add(this.tbToBuild);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(3, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 268);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To Build";
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(382, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRemove.Location = new System.Drawing.Point(305, 239);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopy.Location = new System.Drawing.Point(228, 239);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLaunch.Location = new System.Drawing.Point(6, 239);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(75, 23);
            this.btnLaunch.TabIndex = 5;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select an installed build to move the selected DLLs to:";
            // 
            // lbDLLs
            // 
            this.lbDLLs.FormattingEnabled = true;
            this.lbDLLs.Location = new System.Drawing.Point(7, 62);
            this.lbDLLs.Name = "lbDLLs";
            this.lbDLLs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDLLs.Size = new System.Drawing.Size(449, 173);
            this.lbDLLs.TabIndex = 3;
            // 
            // btnGetToBuild
            // 
            this.btnGetToBuild.Location = new System.Drawing.Point(432, 38);
            this.btnGetToBuild.Name = "btnGetToBuild";
            this.btnGetToBuild.Size = new System.Drawing.Size(24, 22);
            this.btnGetToBuild.TabIndex = 2;
            this.btnGetToBuild.Text = "...";
            this.btnGetToBuild.UseVisualStyleBackColor = true;
            this.btnGetToBuild.Click += new System.EventHandler(this.btnGetToBuild_Click);
            // 
            // tbToBuild
            // 
            this.tbToBuild.Location = new System.Drawing.Point(8, 39);
            this.tbToBuild.Name = "tbToBuild";
            this.tbToBuild.ReadOnly = true;
            this.tbToBuild.Size = new System.Drawing.Size(424, 20);
            this.tbToBuild.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbCustom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbExtended);
            this.groupBox1.Controls.Add(this.btnGetFromBuild);
            this.groupBox1.Controls.Add(this.tbFromBuild);
            this.groupBox1.Controls.Add(this.cbVersion);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 263);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Build";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(319, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Custom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(87, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Extended";
            // 
            // lbCustom
            // 
            this.lbCustom.FormattingEnabled = true;
            this.lbCustom.Location = new System.Drawing.Point(233, 81);
            this.lbCustom.Name = "lbCustom";
            this.lbCustom.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCustom.Size = new System.Drawing.Size(220, 173);
            this.lbCustom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a SalesPad build folder to pull DLLs from:";
            // 
            // lbExtended
            // 
            this.lbExtended.FormattingEnabled = true;
            this.lbExtended.Location = new System.Drawing.Point(7, 81);
            this.lbExtended.Name = "lbExtended";
            this.lbExtended.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExtended.Size = new System.Drawing.Size(220, 173);
            this.lbExtended.TabIndex = 3;
            // 
            // btnGetFromBuild
            // 
            this.btnGetFromBuild.Location = new System.Drawing.Point(432, 38);
            this.btnGetFromBuild.Name = "btnGetFromBuild";
            this.btnGetFromBuild.Size = new System.Drawing.Size(24, 22);
            this.btnGetFromBuild.TabIndex = 2;
            this.btnGetFromBuild.Text = "...";
            this.btnGetFromBuild.UseVisualStyleBackColor = true;
            this.btnGetFromBuild.Click += new System.EventHandler(this.btnGetFromBuild_Click);
            // 
            // tbFromBuild
            // 
            this.tbFromBuild.Location = new System.Drawing.Point(62, 39);
            this.tbFromBuild.Name = "tbFromBuild";
            this.tbFromBuild.ReadOnly = true;
            this.tbFromBuild.Size = new System.Drawing.Size(370, 20);
            this.tbFromBuild.TabIndex = 1;
            // 
            // cbVersion
            // 
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Items.AddRange(new object[] {
            "x86",
            "x64",
            "Pre"});
            this.cbVersion.Location = new System.Drawing.Point(8, 38);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(51, 21);
            this.cbVersion.TabIndex = 0;
            this.cbVersion.Text = "x86";
            this.cbVersion.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
            // 
            // DLLManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 543);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DLLManager";
            this.Text = "DLLManager";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDLLs;
        private System.Windows.Forms.Button btnGetToBuild;
        private System.Windows.Forms.TextBox tbToBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbCustom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbExtended;
        private System.Windows.Forms.Button btnGetFromBuild;
        private System.Windows.Forms.TextBox tbFromBuild;
        private System.Windows.Forms.ComboBox cbVersion;
    }
}