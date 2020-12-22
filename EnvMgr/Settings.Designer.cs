namespace EnvMgr
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.tbDBDirectory = new System.Windows.Forms.TextBox();
            this.btnDBBackupDirectory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMBDB = new System.Windows.Forms.Button();
            this.tbMBDB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNonMBDB = new System.Windows.Forms.Button();
            this.tbNonMBDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDynamicsDB = new System.Windows.Forms.Button();
            this.tbDynamicsDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDBMethod = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAutoOverwrite = new System.Windows.Forms.CheckBox();
            this.cbAutoInstall = new System.Windows.Forms.CheckBox();
            this.btnSCDirectory = new System.Windows.Forms.Button();
            this.tbSCDirectory = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSPMDirectory = new System.Windows.Forms.Button();
            this.btnDCDirectory = new System.Windows.Forms.Button();
            this.tbSPMDirectory = new System.Windows.Forms.TextBox();
            this.tbDCDirectory = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSPGPx64Directory = new System.Windows.Forms.Button();
            this.btnSPGPx86Directory = new System.Windows.Forms.Button();
            this.tbSPGPx64Directory = new System.Windows.Forms.TextBox();
            this.tbSPGPx86Directory = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTenantName = new System.Windows.Forms.Button();
            this.tbTenantName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB Backup Folder: ";
            // 
            // tbDBDirectory
            // 
            this.tbDBDirectory.Location = new System.Drawing.Point(109, 18);
            this.tbDBDirectory.Name = "tbDBDirectory";
            this.tbDBDirectory.ReadOnly = true;
            this.tbDBDirectory.Size = new System.Drawing.Size(282, 20);
            this.tbDBDirectory.TabIndex = 2;
            // 
            // btnDBBackupDirectory
            // 
            this.btnDBBackupDirectory.Location = new System.Drawing.Point(392, 17);
            this.btnDBBackupDirectory.Name = "btnDBBackupDirectory";
            this.btnDBBackupDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnDBBackupDirectory.TabIndex = 4;
            this.btnDBBackupDirectory.Text = "...";
            this.btnDBBackupDirectory.UseVisualStyleBackColor = true;
            this.btnDBBackupDirectory.Click += new System.EventHandler(this.btnDBBackupDirectory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMBDB);
            this.groupBox1.Controls.Add(this.tbMBDB);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnNonMBDB);
            this.groupBox1.Controls.Add(this.tbNonMBDB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDynamicsDB);
            this.groupBox1.Controls.Add(this.tbDynamicsDB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDBMethod);
            this.groupBox1.Controls.Add(this.btnDBBackupDirectory);
            this.groupBox1.Controls.Add(this.tbDBDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 135);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Management";
            // 
            // btnMBDB
            // 
            this.btnMBDB.Location = new System.Drawing.Point(392, 109);
            this.btnMBDB.Name = "btnMBDB";
            this.btnMBDB.Size = new System.Drawing.Size(24, 22);
            this.btnMBDB.TabIndex = 49;
            this.btnMBDB.Text = "...";
            this.btnMBDB.UseVisualStyleBackColor = true;
            this.btnMBDB.Click += new System.EventHandler(this.btnMBDB_Click);
            // 
            // tbMBDB
            // 
            this.tbMBDB.Location = new System.Drawing.Point(109, 110);
            this.tbMBDB.Name = "tbMBDB";
            this.tbMBDB.ReadOnly = true;
            this.tbMBDB.Size = new System.Drawing.Size(282, 20);
            this.tbMBDB.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(7, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "MB Database:";
            // 
            // btnNonMBDB
            // 
            this.btnNonMBDB.Location = new System.Drawing.Point(392, 85);
            this.btnNonMBDB.Name = "btnNonMBDB";
            this.btnNonMBDB.Size = new System.Drawing.Size(24, 22);
            this.btnNonMBDB.TabIndex = 46;
            this.btnNonMBDB.Text = "...";
            this.btnNonMBDB.UseVisualStyleBackColor = true;
            this.btnNonMBDB.Click += new System.EventHandler(this.btnNonMBDB_Click);
            // 
            // tbNonMBDB
            // 
            this.tbNonMBDB.Location = new System.Drawing.Point(109, 86);
            this.tbNonMBDB.Name = "tbNonMBDB";
            this.tbNonMBDB.ReadOnly = true;
            this.tbNonMBDB.Size = new System.Drawing.Size(282, 20);
            this.tbNonMBDB.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Non-MB Database:";
            // 
            // btnDynamicsDB
            // 
            this.btnDynamicsDB.Location = new System.Drawing.Point(392, 61);
            this.btnDynamicsDB.Name = "btnDynamicsDB";
            this.btnDynamicsDB.Size = new System.Drawing.Size(24, 22);
            this.btnDynamicsDB.TabIndex = 43;
            this.btnDynamicsDB.Text = "...";
            this.btnDynamicsDB.UseVisualStyleBackColor = true;
            this.btnDynamicsDB.Click += new System.EventHandler(this.btnDynamicsDB_Click);
            // 
            // tbDynamicsDB
            // 
            this.tbDynamicsDB.Location = new System.Drawing.Point(109, 62);
            this.tbDynamicsDB.Name = "tbDynamicsDB";
            this.tbDynamicsDB.ReadOnly = true;
            this.tbDynamicsDB.Size = new System.Drawing.Size(282, 20);
            this.tbDynamicsDB.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Dynamics Database:";
            // 
            // cbDBMethod
            // 
            this.cbDBMethod.AutoSize = true;
            this.cbDBMethod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbDBMethod.Location = new System.Drawing.Point(10, 44);
            this.cbDBMethod.Name = "cbDBMethod";
            this.cbDBMethod.Size = new System.Drawing.Size(299, 17);
            this.cbDBMethod.TabIndex = 5;
            this.cbDBMethod.Text = "Manually Select Databases to Backup/Restore/Overwrite";
            this.cbDBMethod.UseVisualStyleBackColor = true;
            this.cbDBMethod.CheckedChanged += new System.EventHandler(this.cbDBMethod_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(350, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAutoOverwrite);
            this.groupBox2.Controls.Add(this.cbAutoInstall);
            this.groupBox2.Controls.Add(this.btnSCDirectory);
            this.groupBox2.Controls.Add(this.tbSCDirectory);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSPMDirectory);
            this.groupBox2.Controls.Add(this.btnDCDirectory);
            this.groupBox2.Controls.Add(this.tbSPMDirectory);
            this.groupBox2.Controls.Add(this.tbDCDirectory);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnSPGPx64Directory);
            this.groupBox2.Controls.Add(this.btnSPGPx86Directory);
            this.groupBox2.Controls.Add(this.tbSPGPx64Directory);
            this.groupBox2.Controls.Add(this.tbSPGPx86Directory);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(2, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 184);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Build Management";
            // 
            // cbAutoOverwrite
            // 
            this.cbAutoOverwrite.AutoSize = true;
            this.cbAutoOverwrite.Enabled = false;
            this.cbAutoOverwrite.Location = new System.Drawing.Point(9, 162);
            this.cbAutoOverwrite.Name = "cbAutoOverwrite";
            this.cbAutoOverwrite.Size = new System.Drawing.Size(255, 17);
            this.cbAutoOverwrite.TabIndex = 33;
            this.cbAutoOverwrite.Text = "Automatically overwrite existing install if duplicate";
            this.cbAutoOverwrite.UseVisualStyleBackColor = true;
            // 
            // cbAutoInstall
            // 
            this.cbAutoInstall.AutoSize = true;
            this.cbAutoInstall.Enabled = false;
            this.cbAutoInstall.Location = new System.Drawing.Point(9, 139);
            this.cbAutoInstall.Name = "cbAutoInstall";
            this.cbAutoInstall.Size = new System.Drawing.Size(204, 17);
            this.cbAutoInstall.TabIndex = 32;
            this.cbAutoInstall.Text = "Automatically install using default path";
            this.cbAutoInstall.UseVisualStyleBackColor = true;
            // 
            // btnSCDirectory
            // 
            this.btnSCDirectory.Location = new System.Drawing.Point(392, 113);
            this.btnSCDirectory.Name = "btnSCDirectory";
            this.btnSCDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnSCDirectory.TabIndex = 31;
            this.btnSCDirectory.Text = "...";
            this.btnSCDirectory.UseVisualStyleBackColor = true;
            this.btnSCDirectory.Click += new System.EventHandler(this.btnSCDirectory_Click);
            // 
            // tbSCDirectory
            // 
            this.tbSCDirectory.Location = new System.Drawing.Point(109, 114);
            this.tbSCDirectory.Name = "tbSCDirectory";
            this.tbSCDirectory.ReadOnly = true;
            this.tbSCDirectory.Size = new System.Drawing.Size(282, 20);
            this.tbSCDirectory.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Ship Center:";
            // 
            // btnSPMDirectory
            // 
            this.btnSPMDirectory.Location = new System.Drawing.Point(392, 89);
            this.btnSPMDirectory.Name = "btnSPMDirectory";
            this.btnSPMDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnSPMDirectory.TabIndex = 28;
            this.btnSPMDirectory.Text = "...";
            this.btnSPMDirectory.UseVisualStyleBackColor = true;
            this.btnSPMDirectory.Click += new System.EventHandler(this.btnSPMDirectory_Click);
            // 
            // btnDCDirectory
            // 
            this.btnDCDirectory.Location = new System.Drawing.Point(392, 65);
            this.btnDCDirectory.Name = "btnDCDirectory";
            this.btnDCDirectory.Size = new System.Drawing.Size(24, 22);
            this.btnDCDirectory.TabIndex = 27;
            this.btnDCDirectory.Text = "...";
            this.btnDCDirectory.UseVisualStyleBackColor = true;
            this.btnDCDirectory.Click += new System.EventHandler(this.btnDCDirectory_Click);
            // 
            // tbSPMDirectory
            // 
            this.tbSPMDirectory.Location = new System.Drawing.Point(109, 90);
            this.tbSPMDirectory.Name = "tbSPMDirectory";
            this.tbSPMDirectory.ReadOnly = true;
            this.tbSPMDirectory.Size = new System.Drawing.Size(282, 20);
            this.tbSPMDirectory.TabIndex = 26;
            // 
            // tbDCDirectory
            // 
            this.tbDCDirectory.Location = new System.Drawing.Point(109, 66);
            this.tbDCDirectory.Name = "tbDCDirectory";
            this.tbDCDirectory.ReadOnly = true;
            this.tbDCDirectory.Size = new System.Drawing.Size(282, 20);
            this.tbDCDirectory.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "SalesPad Mobile:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "DataCollection:";
            // 
            // btnSPGPx64Directory
            // 
            this.btnSPGPx64Directory.Location = new System.Drawing.Point(392, 42);
            this.btnSPGPx64Directory.Name = "btnSPGPx64Directory";
            this.btnSPGPx64Directory.Size = new System.Drawing.Size(24, 22);
            this.btnSPGPx64Directory.TabIndex = 22;
            this.btnSPGPx64Directory.Text = "...";
            this.btnSPGPx64Directory.UseVisualStyleBackColor = true;
            this.btnSPGPx64Directory.Click += new System.EventHandler(this.btnSPGPx64Directory_Click);
            // 
            // btnSPGPx86Directory
            // 
            this.btnSPGPx86Directory.Location = new System.Drawing.Point(392, 18);
            this.btnSPGPx86Directory.Name = "btnSPGPx86Directory";
            this.btnSPGPx86Directory.Size = new System.Drawing.Size(24, 22);
            this.btnSPGPx86Directory.TabIndex = 21;
            this.btnSPGPx86Directory.Text = "...";
            this.btnSPGPx86Directory.UseVisualStyleBackColor = true;
            this.btnSPGPx86Directory.Click += new System.EventHandler(this.btnSPGPx86Directory_Click);
            // 
            // tbSPGPx64Directory
            // 
            this.tbSPGPx64Directory.Location = new System.Drawing.Point(109, 43);
            this.tbSPGPx64Directory.Name = "tbSPGPx64Directory";
            this.tbSPGPx64Directory.ReadOnly = true;
            this.tbSPGPx64Directory.Size = new System.Drawing.Size(282, 20);
            this.tbSPGPx64Directory.TabIndex = 20;
            // 
            // tbSPGPx86Directory
            // 
            this.tbSPGPx86Directory.Location = new System.Drawing.Point(109, 19);
            this.tbSPGPx86Directory.Name = "tbSPGPx86Directory";
            this.tbSPGPx86Directory.ReadOnly = true;
            this.tbSPGPx86Directory.Size = new System.Drawing.Size(282, 20);
            this.tbSPGPx86Directory.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "SalesPad GP x64:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "SalesPad GP x86:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(80, 385);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(3, 385);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTenantName);
            this.groupBox3.Controls.Add(this.tbTenantName);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(2, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 48);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cloud Management";
            // 
            // btnTenantName
            // 
            this.btnTenantName.Location = new System.Drawing.Point(392, 19);
            this.btnTenantName.Name = "btnTenantName";
            this.btnTenantName.Size = new System.Drawing.Size(24, 22);
            this.btnTenantName.TabIndex = 24;
            this.btnTenantName.Text = "...";
            this.btnTenantName.UseVisualStyleBackColor = true;
            this.btnTenantName.Click += new System.EventHandler(this.btnTenantName_Click);
            // 
            // tbTenantName
            // 
            this.tbTenantName.Location = new System.Drawing.Point(109, 20);
            this.tbTenantName.Name = "tbTenantName";
            this.tbTenantName.ReadOnly = true;
            this.tbTenantName.Size = new System.Drawing.Size(282, 20);
            this.tbTenantName.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(7, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Tenant Name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(2, 144);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 184);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Build Management";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(9, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(255, 17);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Automatically overwrite existing install if duplicate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox2.Location = new System.Drawing.Point(9, 139);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(204, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "Automatically install using default path";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 22);
            this.button1.TabIndex = 31;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSCDirectory_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(282, 20);
            this.textBox1.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Ship Center:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 22);
            this.button2.TabIndex = 28;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSPMDirectory_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 22);
            this.button3.TabIndex = 27;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDCDirectory_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(109, 90);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(282, 20);
            this.textBox2.TabIndex = 26;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(109, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(282, 20);
            this.textBox3.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(7, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "SalesPad Mobile:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "DataCollection:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(392, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 22);
            this.button4.TabIndex = 22;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSPGPx64Directory_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(392, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 22);
            this.button5.TabIndex = 21;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnSPGPx86Directory_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(109, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(282, 20);
            this.textBox4.TabIndex = 20;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(109, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(282, 20);
            this.textBox5.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(7, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "SalesPad GP x64:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(7, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "SalesPad GP x86:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 410);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDBDirectory;
        private System.Windows.Forms.Button btnDBBackupDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSCDirectory;
        private System.Windows.Forms.TextBox tbSCDirectory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSPMDirectory;
        private System.Windows.Forms.Button btnDCDirectory;
        private System.Windows.Forms.TextBox tbSPMDirectory;
        private System.Windows.Forms.TextBox tbDCDirectory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSPGPx64Directory;
        private System.Windows.Forms.Button btnSPGPx86Directory;
        private System.Windows.Forms.TextBox tbSPGPx64Directory;
        private System.Windows.Forms.TextBox tbSPGPx86Directory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTenantName;
        private System.Windows.Forms.TextBox tbTenantName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbDBMethod;
        private System.Windows.Forms.Button btnMBDB;
        private System.Windows.Forms.TextBox tbMBDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNonMBDB;
        private System.Windows.Forms.TextBox tbNonMBDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDynamicsDB;
        private System.Windows.Forms.TextBox tbDynamicsDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAutoOverwrite;
        private System.Windows.Forms.CheckBox cbAutoInstall;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}