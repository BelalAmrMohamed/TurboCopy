//namespace Turbo_Copy
//{
//    partial class MainForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
//            this.txtSource = new System.Windows.Forms.TextBox();
//            this.txtDest = new System.Windows.Forms.TextBox();
//            this.btnBrowseSource = new System.Windows.Forms.Button();
//            this.btnBrowseDest = new System.Windows.Forms.Button();
//            this.btnStart = new System.Windows.Forms.Button();
//            this.rtbLog = new System.Windows.Forms.RichTextBox();
//            this.rbCopy = new System.Windows.Forms.RadioButton();
//            this.rbMove = new System.Windows.Forms.RadioButton();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.panelStatus = new System.Windows.Forms.StatusStrip();
//            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
//            this.progressBar = new System.Windows.Forms.ProgressBar();
//            this.lblProgress = new System.Windows.Forms.Label();
//            this.groupBox1.SuspendLayout();
//            this.panelStatus.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // txtSource
//            // 
//            this.txtSource.Location = new System.Drawing.Point(17, 43);
//            this.txtSource.Name = "txtSource";
//            this.txtSource.Size = new System.Drawing.Size(491, 22);
//            this.txtSource.TabIndex = 8;
//            // 
//            // txtDest
//            // 
//            this.txtDest.Location = new System.Drawing.Point(17, 101);
//            this.txtDest.Name = "txtDest";
//            this.txtDest.Size = new System.Drawing.Size(491, 22);
//            this.txtDest.TabIndex = 5;
//            // 
//            // btnBrowseSource
//            // 
//            this.btnBrowseSource.Location = new System.Drawing.Point(520, 42);
//            this.btnBrowseSource.Name = "btnBrowseSource";
//            this.btnBrowseSource.Size = new System.Drawing.Size(91, 27);
//            this.btnBrowseSource.TabIndex = 7;
//            this.btnBrowseSource.Text = "📁 Browse...";
//            this.btnBrowseSource.UseVisualStyleBackColor = true;
//            this.btnBrowseSource.Click += new System.EventHandler(this.BtnBrowseSource_Click);
//            // 
//            // btnBrowseDest
//            // 
//            this.btnBrowseDest.Location = new System.Drawing.Point(520, 100);
//            this.btnBrowseDest.Name = "btnBrowseDest";
//            this.btnBrowseDest.Size = new System.Drawing.Size(91, 27);
//            this.btnBrowseDest.TabIndex = 4;
//            this.btnBrowseDest.Text = "📁 Browse...";
//            this.btnBrowseDest.UseVisualStyleBackColor = true;
//            this.btnBrowseDest.Click += new System.EventHandler(this.BtnBrowseDest_Click);
//            // 
//            // btnStart
//            // 
//            this.btnStart.BackColor = System.Drawing.Color.SteelBlue;
//            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.btnStart.ForeColor = System.Drawing.Color.White;
//            this.btnStart.Location = new System.Drawing.Point(263, 151);
//            this.btnStart.Name = "btnStart";
//            this.btnStart.Size = new System.Drawing.Size(349, 46);
//            this.btnStart.TabIndex = 2;
//            this.btnStart.Text = "▶ START TURBO TRANSFER";
//            this.btnStart.UseVisualStyleBackColor = false;
//            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
//            // 
//            // rtbLog
//            // 
//            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
//            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F);
//            this.rtbLog.ForeColor = System.Drawing.Color.LightGray;
//            this.rtbLog.Location = new System.Drawing.Point(17, 251);
//            this.rtbLog.Name = "rtbLog";
//            this.rtbLog.ReadOnly = true;
//            this.rtbLog.Size = new System.Drawing.Size(594, 196);
//            this.rtbLog.TabIndex = 1;
//            this.rtbLog.Text = "";
//            // 
//            // rbCopy
//            // 
//            this.rbCopy.Checked = true;
//            this.rbCopy.Location = new System.Drawing.Point(17, 21);
//            this.rbCopy.Name = "rbCopy";
//            this.rbCopy.Size = new System.Drawing.Size(80, 21);
//            this.rbCopy.TabIndex = 0;
//            this.rbCopy.TabStop = true;
//            this.rbCopy.Text = "Copy";
//            // 
//            // rbMove
//            // 
//            this.rbMove.Location = new System.Drawing.Point(111, 21);
//            this.rbMove.Name = "rbMove";
//            this.rbMove.Size = new System.Drawing.Size(103, 21);
//            this.rbMove.TabIndex = 1;
//            this.rbMove.Text = "Cut";
//            // 
//            // label1
//            // 
//            this.label1.Location = new System.Drawing.Point(17, 21);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(114, 16);
//            this.label1.TabIndex = 9;
//            this.label1.Text = "Source Path:";
//            // 
//            // label2
//            // 
//            this.label2.Location = new System.Drawing.Point(17, 80);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(114, 16);
//            this.label2.TabIndex = 6;
//            this.label2.Text = "Destination Path:";
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.rbCopy);
//            this.groupBox1.Controls.Add(this.rbMove);
//            this.groupBox1.Location = new System.Drawing.Point(17, 144);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(229, 53);
//            this.groupBox1.TabIndex = 3;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Operation Mode";
//            // 
//            // panelStatus
//            // 
//            this.panelStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.panelStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.lblStatus});
//            this.panelStatus.Location = new System.Drawing.Point(0, 466);
//            this.panelStatus.Name = "panelStatus";
//            this.panelStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
//            this.panelStatus.Size = new System.Drawing.Size(629, 26);
//            this.panelStatus.TabIndex = 0;
//            // 
//            // lblStatus
//            // 
//            this.lblStatus.Name = "lblStatus";
//            this.lblStatus.Size = new System.Drawing.Size(50, 20);
//            this.lblStatus.Text = "Ready";
//            // 
//            // progressBar
//            // 
//            this.progressBar.Location = new System.Drawing.Point(17, 213);
//            this.progressBar.Name = "progressBar";
//            this.progressBar.Size = new System.Drawing.Size(594, 23);
//            this.progressBar.TabIndex = 10;
//            this.progressBar.Visible = false;
//            // 
//            // lblProgress
//            // 
//            this.lblProgress.Location = new System.Drawing.Point(17, 213);
//            this.lblProgress.Name = "lblProgress";
//            this.lblProgress.Size = new System.Drawing.Size(594, 23);
//            this.lblProgress.TabIndex = 11;
//            this.lblProgress.Text = "";
//            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
//            this.lblProgress.ForeColor = System.Drawing.Color.SteelBlue;
//            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
//            this.lblProgress.Visible = false;
//            // 
//            // MainForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(629, 492);
//            this.Controls.Add(this.lblProgress);
//            this.Controls.Add(this.progressBar);
//            this.Controls.Add(this.panelStatus);
//            this.Controls.Add(this.rtbLog);
//            this.Controls.Add(this.btnStart);
//            this.Controls.Add(this.groupBox1);
//            this.Controls.Add(this.btnBrowseDest);
//            this.Controls.Add(this.txtDest);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.btnBrowseSource);
//            this.Controls.Add(this.txtSource);
//            this.Controls.Add(this.label1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MaximizeBox = false;
//            this.Name = "MainForm";
//            this.Text = "Turbo Copy";
//            this.groupBox1.ResumeLayout(false);
//            this.panelStatus.ResumeLayout(false);
//            this.panelStatus.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        private System.Windows.Forms.TextBox txtSource;
//        private System.Windows.Forms.TextBox txtDest;
//        private System.Windows.Forms.Button btnBrowseSource;
//        private System.Windows.Forms.Button btnBrowseDest;
//        private System.Windows.Forms.Button btnStart;
//        private System.Windows.Forms.RichTextBox rtbLog;
//        private System.Windows.Forms.RadioButton rbCopy;
//        private System.Windows.Forms.RadioButton rbMove;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.StatusStrip panelStatus;
//        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
//        private System.Windows.Forms.ProgressBar progressBar;
//        private System.Windows.Forms.Label lblProgress;
//    }
//}
namespace Turbo_Copy
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFolder = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.btnClearSource = new System.Windows.Forms.Button();
            this.btnClearDest = new System.Windows.Forms.Button();
            this.chkVerify = new System.Windows.Forms.CheckBox();
            this.chkSkipExisting = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.AllowDrop = true;
            this.txtSource.Location = new System.Drawing.Point(17, 43);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(522, 22);
            this.txtSource.TabIndex = 0;
            this.txtSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtSource_DragDrop);
            this.txtSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtSource_DragEnter);
            // 
            // txtDest
            // 
            this.txtDest.AllowDrop = true;
            this.txtDest.Location = new System.Drawing.Point(17, 101);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(522, 22);
            this.txtDest.TabIndex = 1;
            this.txtDest.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtDest_DragDrop);
            this.txtDest.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtDest_DragEnter);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(551, 42);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(91, 27);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "📁 Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.BtnBrowseSource_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(551, 100);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(91, 27);
            this.btnBrowseDest.TabIndex = 3;
            this.btnBrowseDest.Text = "📁 Browse...";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.BtnBrowseDest_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(540, 159);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(211, 46);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "▶  START TRANSFER";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog.ForeColor = System.Drawing.Color.LightGray;
            this.rtbLog.Location = new System.Drawing.Point(17, 285);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(734, 196);
            this.rtbLog.TabIndex = 5;
            this.rtbLog.Text = "";
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Checked = true;
            this.rbCopy.Location = new System.Drawing.Point(17, 21);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(89, 24);
            this.rbCopy.TabIndex = 0;
            this.rbCopy.TabStop = true;
            this.rbCopy.Text = "📋 Copy";
            this.rbCopy.UseVisualStyleBackColor = true;
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Location = new System.Drawing.Point(121, 21);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(77, 24);
            this.rbMove.TabIndex = 1;
            this.rbMove.Text = "✂️ Cut";
            this.rbMove.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Source Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCopy);
            this.groupBox1.Controls.Add(this.rbMove);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(17, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 53);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Mode";
            // 
            // panelStatus
            // 
            this.panelStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.panelStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripSpring,
            this.lblSpeed});
            this.panelStatus.Location = new System.Drawing.Point(0, 534);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.panelStatus.Size = new System.Drawing.Size(769, 26);
            this.panelStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.Text = "Ready";
            // 
            // toolStripSpring
            // 
            this.toolStripSpring.Name = "toolStripSpring";
            this.toolStripSpring.Size = new System.Drawing.Size(702, 20);
            this.toolStripSpring.Spring = true;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(0, 20);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 255);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(571, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblProgress.Location = new System.Drawing.Point(17, 255);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(571, 23);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFolder);
            this.groupBox2.Controls.Add(this.rbFile);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(17, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 53);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Type";
            // 
            // rbFolder
            // 
            this.rbFolder.AutoSize = true;
            this.rbFolder.Checked = true;
            this.rbFolder.Location = new System.Drawing.Point(17, 21);
            this.rbFolder.Name = "rbFolder";
            this.rbFolder.Size = new System.Drawing.Size(97, 24);
            this.rbFolder.TabIndex = 0;
            this.rbFolder.TabStop = true;
            this.rbFolder.Text = "📁 Folder";
            this.rbFolder.UseVisualStyleBackColor = true;
            this.rbFolder.CheckedChanged += new System.EventHandler(this.RbSourceType_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(121, 21);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(94, 24);
            this.rbFile.TabIndex = 1;
            this.rbFile.Text = "📄 File(s)";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.RbSourceType_CheckedChanged);
            // 
            // btnClearSource
            // 
            this.btnClearSource.ForeColor = System.Drawing.Color.Red;
            this.btnClearSource.Location = new System.Drawing.Point(654, 42);
            this.btnClearSource.Name = "btnClearSource";
            this.btnClearSource.Size = new System.Drawing.Size(35, 27);
            this.btnClearSource.TabIndex = 13;
            this.btnClearSource.Text = "✖";
            this.btnClearSource.UseVisualStyleBackColor = true;
            this.btnClearSource.Click += new System.EventHandler(this.BtnClearSource_Click);
            // 
            // btnClearDest
            // 
            this.btnClearDest.ForeColor = System.Drawing.Color.Red;
            this.btnClearDest.Location = new System.Drawing.Point(654, 100);
            this.btnClearDest.Name = "btnClearDest";
            this.btnClearDest.Size = new System.Drawing.Size(35, 27);
            this.btnClearDest.TabIndex = 14;
            this.btnClearDest.Text = "✖";
            this.btnClearDest.UseVisualStyleBackColor = true;
            this.btnClearDest.Click += new System.EventHandler(this.BtnClearDest_Click);
            // 
            // chkVerify
            // 
            this.chkVerify.AutoSize = true;
            this.chkVerify.Location = new System.Drawing.Point(271, 171);
            this.chkVerify.Name = "chkVerify";
            this.chkVerify.Size = new System.Drawing.Size(145, 20);
            this.chkVerify.TabIndex = 15;
            this.chkVerify.Text = "✓ Verify copied files";
            this.chkVerify.UseVisualStyleBackColor = true;
            // 
            // chkSkipExisting
            // 
            this.chkSkipExisting.AutoSize = true;
            this.chkSkipExisting.Location = new System.Drawing.Point(271, 198);
            this.chkSkipExisting.Name = "chkSkipExisting";
            this.chkSkipExisting.Size = new System.Drawing.Size(146, 20);
            this.chkSkipExisting.TabIndex = 16;
            this.chkSkipExisting.Text = "⏭ Skip existing files";
            this.chkSkipExisting.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(600, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 46);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "⏹  CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblFileInfo.Location = new System.Drawing.Point(17, 487);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(734, 40);
            this.lblFileInfo.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 560);
            this.Controls.Add(this.lblFileInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkSkipExisting);
            this.Controls.Add(this.chkVerify);
            this.Controls.Add(this.btnClearDest);
            this.Controls.Add(this.btnClearSource);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseDest);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turbo Copy - Advanced File & Folder Transfer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.RadioButton rbCopy;
        private System.Windows.Forms.RadioButton rbMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip panelStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblSpeed;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFolder;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.Button btnClearSource;
        private System.Windows.Forms.Button btnClearDest;
        private System.Windows.Forms.CheckBox chkVerify;
        private System.Windows.Forms.CheckBox chkSkipExisting;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileInfo;
    }
}