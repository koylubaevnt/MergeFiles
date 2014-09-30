namespace MergeFiles
{
    partial class frmAbout
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbCompanyIcon = new System.Windows.Forms.PictureBox();
            this.lSite = new System.Windows.Forms.LinkLabel();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblPred = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblProgName = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCompanyIcon
            // 
            this.pbCompanyIcon.Image = global::MergeFiles.Properties.Resources.LineRetailLTD;
            this.pbCompanyIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbCompanyIcon.InitialImage")));
            this.pbCompanyIcon.Location = new System.Drawing.Point(15, 12);
            this.pbCompanyIcon.Name = "pbCompanyIcon";
            this.pbCompanyIcon.Size = new System.Drawing.Size(459, 103);
            this.pbCompanyIcon.TabIndex = 1;
            this.pbCompanyIcon.TabStop = false;
            // 
            // lSite
            // 
            this.lSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lSite.AutoSize = true;
            this.lSite.Location = new System.Drawing.Point(12, 429);
            this.lSite.Name = "lSite";
            this.lSite.Size = new System.Drawing.Size(110, 13);
            this.lSite.TabIndex = 17;
            this.lSite.TabStop = true;
            this.lSite.Text = "Сайт разработчиков";
            this.lSite.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lSite_LinkClicked);
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOS.Location = new System.Drawing.Point(12, 386);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(32, 13);
            this.lblOS.TabIndex = 16;
            this.lblOS.Text = "lblOS";
            // 
            // lblPred
            // 
            this.lblPred.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPred.Location = new System.Drawing.Point(12, 326);
            this.lblPred.Name = "lblPred";
            this.lblPred.Size = new System.Drawing.Size(465, 61);
            this.lblPred.TabIndex = 15;
            this.lblPred.Text = resources.GetString("lblPred.Text");
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(15, 194);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(462, 129);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLicense.Location = new System.Drawing.Point(12, 178);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(54, 13);
            this.lblLicense.TabIndex = 13;
            this.lblLicense.Text = "lblLicense";
            // 
            // lblDescription
            // 
            this.lblDescription.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDescription.Location = new System.Drawing.Point(12, 151);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(476, 27);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "lblDescription";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblVersion.Location = new System.Drawing.Point(12, 135);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(52, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "lblVersion";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAccept.Location = new System.Drawing.Point(402, 424);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "ОК";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblProgName
            // 
            this.lblProgName.AutoSize = true;
            this.lblProgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProgName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProgName.Location = new System.Drawing.Point(12, 119);
            this.lblProgName.Name = "lblProgName";
            this.lblProgName.Size = new System.Drawing.Size(78, 13);
            this.lblProgName.TabIndex = 9;
            this.lblProgName.Text = "lblProgName";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHistory.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnHistory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnHistory.Location = new System.Drawing.Point(321, 424);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(75, 23);
            this.btnHistory.TabIndex = 18;
            this.btnHistory.Text = "История";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(489, 451);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.lSite);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.lblPred);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblProgName);
            this.Controls.Add(this.pbCompanyIcon);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAbout";
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCompanyIcon;
        private System.Windows.Forms.LinkLabel lSite;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblPred;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblProgName;
        private System.Windows.Forms.Button btnHistory;
    }
}