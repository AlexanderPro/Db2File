namespace Db2File.Code.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExecute = new System.Windows.Forms.Button();
            this.grpCommon = new System.Windows.Forms.GroupBox();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.lblFileEncoding = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtFileEncoding = new System.Windows.Forms.TextBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblDbType = new System.Windows.Forms.Label();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.grpColumnRelations = new System.Windows.Forms.GroupBox();
            this.btnAddRelation = new System.Windows.Forms.Button();
            this.gridColumnRelations = new System.Windows.Forms.DataGridView();
            this.clmnDeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmnDbColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFileColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFileColumnFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFileColumnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmnFileColumnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnFileColumnDecimals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSpace = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTimeSpan = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpCommon.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.grpColumnRelations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumnRelations)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(685, 607);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(87, 23);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.ButtonExecuteClick);
            // 
            // grpCommon
            // 
            this.grpCommon.Controls.Add(this.btnBrowseFile);
            this.grpCommon.Controls.Add(this.lblFileEncoding);
            this.grpCommon.Controls.Add(this.lblFilePath);
            this.grpCommon.Controls.Add(this.txtFilePath);
            this.grpCommon.Controls.Add(this.txtFileEncoding);
            this.grpCommon.Controls.Add(this.lblFileType);
            this.grpCommon.Controls.Add(this.lblConnectionString);
            this.grpCommon.Controls.Add(this.cmbFileType);
            this.grpCommon.Controls.Add(this.txtConnectionString);
            this.grpCommon.Controls.Add(this.lblDbType);
            this.grpCommon.Controls.Add(this.cmbDataBase);
            this.grpCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommon.Location = new System.Drawing.Point(0, 0);
            this.grpCommon.Name = "grpCommon";
            this.grpCommon.Size = new System.Drawing.Size(784, 151);
            this.grpCommon.TabIndex = 0;
            this.grpCommon.TabStop = false;
            this.grpCommon.Text = "Common";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.Location = new System.Drawing.Point(730, 101);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(42, 23);
            this.btnBrowseFile.TabIndex = 10;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFileClick);
            // 
            // lblFileEncoding
            // 
            this.lblFileEncoding.AutoSize = true;
            this.lblFileEncoding.Location = new System.Drawing.Point(183, 87);
            this.lblFileEncoding.Name = "lblFileEncoding";
            this.lblFileEncoding.Size = new System.Drawing.Size(74, 13);
            this.lblFileEncoding.TabIndex = 6;
            this.lblFileEncoding.Text = "File Encoding:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(354, 87);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 8;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(357, 103);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(367, 20);
            this.txtFilePath.TabIndex = 9;
            // 
            // txtFileEncoding
            // 
            this.txtFileEncoding.Location = new System.Drawing.Point(186, 103);
            this.txtFileEncoding.Name = "txtFileEncoding";
            this.txtFileEncoding.Size = new System.Drawing.Size(156, 20);
            this.txtFileEncoding.TabIndex = 7;
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(6, 87);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(53, 13);
            this.lblFileType.TabIndex = 4;
            this.lblFileType.Text = "File Type:";
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(183, 25);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(94, 13);
            this.lblConnectionString.TabIndex = 2;
            this.lblConnectionString.Text = "Connection String:";
            // 
            // cmbFileType
            // 
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Location = new System.Drawing.Point(9, 103);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(159, 21);
            this.cmbFileType.TabIndex = 5;
            this.cmbFileType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFileTypeIndexChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(186, 41);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(586, 20);
            this.txtConnectionString.TabIndex = 3;
            // 
            // lblDbType
            // 
            this.lblDbType.AutoSize = true;
            this.lblDbType.Location = new System.Drawing.Point(6, 25);
            this.lblDbType.Name = "lblDbType";
            this.lblDbType.Size = new System.Drawing.Size(60, 13);
            this.lblDbType.TabIndex = 0;
            this.lblDbType.Text = "Data Base:";
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(9, 41);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(159, 21);
            this.cmbDataBase.TabIndex = 1;
            // 
            // grpQuery
            // 
            this.grpQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpQuery.Controls.Add(this.txtQuery);
            this.grpQuery.Location = new System.Drawing.Point(0, 395);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(784, 194);
            this.grpQuery.TabIndex = 2;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "SQL";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(9, 19);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(763, 169);
            this.txtQuery.TabIndex = 0;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(575, 607);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(104, 23);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.ButtonTestClick);
            // 
            // grpColumnRelations
            // 
            this.grpColumnRelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpColumnRelations.Controls.Add(this.btnAddRelation);
            this.grpColumnRelations.Controls.Add(this.gridColumnRelations);
            this.grpColumnRelations.Location = new System.Drawing.Point(0, 157);
            this.grpColumnRelations.Name = "grpColumnRelations";
            this.grpColumnRelations.Size = new System.Drawing.Size(784, 232);
            this.grpColumnRelations.TabIndex = 1;
            this.grpColumnRelations.TabStop = false;
            this.grpColumnRelations.Text = "Column Relations";
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRelation.Location = new System.Drawing.Point(718, 203);
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Size = new System.Drawing.Size(54, 23);
            this.btnAddRelation.TabIndex = 1;
            this.btnAddRelation.Text = "+";
            this.btnAddRelation.UseVisualStyleBackColor = true;
            this.btnAddRelation.Click += new System.EventHandler(this.ButtonAddRelationClick);
            // 
            // gridColumnRelations
            // 
            this.gridColumnRelations.AllowUserToAddRows = false;
            this.gridColumnRelations.AllowUserToResizeRows = false;
            this.gridColumnRelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridColumnRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumnRelations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnDeleteButton,
            this.clmnDbColumnName,
            this.clmnFileColumnName,
            this.clmnFileColumnFormat,
            this.clmnFileColumnType,
            this.clmnFileColumnLength,
            this.clmnFileColumnDecimals});
            this.gridColumnRelations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridColumnRelations.GridColor = System.Drawing.SystemColors.Control;
            this.gridColumnRelations.Location = new System.Drawing.Point(9, 19);
            this.gridColumnRelations.MultiSelect = false;
            this.gridColumnRelations.Name = "gridColumnRelations";
            this.gridColumnRelations.RowHeadersVisible = false;
            this.gridColumnRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridColumnRelations.Size = new System.Drawing.Size(763, 178);
            this.gridColumnRelations.TabIndex = 0;
            this.gridColumnRelations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridColumnRelationsCellClick);
            // 
            // clmnDeleteButton
            // 
            this.clmnDeleteButton.HeaderText = "";
            this.clmnDeleteButton.Name = "clmnDeleteButton";
            this.clmnDeleteButton.Text = "-";
            this.clmnDeleteButton.UseColumnTextForButtonValue = true;
            this.clmnDeleteButton.Width = 20;
            // 
            // clmnDbColumnName
            // 
            this.clmnDbColumnName.HeaderText = "DB Column Name";
            this.clmnDbColumnName.Name = "clmnDbColumnName";
            this.clmnDbColumnName.Width = 120;
            // 
            // clmnFileColumnName
            // 
            this.clmnFileColumnName.HeaderText = "File Column Name";
            this.clmnFileColumnName.Name = "clmnFileColumnName";
            this.clmnFileColumnName.Width = 120;
            // 
            // clmnFileColumnFormat
            // 
            this.clmnFileColumnFormat.HeaderText = "File Column Format";
            this.clmnFileColumnFormat.Name = "clmnFileColumnFormat";
            this.clmnFileColumnFormat.Width = 130;
            // 
            // clmnFileColumnType
            // 
            this.clmnFileColumnType.HeaderText = "File Column Type";
            this.clmnFileColumnType.Name = "clmnFileColumnType";
            this.clmnFileColumnType.Width = 120;
            // 
            // clmnFileColumnLength
            // 
            this.clmnFileColumnLength.HeaderText = "File Column Length";
            this.clmnFileColumnLength.Name = "clmnFileColumnLength";
            this.clmnFileColumnLength.Width = 120;
            // 
            // clmnFileColumnDecimals
            // 
            this.clmnFileColumnDecimals.HeaderText = "File Column Decimals";
            this.clmnFileColumnDecimals.Name = "clmnFileColumnDecimals";
            this.clmnFileColumnDecimals.Width = 130;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripSpace,
            this.toolStripTimeSpan});
            this.statusStrip.Location = new System.Drawing.Point(0, 646);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 5;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripSpace
            // 
            this.toolStripSpace.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripSpace.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripSpace.Name = "toolStripSpace";
            this.toolStripSpace.Size = new System.Drawing.Size(720, 17);
            this.toolStripSpace.Spring = true;
            // 
            // toolStripTimeSpan
            // 
            this.toolStripTimeSpan.Name = "toolStripTimeSpan";
            this.toolStripTimeSpan.Size = new System.Drawing.Size(49, 17);
            this.toolStripTimeSpan.Text = "00:00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 668);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpColumnRelations);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.grpQuery);
            this.Controls.Add(this.grpCommon);
            this.Controls.Add(this.btnExecute);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Db2File";
            this.grpCommon.ResumeLayout(false);
            this.grpCommon.PerformLayout();
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.grpColumnRelations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumnRelations)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox grpCommon;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblDbType;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblFileEncoding;
        private System.Windows.Forms.TextBox txtFileEncoding;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.GroupBox grpColumnRelations;
        private System.Windows.Forms.DataGridView gridColumnRelations;
        private System.Windows.Forms.Button btnAddRelation;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSpace;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTimeSpan;
        private System.Windows.Forms.DataGridViewButtonColumn clmnDeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDbColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFileColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFileColumnFormat;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnFileColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFileColumnLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFileColumnDecimals;
    }
}