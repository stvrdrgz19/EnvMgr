namespace EnvMgr
{
    partial class DBDesc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBDesc));
            this.tbExistingDescription = new System.Windows.Forms.TextBox();
            this.tbNewDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbExistingDescription
            // 
            this.tbExistingDescription.Location = new System.Drawing.Point(3, 26);
            this.tbExistingDescription.Multiline = true;
            this.tbExistingDescription.Name = "tbExistingDescription";
            this.tbExistingDescription.ReadOnly = true;
            this.tbExistingDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbExistingDescription.Size = new System.Drawing.Size(498, 157);
            this.tbExistingDescription.TabIndex = 3;
            // 
            // tbNewDescription
            // 
            this.tbNewDescription.Location = new System.Drawing.Point(3, 210);
            this.tbNewDescription.Multiline = true;
            this.tbNewDescription.Name = "tbNewDescription";
            this.tbNewDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNewDescription.Size = new System.Drawing.Size(498, 157);
            this.tbNewDescription.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Existing Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "New Description:";
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.Location = new System.Drawing.Point(2, 368);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(250, 23);
            this.btnOverwrite.TabIndex = 1;
            this.btnOverwrite.Text = "Overwrite Description";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(252, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(250, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add to Description";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DBDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 393);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNewDescription);
            this.Controls.Add(this.tbExistingDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DBDesc";
            this.Text = "Database Description";
            this.Load += new System.EventHandler(this.DBDesc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExistingDescription;
        private System.Windows.Forms.TextBox tbNewDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button btnAdd;
    }
}