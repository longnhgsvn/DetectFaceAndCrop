namespace DetectFaceAndCrop
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
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sideLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilesTitle = new System.Windows.Forms.Label();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.previewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.originalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblOriginal = new System.Windows.Forms.Label();
            this.originalImageBox = new Emgu.CV.UI.ImageBox();
            this.resultLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.croppedPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rootLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentLayout.SuspendLayout();
            this.sideLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.previewLayout.SuspendLayout();
            this.originalLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            this.resultLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.croppedPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.headerPanel, 0, 0);
            this.rootLayout.Controls.Add(this.contentLayout, 0, 1);
            this.rootLayout.Controls.Add(this.statusStrip, 0, 2);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Margin = new System.Windows.Forms.Padding(0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 3;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.rootLayout.Size = new System.Drawing.Size(1180, 700);
            this.rootLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1180, 68);
            this.headerPanel.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.lblSubtitle.Location = new System.Drawing.Point(26, 43);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(485, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Detect faces with Emgu CV and export standardized 248 x 340 profile photos.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(352, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Face Detection and ID Photo Cropper";
            // 
            // contentLayout
            // 
            this.contentLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.contentLayout.ColumnCount = 2;
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.contentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentLayout.Controls.Add(this.sideLayout, 0, 0);
            this.contentLayout.Controls.Add(this.previewLayout, 1, 0);
            this.contentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentLayout.Location = new System.Drawing.Point(0, 68);
            this.contentLayout.Margin = new System.Windows.Forms.Padding(0);
            this.contentLayout.Name = "contentLayout";
            this.contentLayout.Padding = new System.Windows.Forms.Padding(16);
            this.contentLayout.RowCount = 1;
            this.contentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentLayout.Size = new System.Drawing.Size(1180, 606);
            this.contentLayout.TabIndex = 1;
            // 
            // sideLayout
            // 
            this.sideLayout.ColumnCount = 1;
            this.sideLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sideLayout.Controls.Add(this.lblFilesTitle, 0, 0);
            this.sideLayout.Controls.Add(this.filesListBox, 0, 1);
            this.sideLayout.Controls.Add(this.buttonPanel, 0, 2);
            this.sideLayout.Controls.Add(this.btnProcess, 0, 3);
            this.sideLayout.Controls.Add(this.btnOpenOutput, 0, 4);
            this.sideLayout.Controls.Add(this.lblHint, 0, 5);
            this.sideLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideLayout.Location = new System.Drawing.Point(19, 19);
            this.sideLayout.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.sideLayout.Name = "sideLayout";
            this.sideLayout.RowCount = 6;
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.sideLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.sideLayout.Size = new System.Drawing.Size(318, 568);
            this.sideLayout.TabIndex = 0;
            // 
            // lblFilesTitle
            // 
            this.lblFilesTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.lblFilesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFilesTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilesTitle.Name = "lblFilesTitle";
            this.lblFilesTitle.Size = new System.Drawing.Size(318, 26);
            this.lblFilesTitle.TabIndex = 0;
            this.lblFilesTitle.Text = "Images to process";
            this.lblFilesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filesListBox
            // 
            this.filesListBox.AllowDrop = true;
            this.filesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListBox.IntegralHeight = false;
            this.filesListBox.Location = new System.Drawing.Point(0, 30);
            this.filesListBox.Margin = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filesListBox.Size = new System.Drawing.Size(318, 340);
            this.filesListBox.TabIndex = 1;
            this.filesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.filesListBox_DragDrop);
            this.filesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.filesListBox_DragEnter);
            this.filesListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesListBox_KeyDown);
            // 
            // buttonPanel
            // 
            this.buttonPanel.ColumnCount = 2;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonPanel.Controls.Add(this.btnBrowse, 0, 0);
            this.buttonPanel.Controls.Add(this.btnClear, 1, 0);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 382);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.Size = new System.Drawing.Size(318, 34);
            this.buttonPanel.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(0, 0);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(155, 34);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Add images...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(163, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 34);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear list";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(0, 424);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(318, 40);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process images";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenOutput.Location = new System.Drawing.Point(0, 472);
            this.btnOpenOutput.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(318, 34);
            this.btnOpenOutput.TabIndex = 4;
            this.btnOpenOutput.Text = "Open output folder";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // lblHint
            // 
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(135)))));
            this.lblHint.Location = new System.Drawing.Point(0, 514);
            this.lblHint.Margin = new System.Windows.Forms.Padding(0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(318, 54);
            this.lblHint.TabIndex = 5;
            this.lblHint.Text = "Results are saved as PNG files in a PROCESS folder next to each source image. Only the largest detected face is exported, at 248 x 340 px.";
            // 
            // previewLayout
            // 
            this.previewLayout.ColumnCount = 2;
            this.previewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.previewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.previewLayout.Controls.Add(this.originalLayout, 0, 0);
            this.previewLayout.Controls.Add(this.resultLayout, 1, 0);
            this.previewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewLayout.Location = new System.Drawing.Point(356, 19);
            this.previewLayout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.previewLayout.Name = "previewLayout";
            this.previewLayout.RowCount = 1;
            this.previewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.previewLayout.Size = new System.Drawing.Size(805, 568);
            this.previewLayout.TabIndex = 1;
            // 
            // originalLayout
            // 
            this.originalLayout.ColumnCount = 1;
            this.originalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.originalLayout.Controls.Add(this.lblOriginal, 0, 0);
            this.originalLayout.Controls.Add(this.originalImageBox, 0, 1);
            this.originalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalLayout.Location = new System.Drawing.Point(0, 0);
            this.originalLayout.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.originalLayout.Name = "originalLayout";
            this.originalLayout.RowCount = 2;
            this.originalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.originalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.originalLayout.Size = new System.Drawing.Size(394, 568);
            this.originalLayout.TabIndex = 0;
            // 
            // lblOriginal
            // 
            this.lblOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOriginal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.lblOriginal.Location = new System.Drawing.Point(0, 0);
            this.lblOriginal.Margin = new System.Windows.Forms.Padding(0);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(394, 28);
            this.lblOriginal.TabIndex = 0;
            this.lblOriginal.Text = "Original - detected faces";
            this.lblOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // originalImageBox
            // 
            this.originalImageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.originalImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImageBox.Location = new System.Drawing.Point(0, 28);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(394, 540);
            this.originalImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalImageBox.TabIndex = 1;
            this.originalImageBox.TabStop = false;
            // 
            // resultLayout
            // 
            this.resultLayout.ColumnCount = 1;
            this.resultLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultLayout.Controls.Add(this.lblResult, 0, 0);
            this.resultLayout.Controls.Add(this.croppedPictureBox, 0, 1);
            this.resultLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLayout.Location = new System.Drawing.Point(410, 0);
            this.resultLayout.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.resultLayout.Name = "resultLayout";
            this.resultLayout.RowCount = 2;
            this.resultLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.resultLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultLayout.Size = new System.Drawing.Size(395, 568);
            this.resultLayout.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Margin = new System.Windows.Forms.Padding(0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(395, 28);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result - ID photo (248 x 340)";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // croppedPictureBox
            // 
            this.croppedPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.croppedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.croppedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.croppedPictureBox.Location = new System.Drawing.Point(0, 28);
            this.croppedPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.croppedPictureBox.Name = "croppedPictureBox";
            this.croppedPictureBox.Size = new System.Drawing.Size(395, 540);
            this.croppedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.croppedPictureBox.TabIndex = 1;
            this.croppedPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 674);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1180, 26);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1000, 21);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready. Add images to get started.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(180, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select images to process";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.rootLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Face Detection and ID Photo Cropper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.rootLayout.ResumeLayout(false);
            this.rootLayout.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentLayout.ResumeLayout(false);
            this.sideLayout.ResumeLayout(false);
            this.sideLayout.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.previewLayout.ResumeLayout(false);
            this.originalLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            this.resultLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.croppedPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel contentLayout;
        private System.Windows.Forms.TableLayoutPanel sideLayout;
        private System.Windows.Forms.Label lblFilesTitle;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.TableLayoutPanel buttonPanel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TableLayoutPanel previewLayout;
        private System.Windows.Forms.TableLayoutPanel originalLayout;
        private System.Windows.Forms.Label lblOriginal;
        private Emgu.CV.UI.ImageBox originalImageBox;
        private System.Windows.Forms.TableLayoutPanel resultLayout;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox croppedPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
