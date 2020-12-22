﻿namespace EnvMgr
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDatabaseVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesPadDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobileSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeCloudEnvironmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeGPDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killSalesPadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLaunchGPUtils = new System.Windows.Forms.Button();
            this.checkManufacturingToggle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLaunchSelectedGP = new System.Windows.Forms.Button();
            this.cbGPListToInstall = new System.Windows.Forms.ComboBox();
            this.btnInstallGP = new System.Windows.Forms.Button();
            this.lbGPVersionsInstalled = new System.Windows.Forms.ListBox();
            this.labelGPInstallationList = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvInstalledSQLServers = new System.Windows.Forms.ListView();
            this.chService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnStopAllServices = new System.Windows.Forms.Button();
            this.labelSQLVersions = new System.Windows.Forms.Label();
            this.btnInstallService = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteBackup = new System.Windows.Forms.Button();
            this.btnNewDB = new System.Windows.Forms.Button();
            this.btnOverwriteDB = new System.Windows.Forms.Button();
            this.tbDBDesc = new System.Windows.Forms.TextBox();
            this.btnRestoreDB = new System.Windows.Forms.Button();
            this.btnDBBackupDescription = new System.Windows.Forms.Button();
            this.btnDBBackupFolder = new System.Windows.Forms.Button();
            this.cbDatabaseList = new System.Windows.Forms.ComboBox();
            this.cbSelectedGP = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuildFolder = new System.Windows.Forms.Button();
            this.cbSPGPVersion = new System.Windows.Forms.ComboBox();
            this.btnDLLManager = new System.Windows.Forms.Button();
            this.cbProductList = new System.Windows.Forms.ComboBox();
            this.btnLaunchProduct = new System.Windows.Forms.Button();
            this.btnInstallProduct = new System.Windows.Forms.Button();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.labelReloadIPAddress = new System.Windows.Forms.Label();
            this.cbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilitiesToolStripMenuItem,
            this.resetDatabaseVersionToolStripMenuItem,
            this.deleteBuildsToolStripMenuItem,
            this.databaseLogToolStripMenuItem,
            this.purgeCloudEnvironmentsToolStripMenuItem,
            this.backupBackupsToolStripMenuItem,
            this.purgeGPDatabasesToolStripMenuItem,
            this.killSalesPadToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            this.utilitiesToolStripMenuItem.Click += new System.EventHandler(this.utilitiesToolStripMenuItem_Click);
            // 
            // resetDatabaseVersionToolStripMenuItem
            // 
            this.resetDatabaseVersionToolStripMenuItem.Name = "resetDatabaseVersionToolStripMenuItem";
            this.resetDatabaseVersionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.resetDatabaseVersionToolStripMenuItem.Text = "Reset Database Version";
            this.resetDatabaseVersionToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseVersionToolStripMenuItem_Click);
            // 
            // deleteBuildsToolStripMenuItem
            // 
            this.deleteBuildsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesPadDesktopToolStripMenuItem,
            this.dataCollectionToolStripMenuItem,
            this.mobileSToolStripMenuItem,
            this.shipCenterToolStripMenuItem});
            this.deleteBuildsToolStripMenuItem.Name = "deleteBuildsToolStripMenuItem";
            this.deleteBuildsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.deleteBuildsToolStripMenuItem.Text = "Delete Builds";
            // 
            // salesPadDesktopToolStripMenuItem
            // 
            this.salesPadDesktopToolStripMenuItem.Name = "salesPadDesktopToolStripMenuItem";
            this.salesPadDesktopToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.salesPadDesktopToolStripMenuItem.Text = "SalesPad Desktop";
            this.salesPadDesktopToolStripMenuItem.Click += new System.EventHandler(this.salesPadDesktopToolStripMenuItem_Click);
            // 
            // dataCollectionToolStripMenuItem
            // 
            this.dataCollectionToolStripMenuItem.Name = "dataCollectionToolStripMenuItem";
            this.dataCollectionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.dataCollectionToolStripMenuItem.Text = "DataCollection";
            this.dataCollectionToolStripMenuItem.Click += new System.EventHandler(this.dataCollectionToolStripMenuItem_Click);
            // 
            // mobileSToolStripMenuItem
            // 
            this.mobileSToolStripMenuItem.Name = "mobileSToolStripMenuItem";
            this.mobileSToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.mobileSToolStripMenuItem.Text = "Mobile Server";
            this.mobileSToolStripMenuItem.Click += new System.EventHandler(this.mobileSToolStripMenuItem_Click);
            // 
            // shipCenterToolStripMenuItem
            // 
            this.shipCenterToolStripMenuItem.Name = "shipCenterToolStripMenuItem";
            this.shipCenterToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.shipCenterToolStripMenuItem.Text = "Ship Center";
            this.shipCenterToolStripMenuItem.Click += new System.EventHandler(this.shipCenterToolStripMenuItem_Click);
            // 
            // databaseLogToolStripMenuItem
            // 
            this.databaseLogToolStripMenuItem.Name = "databaseLogToolStripMenuItem";
            this.databaseLogToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.databaseLogToolStripMenuItem.Text = "Database Log";
            this.databaseLogToolStripMenuItem.Click += new System.EventHandler(this.databaseLogToolStripMenuItem_Click);
            // 
            // purgeCloudEnvironmentsToolStripMenuItem
            // 
            this.purgeCloudEnvironmentsToolStripMenuItem.Name = "purgeCloudEnvironmentsToolStripMenuItem";
            this.purgeCloudEnvironmentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.purgeCloudEnvironmentsToolStripMenuItem.Text = "Purge Cloud Environments";
            this.purgeCloudEnvironmentsToolStripMenuItem.Click += new System.EventHandler(this.purgeCloudEnvironmentsToolStripMenuItem_Click);
            // 
            // backupBackupsToolStripMenuItem
            // 
            this.backupBackupsToolStripMenuItem.Name = "backupBackupsToolStripMenuItem";
            this.backupBackupsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.backupBackupsToolStripMenuItem.Text = "Backup Backups";
            this.backupBackupsToolStripMenuItem.Click += new System.EventHandler(this.backupBackupsToolStripMenuItem_Click);
            // 
            // purgeGPDatabasesToolStripMenuItem
            // 
            this.purgeGPDatabasesToolStripMenuItem.Name = "purgeGPDatabasesToolStripMenuItem";
            this.purgeGPDatabasesToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.purgeGPDatabasesToolStripMenuItem.Text = "Purge GP Databases";
            this.purgeGPDatabasesToolStripMenuItem.Click += new System.EventHandler(this.purgeGPDatabasesToolStripMenuItem_Click);
            // 
            // killSalesPadToolStripMenuItem
            // 
            this.killSalesPadToolStripMenuItem.Name = "killSalesPadToolStripMenuItem";
            this.killSalesPadToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.killSalesPadToolStripMenuItem.Text = "Kill SalesPad";
            this.killSalesPadToolStripMenuItem.Click += new System.EventHandler(this.killSalesPadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLaunchGPUtils);
            this.groupBox1.Controls.Add(this.checkManufacturingToggle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLaunchSelectedGP);
            this.groupBox1.Controls.Add(this.cbGPListToInstall);
            this.groupBox1.Controls.Add(this.btnInstallGP);
            this.groupBox1.Controls.Add(this.lbGPVersionsInstalled);
            this.groupBox1.Controls.Add(this.labelGPInstallationList);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamics GP Management";
            // 
            // btnLaunchGPUtils
            // 
            this.btnLaunchGPUtils.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLaunchGPUtils.Location = new System.Drawing.Point(126, 146);
            this.btnLaunchGPUtils.Name = "btnLaunchGPUtils";
            this.btnLaunchGPUtils.Size = new System.Drawing.Size(121, 23);
            this.btnLaunchGPUtils.TabIndex = 7;
            this.btnLaunchGPUtils.Text = "Launch GP Utils";
            this.btnLaunchGPUtils.UseVisualStyleBackColor = true;
            this.btnLaunchGPUtils.Click += new System.EventHandler(this.btnLaunchGPUtils_Click);
            // 
            // checkManufacturingToggle
            // 
            this.checkManufacturingToggle.AutoSize = true;
            this.checkManufacturingToggle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkManufacturingToggle.Location = new System.Drawing.Point(156, 182);
            this.checkManufacturingToggle.Name = "checkManufacturingToggle";
            this.checkManufacturingToggle.Size = new System.Drawing.Size(94, 17);
            this.checkManufacturingToggle.TabIndex = 6;
            this.checkManufacturingToggle.Text = "Manufacturing";
            this.checkManufacturingToggle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(5, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Install GP:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnLaunchSelectedGP
            // 
            this.btnLaunchSelectedGP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLaunchSelectedGP.Location = new System.Drawing.Point(5, 146);
            this.btnLaunchSelectedGP.Name = "btnLaunchSelectedGP";
            this.btnLaunchSelectedGP.Size = new System.Drawing.Size(121, 23);
            this.btnLaunchSelectedGP.TabIndex = 4;
            this.btnLaunchSelectedGP.Text = "Launch GP";
            this.btnLaunchSelectedGP.UseVisualStyleBackColor = true;
            this.btnLaunchSelectedGP.Click += new System.EventHandler(this.btnLaunchSelectedGP_Click);
            // 
            // cbGPListToInstall
            // 
            this.cbGPListToInstall.FormattingEnabled = true;
            this.cbGPListToInstall.Location = new System.Drawing.Point(6, 200);
            this.cbGPListToInstall.Name = "cbGPListToInstall";
            this.cbGPListToInstall.Size = new System.Drawing.Size(240, 21);
            this.cbGPListToInstall.TabIndex = 3;
            this.cbGPListToInstall.Text = "Select a GP Version To Install";
            this.cbGPListToInstall.SelectedIndexChanged += new System.EventHandler(this.cbGPListToInstall_SelectedIndexChanged);
            // 
            // btnInstallGP
            // 
            this.btnInstallGP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInstallGP.Location = new System.Drawing.Point(5, 222);
            this.btnInstallGP.Name = "btnInstallGP";
            this.btnInstallGP.Size = new System.Drawing.Size(242, 23);
            this.btnInstallGP.TabIndex = 2;
            this.btnInstallGP.Text = "Install GP";
            this.btnInstallGP.UseVisualStyleBackColor = true;
            this.btnInstallGP.Click += new System.EventHandler(this.btnInstallGP_Click);
            // 
            // lbGPVersionsInstalled
            // 
            this.lbGPVersionsInstalled.FormattingEnabled = true;
            this.lbGPVersionsInstalled.Location = new System.Drawing.Point(6, 37);
            this.lbGPVersionsInstalled.Name = "lbGPVersionsInstalled";
            this.lbGPVersionsInstalled.Size = new System.Drawing.Size(240, 108);
            this.lbGPVersionsInstalled.TabIndex = 1;
            // 
            // labelGPInstallationList
            // 
            this.labelGPInstallationList.AutoSize = true;
            this.labelGPInstallationList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelGPInstallationList.Location = new System.Drawing.Point(7, 20);
            this.labelGPInstallationList.Name = "labelGPInstallationList";
            this.labelGPInstallationList.Size = new System.Drawing.Size(83, 13);
            this.labelGPInstallationList.TabIndex = 0;
            this.labelGPInstallationList.Text = "GP Installations:";
            this.labelGPInstallationList.Click += new System.EventHandler(this.labelGPInstallationList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvInstalledSQLServers);
            this.groupBox2.Controls.Add(this.btnStopService);
            this.groupBox2.Controls.Add(this.btnStartService);
            this.groupBox2.Controls.Add(this.btnStopAllServices);
            this.groupBox2.Controls.Add(this.labelSQLVersions);
            this.groupBox2.Controls.Add(this.btnInstallService);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(263, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 251);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SQL Server Management";
            // 
            // lvInstalledSQLServers
            // 
            this.lvInstalledSQLServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chService,
            this.chStatus});
            this.lvInstalledSQLServers.FullRowSelect = true;
            this.lvInstalledSQLServers.GridLines = true;
            this.lvInstalledSQLServers.HideSelection = false;
            this.lvInstalledSQLServers.Location = new System.Drawing.Point(6, 37);
            this.lvInstalledSQLServers.Name = "lvInstalledSQLServers";
            this.lvInstalledSQLServers.Size = new System.Drawing.Size(240, 157);
            this.lvInstalledSQLServers.TabIndex = 11;
            this.lvInstalledSQLServers.UseCompatibleStateImageBehavior = false;
            this.lvInstalledSQLServers.View = System.Windows.Forms.View.Details;
            // 
            // chService
            // 
            this.chService.Text = "Service";
            this.chService.Width = 118;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 118;
            // 
            // btnStopService
            // 
            this.btnStopService.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStopService.Location = new System.Drawing.Point(126, 199);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(121, 23);
            this.btnStopService.TabIndex = 10;
            this.btnStopService.Text = "Stop Service";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartService.Location = new System.Drawing.Point(5, 199);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(121, 23);
            this.btnStartService.TabIndex = 9;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnStopAllServices
            // 
            this.btnStopAllServices.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStopAllServices.Location = new System.Drawing.Point(126, 222);
            this.btnStopAllServices.Name = "btnStopAllServices";
            this.btnStopAllServices.Size = new System.Drawing.Size(121, 23);
            this.btnStopAllServices.TabIndex = 8;
            this.btnStopAllServices.Text = "Stop All Services";
            this.btnStopAllServices.UseVisualStyleBackColor = true;
            this.btnStopAllServices.Click += new System.EventHandler(this.btnStopAllServices_Click);
            // 
            // labelSQLVersions
            // 
            this.labelSQLVersions.AutoSize = true;
            this.labelSQLVersions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSQLVersions.Location = new System.Drawing.Point(6, 20);
            this.labelSQLVersions.Name = "labelSQLVersions";
            this.labelSQLVersions.Size = new System.Drawing.Size(70, 13);
            this.labelSQLVersions.TabIndex = 3;
            this.labelSQLVersions.Text = "SQL Servers:";
            this.labelSQLVersions.Click += new System.EventHandler(this.labelSQLVersions_Click);
            // 
            // btnInstallService
            // 
            this.btnInstallService.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInstallService.Location = new System.Drawing.Point(5, 222);
            this.btnInstallService.Name = "btnInstallService";
            this.btnInstallService.Size = new System.Drawing.Size(121, 23);
            this.btnInstallService.TabIndex = 7;
            this.btnInstallService.Text = "Install Service";
            this.btnInstallService.UseVisualStyleBackColor = true;
            this.btnInstallService.Click += new System.EventHandler(this.btnInstallService_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteBackup);
            this.groupBox3.Controls.Add(this.btnNewDB);
            this.groupBox3.Controls.Add(this.btnOverwriteDB);
            this.groupBox3.Controls.Add(this.tbDBDesc);
            this.groupBox3.Controls.Add(this.btnRestoreDB);
            this.groupBox3.Controls.Add(this.btnDBBackupDescription);
            this.groupBox3.Controls.Add(this.btnDBBackupFolder);
            this.groupBox3.Controls.Add(this.cbDatabaseList);
            this.groupBox3.Controls.Add(this.cbSelectedGP);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(5, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 235);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Database Management";
            // 
            // btnDeleteBackup
            // 
            this.btnDeleteBackup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteBackup.Location = new System.Drawing.Point(380, 206);
            this.btnDeleteBackup.Name = "btnDeleteBackup";
            this.btnDeleteBackup.Size = new System.Drawing.Size(125, 23);
            this.btnDeleteBackup.TabIndex = 8;
            this.btnDeleteBackup.Text = "Delete DB Backup";
            this.btnDeleteBackup.UseVisualStyleBackColor = true;
            this.btnDeleteBackup.Click += new System.EventHandler(this.btnDeleteBackup_Click);
            // 
            // btnNewDB
            // 
            this.btnNewDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewDB.Location = new System.Drawing.Point(255, 206);
            this.btnNewDB.Name = "btnNewDB";
            this.btnNewDB.Size = new System.Drawing.Size(125, 23);
            this.btnNewDB.TabIndex = 7;
            this.btnNewDB.Text = "New DB Backup";
            this.btnNewDB.UseVisualStyleBackColor = true;
            this.btnNewDB.Click += new System.EventHandler(this.btnNewDB_Click);
            // 
            // btnOverwriteDB
            // 
            this.btnOverwriteDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOverwriteDB.Location = new System.Drawing.Point(130, 206);
            this.btnOverwriteDB.Name = "btnOverwriteDB";
            this.btnOverwriteDB.Size = new System.Drawing.Size(125, 23);
            this.btnOverwriteDB.TabIndex = 6;
            this.btnOverwriteDB.Text = "Overwrite DB";
            this.btnOverwriteDB.UseVisualStyleBackColor = true;
            this.btnOverwriteDB.Click += new System.EventHandler(this.btnOverwriteDB_Click);
            // 
            // tbDBDesc
            // 
            this.tbDBDesc.Location = new System.Drawing.Point(6, 46);
            this.tbDBDesc.Multiline = true;
            this.tbDBDesc.Name = "tbDBDesc";
            this.tbDBDesc.ReadOnly = true;
            this.tbDBDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDBDesc.Size = new System.Drawing.Size(498, 157);
            this.tbDBDesc.TabIndex = 5;
            // 
            // btnRestoreDB
            // 
            this.btnRestoreDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRestoreDB.Location = new System.Drawing.Point(5, 206);
            this.btnRestoreDB.Name = "btnRestoreDB";
            this.btnRestoreDB.Size = new System.Drawing.Size(125, 23);
            this.btnRestoreDB.TabIndex = 4;
            this.btnRestoreDB.Text = "Restore DB";
            this.btnRestoreDB.UseVisualStyleBackColor = true;
            this.btnRestoreDB.Click += new System.EventHandler(this.btnRestoreDB_Click);
            // 
            // btnDBBackupDescription
            // 
            this.btnDBBackupDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDBBackupDescription.Image = ((System.Drawing.Image)(resources.GetObject("btnDBBackupDescription.Image")));
            this.btnDBBackupDescription.Location = new System.Drawing.Point(482, 19);
            this.btnDBBackupDescription.Name = "btnDBBackupDescription";
            this.btnDBBackupDescription.Size = new System.Drawing.Size(23, 23);
            this.btnDBBackupDescription.TabIndex = 3;
            this.btnDBBackupDescription.UseVisualStyleBackColor = true;
            this.btnDBBackupDescription.Click += new System.EventHandler(this.btnDBBackupDescription_Click);
            // 
            // btnDBBackupFolder
            // 
            this.btnDBBackupFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDBBackupFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnDBBackupFolder.Image")));
            this.btnDBBackupFolder.Location = new System.Drawing.Point(458, 19);
            this.btnDBBackupFolder.Name = "btnDBBackupFolder";
            this.btnDBBackupFolder.Size = new System.Drawing.Size(23, 23);
            this.btnDBBackupFolder.TabIndex = 2;
            this.btnDBBackupFolder.UseVisualStyleBackColor = true;
            this.btnDBBackupFolder.Click += new System.EventHandler(this.btnDBBackupFolder_Click);
            // 
            // cbDatabaseList
            // 
            this.cbDatabaseList.FormattingEnabled = true;
            this.cbDatabaseList.Location = new System.Drawing.Point(86, 20);
            this.cbDatabaseList.Name = "cbDatabaseList";
            this.cbDatabaseList.Size = new System.Drawing.Size(370, 21);
            this.cbDatabaseList.TabIndex = 1;
            this.cbDatabaseList.Text = "Select a Database";
            this.cbDatabaseList.SelectedIndexChanged += new System.EventHandler(this.cbDatabaseList_SelectedIndexChanged);
            // 
            // cbSelectedGP
            // 
            this.cbSelectedGP.FormattingEnabled = true;
            this.cbSelectedGP.Items.AddRange(new object[] {
            "GP10",
            "GP2010",
            "GP2013",
            "GP2015",
            "GP2016",
            "GP2018",
            "GP2019"});
            this.cbSelectedGP.Location = new System.Drawing.Point(6, 20);
            this.cbSelectedGP.Name = "cbSelectedGP";
            this.cbSelectedGP.Size = new System.Drawing.Size(76, 21);
            this.cbSelectedGP.TabIndex = 0;
            this.cbSelectedGP.Text = "Select GP";
            this.cbSelectedGP.SelectedIndexChanged += new System.EventHandler(this.cbSelectedGP_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuildFolder);
            this.groupBox4.Controls.Add(this.cbSPGPVersion);
            this.groupBox4.Controls.Add(this.btnDLLManager);
            this.groupBox4.Controls.Add(this.cbProductList);
            this.groupBox4.Controls.Add(this.btnLaunchProduct);
            this.groupBox4.Controls.Add(this.btnInstallProduct);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(5, 518);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(510, 70);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Build Management";
            // 
            // btnBuildFolder
            // 
            this.btnBuildFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuildFolder.Location = new System.Drawing.Point(380, 42);
            this.btnBuildFolder.Name = "btnBuildFolder";
            this.btnBuildFolder.Size = new System.Drawing.Size(125, 23);
            this.btnBuildFolder.TabIndex = 12;
            this.btnBuildFolder.Text = "Build Folder";
            this.btnBuildFolder.UseVisualStyleBackColor = true;
            this.btnBuildFolder.Click += new System.EventHandler(this.btnBuildFolder_Click);
            // 
            // cbSPGPVersion
            // 
            this.cbSPGPVersion.Enabled = false;
            this.cbSPGPVersion.FormattingEnabled = true;
            this.cbSPGPVersion.Items.AddRange(new object[] {
            "x86",
            "x64",
            "Pre"});
            this.cbSPGPVersion.Location = new System.Drawing.Point(435, 18);
            this.cbSPGPVersion.Name = "cbSPGPVersion";
            this.cbSPGPVersion.Size = new System.Drawing.Size(68, 21);
            this.cbSPGPVersion.TabIndex = 1;
            this.cbSPGPVersion.Text = "x86";
            // 
            // btnDLLManager
            // 
            this.btnDLLManager.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDLLManager.Location = new System.Drawing.Point(255, 42);
            this.btnDLLManager.Name = "btnDLLManager";
            this.btnDLLManager.Size = new System.Drawing.Size(125, 23);
            this.btnDLLManager.TabIndex = 11;
            this.btnDLLManager.Text = "DLL Manager";
            this.btnDLLManager.UseVisualStyleBackColor = true;
            this.btnDLLManager.Click += new System.EventHandler(this.btnDLLManager_Click);
            // 
            // cbProductList
            // 
            this.cbProductList.FormattingEnabled = true;
            this.cbProductList.Items.AddRange(new object[] {
            "SalesPad Desktop",
            "DataCollection",
            "SalesPad Mobile",
            "ShipCenter"});
            this.cbProductList.Location = new System.Drawing.Point(6, 18);
            this.cbProductList.Name = "cbProductList";
            this.cbProductList.Size = new System.Drawing.Size(425, 21);
            this.cbProductList.TabIndex = 0;
            this.cbProductList.Text = "Select a Product";
            this.cbProductList.SelectedIndexChanged += new System.EventHandler(this.cbProductList_SelectedIndexChanged);
            // 
            // btnLaunchProduct
            // 
            this.btnLaunchProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLaunchProduct.Location = new System.Drawing.Point(130, 42);
            this.btnLaunchProduct.Name = "btnLaunchProduct";
            this.btnLaunchProduct.Size = new System.Drawing.Size(125, 23);
            this.btnLaunchProduct.TabIndex = 10;
            this.btnLaunchProduct.Text = "Launch Product";
            this.btnLaunchProduct.UseVisualStyleBackColor = true;
            this.btnLaunchProduct.Click += new System.EventHandler(this.btnLaunchProduct_Click);
            // 
            // btnInstallProduct
            // 
            this.btnInstallProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInstallProduct.Location = new System.Drawing.Point(5, 42);
            this.btnInstallProduct.Name = "btnInstallProduct";
            this.btnInstallProduct.Size = new System.Drawing.Size(125, 23);
            this.btnInstallProduct.TabIndex = 9;
            this.btnInstallProduct.Text = "Install";
            this.btnInstallProduct.UseVisualStyleBackColor = true;
            this.btnInstallProduct.Click += new System.EventHandler(this.btnInstallProduct_Click);
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(386, 590);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.ReadOnly = true;
            this.tbIPAddress.Size = new System.Drawing.Size(123, 20);
            this.tbIPAddress.TabIndex = 4;
            this.tbIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReloadIPAddress
            // 
            this.labelReloadIPAddress.AutoSize = true;
            this.labelReloadIPAddress.Location = new System.Drawing.Point(324, 593);
            this.labelReloadIPAddress.Name = "labelReloadIPAddress";
            this.labelReloadIPAddress.Size = new System.Drawing.Size(61, 13);
            this.labelReloadIPAddress.TabIndex = 5;
            this.labelReloadIPAddress.Text = "IP Address:";
            this.labelReloadIPAddress.Click += new System.EventHandler(this.labelReloadIPAddress_Click);
            // 
            // cbAlwaysOnTop
            // 
            this.cbAlwaysOnTop.AutoSize = true;
            this.cbAlwaysOnTop.Location = new System.Drawing.Point(11, 592);
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.Size = new System.Drawing.Size(98, 17);
            this.cbAlwaysOnTop.TabIndex = 6;
            this.cbAlwaysOnTop.Text = "Always On Top";
            this.cbAlwaysOnTop.UseVisualStyleBackColor = true;
            this.cbAlwaysOnTop.CheckedChanged += new System.EventHandler(this.cbAlwaysOnTop_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 615);
            this.Controls.Add(this.cbAlwaysOnTop);
            this.Controls.Add(this.labelReloadIPAddress);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Environment Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkManufacturingToggle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLaunchSelectedGP;
        private System.Windows.Forms.ComboBox cbGPListToInstall;
        private System.Windows.Forms.Button btnInstallGP;
        private System.Windows.Forms.ListBox lbGPVersionsInstalled;
        private System.Windows.Forms.Label labelGPInstallationList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lvInstalledSQLServers;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopAllServices;
        private System.Windows.Forms.Label labelSQLVersions;
        private System.Windows.Forms.Button btnInstallService;
        private System.Windows.Forms.Button btnDeleteBackup;
        private System.Windows.Forms.Button btnNewDB;
        private System.Windows.Forms.Button btnOverwriteDB;
        private System.Windows.Forms.TextBox tbDBDesc;
        private System.Windows.Forms.Button btnRestoreDB;
        private System.Windows.Forms.Button btnDBBackupDescription;
        private System.Windows.Forms.Button btnDBBackupFolder;
        private System.Windows.Forms.ComboBox cbDatabaseList;
        private System.Windows.Forms.ComboBox cbSelectedGP;
        private System.Windows.Forms.Button btnBuildFolder;
        private System.Windows.Forms.ComboBox cbSPGPVersion;
        private System.Windows.Forms.Button btnDLLManager;
        private System.Windows.Forms.ComboBox cbProductList;
        private System.Windows.Forms.Button btnLaunchProduct;
        private System.Windows.Forms.Button btnInstallProduct;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label labelReloadIPAddress;
        private System.Windows.Forms.CheckBox cbAlwaysOnTop;
        private System.Windows.Forms.ColumnHeader chService;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBuildsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesPadDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mobileSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgeCloudEnvironmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupBackupsToolStripMenuItem;
        private System.Windows.Forms.Button btnLaunchGPUtils;
        private System.Windows.Forms.ToolStripMenuItem purgeGPDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killSalesPadToolStripMenuItem;
    }
}

