namespace MergeFiles
{
    partial class frmMain
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettingsLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettingsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMergeFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSeparator = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMergeFiles = new System.Windows.Forms.Button();
            this.lSeparator = new System.Windows.Forms.Label();
            this.lDestinationDirectory = new System.Windows.Forms.Label();
            this.tbDestinationDirectory = new System.Windows.Forms.TextBox();
            this.tbDestinationFileName = new System.Windows.Forms.TextBox();
            this.lDestinationFileName = new System.Windows.Forms.Label();
            this.lTypeFile = new System.Windows.Forms.Label();
            this.cbTypeFile = new System.Windows.Forms.ComboBox();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMain,
            this.tsmiAbout});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(656, 24);
            this.msMain.TabIndex = 0;
            // 
            // tsmiMain
            // 
            this.tsmiMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiSettings,
            this.tsmiMergeFiles,
            this.tsmiExit});
            this.tsmiMain.Name = "tsmiMain";
            this.tsmiMain.Size = new System.Drawing.Size(61, 20);
            this.tsmiMain.Text = "Главное";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileAdd,
            this.tsmiFileDelete});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(152, 22);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiFileAdd
            // 
            this.tsmiFileAdd.Name = "tsmiFileAdd";
            this.tsmiFileAdd.Size = new System.Drawing.Size(152, 22);
            this.tsmiFileAdd.Text = "Добавить";
            this.tsmiFileAdd.Click += new System.EventHandler(this.tsmiFileAdd_Click);
            // 
            // tsmiFileDelete
            // 
            this.tsmiFileDelete.Name = "tsmiFileDelete";
            this.tsmiFileDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmiFileDelete.Text = "Удалить";
            this.tsmiFileDelete.Click += new System.EventHandler(this.tsmiFileDelete_Click);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettingsLoad,
            this.tsmiSettingsSave});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(152, 22);
            this.tsmiSettings.Text = "Настройки";
            // 
            // tsmiSettingsLoad
            // 
            this.tsmiSettingsLoad.Name = "tsmiSettingsLoad";
            this.tsmiSettingsLoad.Size = new System.Drawing.Size(152, 22);
            this.tsmiSettingsLoad.Text = "Загрузить";
            // 
            // tsmiSettingsSave
            // 
            this.tsmiSettingsSave.Name = "tsmiSettingsSave";
            this.tsmiSettingsSave.Size = new System.Drawing.Size(152, 22);
            this.tsmiSettingsSave.Text = "Сохранить";
            // 
            // tsmiMergeFiles
            // 
            this.tsmiMergeFiles.Name = "tsmiMergeFiles";
            this.tsmiMergeFiles.Size = new System.Drawing.Size(152, 22);
            this.tsmiMergeFiles.Text = "Объединить";
            this.tsmiMergeFiles.Click += new System.EventHandler(this.MergeFile_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(152, 22);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.CloseProgram_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(83, 20);
            this.tsmiAbout.Text = "О программе";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // cbSeparator
            // 
            this.cbSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeparator.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSeparator.FormattingEnabled = true;
            this.cbSeparator.Location = new System.Drawing.Point(79, 378);
            this.cbSeparator.Name = "cbSeparator";
            this.cbSeparator.Size = new System.Drawing.Size(208, 21);
            this.cbSeparator.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(560, 377);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.CloseProgram_Click);
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.Location = new System.Drawing.Point(473, 377);
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.Size = new System.Drawing.Size(81, 23);
            this.btnMergeFiles.TabIndex = 4;
            this.btnMergeFiles.Text = "Объединить";
            this.btnMergeFiles.UseVisualStyleBackColor = true;
            this.btnMergeFiles.Click += new System.EventHandler(this.MergeFile_Click);
            // 
            // lSeparator
            // 
            this.lSeparator.AutoSize = true;
            this.lSeparator.Location = new System.Drawing.Point(0, 381);
            this.lSeparator.Name = "lSeparator";
            this.lSeparator.Size = new System.Drawing.Size(76, 13);
            this.lSeparator.TabIndex = 5;
            this.lSeparator.Text = "Разделитель:";
            // 
            // lDestinationDirectory
            // 
            this.lDestinationDirectory.AutoSize = true;
            this.lDestinationDirectory.Location = new System.Drawing.Point(2, 323);
            this.lDestinationDirectory.Name = "lDestinationDirectory";
            this.lDestinationDirectory.Size = new System.Drawing.Size(125, 13);
            this.lDestinationDirectory.TabIndex = 6;
            this.lDestinationDirectory.Text = "Папка для сохранения:";
            // 
            // tbDestinationDirectory
            // 
            this.tbDestinationDirectory.Location = new System.Drawing.Point(133, 320);
            this.tbDestinationDirectory.Name = "tbDestinationDirectory";
            this.tbDestinationDirectory.Size = new System.Drawing.Size(502, 20);
            this.tbDestinationDirectory.TabIndex = 7;
            this.tbDestinationDirectory.DoubleClick += new System.EventHandler(this.ChooseDestinationFileName_Click);
            // 
            // tbDestinationFileName
            // 
            this.tbDestinationFileName.Location = new System.Drawing.Point(133, 346);
            this.tbDestinationFileName.Name = "tbDestinationFileName";
            this.tbDestinationFileName.Size = new System.Drawing.Size(502, 20);
            this.tbDestinationFileName.TabIndex = 9;
            this.tbDestinationFileName.DoubleClick += new System.EventHandler(this.ChooseDestinationFileName_Click);
            // 
            // lDestinationFileName
            // 
            this.lDestinationFileName.AutoSize = true;
            this.lDestinationFileName.Location = new System.Drawing.Point(2, 349);
            this.lDestinationFileName.Name = "lDestinationFileName";
            this.lDestinationFileName.Size = new System.Drawing.Size(67, 13);
            this.lDestinationFileName.TabIndex = 8;
            this.lDestinationFileName.Text = "Имя файла:";
            // 
            // lTypeFile
            // 
            this.lTypeFile.AutoSize = true;
            this.lTypeFile.Location = new System.Drawing.Point(0, 34);
            this.lTypeFile.Name = "lTypeFile";
            this.lTypeFile.Size = new System.Drawing.Size(64, 13);
            this.lTypeFile.TabIndex = 11;
            this.lTypeFile.Text = "Тип файла:";
            // 
            // cbTypeFile
            // 
            this.cbTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTypeFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbTypeFile.IntegralHeight = false;
            this.cbTypeFile.Location = new System.Drawing.Point(79, 31);
            this.cbTypeFile.Name = "cbTypeFile";
            this.cbTypeFile.Size = new System.Drawing.Size(208, 21);
            this.cbTypeFile.TabIndex = 10;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeColumns = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.FileDirectory,
            this.FileName,
            this.FileExtension});
            this.dgvFiles.Location = new System.Drawing.Point(5, 62);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.ShowEditingIcon = false;
            this.dgvFiles.Size = new System.Drawing.Size(651, 252);
            this.dgvFiles.TabIndex = 12;
            // 
            // Checked
            // 
            this.Checked.Frozen = true;
            this.Checked.HeaderText = "";
            this.Checked.Name = "Checked";
            this.Checked.Width = 25;
            // 
            // FileDirectory
            // 
            this.FileDirectory.Frozen = true;
            this.FileDirectory.HeaderText = "Директория файла";
            this.FileDirectory.Name = "FileDirectory";
            this.FileDirectory.ReadOnly = true;
            this.FileDirectory.Width = 300;
            // 
            // FileName
            // 
            this.FileName.Frozen = true;
            this.FileName.HeaderText = "Имя файла";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 200;
            // 
            // FileExtension
            // 
            this.FileExtension.Frozen = true;
            this.FileExtension.HeaderText = "Расширение файла";
            this.FileExtension.Name = "FileExtension";
            this.FileExtension.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 401);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.lTypeFile);
            this.Controls.Add(this.cbTypeFile);
            this.Controls.Add(this.tbDestinationFileName);
            this.Controls.Add(this.lDestinationFileName);
            this.Controls.Add(this.tbDestinationDirectory);
            this.Controls.Add(this.lDestinationDirectory);
            this.Controls.Add(this.lSeparator);
            this.Controls.Add(this.btnMergeFiles);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbSeparator);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettingsLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettingsSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiMergeFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ComboBox cbSeparator;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMergeFiles;
        private System.Windows.Forms.Label lSeparator;
        private System.Windows.Forms.Label lDestinationDirectory;
        private System.Windows.Forms.TextBox tbDestinationDirectory;
        private System.Windows.Forms.TextBox tbDestinationFileName;
        private System.Windows.Forms.Label lDestinationFileName;
        private System.Windows.Forms.Label lTypeFile;
        private System.Windows.Forms.ComboBox cbTypeFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileExtension;
        private System.Windows.Forms.DataGridView dgvFiles;
    }
}

