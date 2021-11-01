namespace DoNotPutYourDataOnRight.Application
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.AddExcelSource = new System.Windows.Forms.Button();
            this.dgvHeadText = new System.Windows.Forms.DataGridView();
            this.HeadText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportJson = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.llAuthor = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // AddExcelSource
            // 
            this.AddExcelSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddExcelSource.Location = new System.Drawing.Point(203, 415);
            this.AddExcelSource.Name = "AddExcelSource";
            this.AddExcelSource.Size = new System.Drawing.Size(242, 23);
            this.AddExcelSource.TabIndex = 0;
            this.AddExcelSource.Text = "Add Excel File";
            this.AddExcelSource.UseVisualStyleBackColor = true;
            this.AddExcelSource.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // dgvHeadText
            // 
            this.dgvHeadText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHeadText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeadText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeadText});
            this.dgvHeadText.Location = new System.Drawing.Point(13, 13);
            this.dgvHeadText.Name = "dgvHeadText";
            this.dgvHeadText.RowTemplate.Height = 23;
            this.dgvHeadText.Size = new System.Drawing.Size(184, 425);
            this.dgvHeadText.TabIndex = 1;
            // 
            // HeadText
            // 
            this.HeadText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HeadText.HeaderText = "Key Text";
            this.HeadText.Name = "HeadText";
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(203, 13);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(242, 396);
            this.lvFiles.TabIndex = 2;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
            this.lvFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvFiles_KeyUp);
            // 
            // dgvResult
            // 
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(451, 13);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(633, 396);
            this.dgvResult.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Location = new System.Drawing.Point(979, 415);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(105, 23);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportJson
            // 
            this.btnExportJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportJson.Enabled = false;
            this.btnExportJson.Location = new System.Drawing.Point(872, 415);
            this.btnExportJson.Name = "btnExportJson";
            this.btnExportJson.Size = new System.Drawing.Size(101, 23);
            this.btnExportJson.TabIndex = 5;
            this.btnExportJson.Text = "Export JSON";
            this.btnExportJson.UseVisualStyleBackColor = true;
            this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(451, 415);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(144, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Build Or Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // llAuthor
            // 
            this.llAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llAuthor.AutoSize = true;
            this.llAuthor.Location = new System.Drawing.Point(663, 420);
            this.llAuthor.Name = "llAuthor";
            this.llAuthor.Size = new System.Drawing.Size(203, 12);
            this.llAuthor.TabIndex = 7;
            this.llAuthor.TabStop = true;
            this.llAuthor.Text = "Author By E.Shaw Copyright © 2018";
            this.llAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAuthor_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 450);
            this.Controls.Add(this.llAuthor);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExportJson);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.dgvHeadText);
            this.Controls.Add(this.AddExcelSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Don\'t put your data on right - E.Shaw";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeadText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddExcelSource;
        private System.Windows.Forms.DataGridView dgvHeadText;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadText;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportJson;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel llAuthor;
    }
}

