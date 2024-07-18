namespace Excel2JsonEX.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip = new ToolStrip();
            btnImportExcel = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnCopyJSON = new ToolStripButton();
            btnSaveJson = new ToolStripButton();
            btnCopyCSharp = new ToolStripButton();
            btnSaveCSharp = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnHelp = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelExcelDropBox = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBoxExcel = new PictureBox();
            labelExcelFile = new Label();
            groupBox1 = new GroupBox();
            checkBoxAllString = new CheckBox();
            checkBoxCellJson = new CheckBox();
            textBoxExculdePrefix = new TextBox();
            comboBoxSheetName = new ComboBox();
            comboBoxDateFormat = new ComboBox();
            btnReimport = new Button();
            comboBoxLowcase = new ComboBox();
            comboBoxHeader = new ComboBox();
            comboBoxEncoding = new ComboBox();
            comboBoxType = new ComboBox();
            tabControlCode = new TabControl();
            tabPageJSON = new TabPage();
            tabCSharp = new TabPage();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            statusStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelExcelDropBox.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExcel).BeginInit();
            groupBox1.SuspendLayout();
            tabControlCode.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new Point(9, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 1;
            label2.Text = "Encoding:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 39);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 1;
            label1.Text = "Export Type:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(9, 125);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(153, 20);
            label4.TabIndex = 6;
            label4.Text = "Lowcase:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(9, 168);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 4;
            label3.Text = "Header:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(9, 212);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 9;
            label5.Text = "Date Format:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Location = new Point(9, 255);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(153, 20);
            label6.TabIndex = 11;
            label6.Text = "SheetName:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new Point(9, 299);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(153, 20);
            label7.TabIndex = 13;
            label7.Text = "ExculdePrefix:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // statusStrip
            // 
            statusStrip.AutoSize = false;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 910);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 21, 0);
            statusStrip.Size = new Size(1276, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "Ready";
            // 
            // statusLabel
            // 
            statusLabel.IsLink = true;
            statusLabel.Name = "statusLabel";
            statusLabel.RightToLeft = RightToLeft.No;
            statusLabel.Size = new Size(178, 20);
            statusLabel.Text = "https://neil3d.github.io";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Click += statusLabel_Click;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.IsLink = true;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.RightToLeft = RightToLeft.No;
            toolStripStatusLabel1.Size = new Size(1037, 20);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "https://github.com/Sonic853/Excel2JsonEX";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight;
            toolStripStatusLabel1.Click += statusLabel1_Click;
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripItem[] { btnImportExcel, toolStripSeparator1, btnCopyJSON, btnSaveJson, btnCopyCSharp, btnSaveCSharp, toolStripSeparator2, btnHelp });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1276, 51);
            toolStrip.TabIndex = 4;
            toolStrip.Text = "Import excel file and export as JSON";
            // 
            // btnImportExcel
            // 
            btnImportExcel.Image = Properties.Resources.excel;
            btnImportExcel.ImageTransparentColor = Color.Magenta;
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(104, 48);
            btnImportExcel.Text = "Import Excel";
            btnImportExcel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnImportExcel.ToolTipText = "Import Excel .xlsx file";
            btnImportExcel.Click += btnImportExcel_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 51);
            // 
            // btnCopyJSON
            // 
            btnCopyJSON.Image = Properties.Resources.clipboard;
            btnCopyJSON.ImageTransparentColor = Color.Magenta;
            btnCopyJSON.Name = "btnCopyJSON";
            btnCopyJSON.Size = new Size(94, 48);
            btnCopyJSON.Text = "Copy JSON";
            btnCopyJSON.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCopyJSON.ToolTipText = "Copy JSON string to clipboard";
            btnCopyJSON.Click += btnCopyJSON_Click;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Image = Properties.Resources.json;
            btnSaveJson.ImageTransparentColor = Color.Magenta;
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(90, 48);
            btnSaveJson.Text = "Save JSON";
            btnSaveJson.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSaveJson.ToolTipText = "Save JSON file";
            btnSaveJson.Click += btnSaveJson_Click;
            // 
            // btnCopyCSharp
            // 
            btnCopyCSharp.Image = Properties.Resources.clipboard;
            btnCopyCSharp.ImageTransparentColor = Color.Magenta;
            btnCopyCSharp.Name = "btnCopyCSharp";
            btnCopyCSharp.Size = new Size(75, 48);
            btnCopyCSharp.Text = "Copy C#";
            btnCopyCSharp.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCopyCSharp.ToolTipText = "Save JSON file";
            btnCopyCSharp.Click += btnCopyCSharp_Click;
            // 
            // btnSaveCSharp
            // 
            btnSaveCSharp.Image = Properties.Resources.code;
            btnSaveCSharp.ImageTransparentColor = Color.Magenta;
            btnSaveCSharp.Name = "btnSaveCSharp";
            btnSaveCSharp.Size = new Size(71, 48);
            btnSaveCSharp.Text = "Save C#";
            btnSaveCSharp.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSaveCSharp.ToolTipText = "Save JSON file";
            btnSaveCSharp.Click += btnSaveCSharp_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 51);
            // 
            // btnHelp
            // 
            btnHelp.Image = Properties.Resources.about;
            btnHelp.ImageTransparentColor = Color.Magenta;
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(48, 48);
            btnHelp.Text = "Help";
            btnHelp.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHelp.ToolTipText = "Help Document on web";
            btnHelp.Click += btnHelp_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 51);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControlCode);
            splitContainer1.Size = new Size(1276, 859);
            splitContainer1.SplitterDistance = 428;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panelExcelDropBox);
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(426, 857);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panelExcelDropBox
            // 
            panelExcelDropBox.AllowDrop = true;
            panelExcelDropBox.BackColor = SystemColors.ControlLight;
            panelExcelDropBox.BorderStyle = BorderStyle.FixedSingle;
            panelExcelDropBox.Controls.Add(flowLayoutPanel2);
            panelExcelDropBox.Location = new Point(12, 13);
            panelExcelDropBox.Margin = new Padding(12, 13, 12, 13);
            panelExcelDropBox.Name = "panelExcelDropBox";
            panelExcelDropBox.Size = new Size(404, 215);
            panelExcelDropBox.TabIndex = 1;
            panelExcelDropBox.DragDrop += panelExcelDropBox_DragDrop;
            panelExcelDropBox.DragEnter += panelExcelDropBox_DragEnter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(pictureBoxExcel);
            flowLayoutPanel2.Controls.Add(labelExcelFile);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(402, 216);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxExcel
            // 
            pictureBoxExcel.Image = Properties.Resources.excel_64;
            pictureBoxExcel.Location = new Point(4, 5);
            pictureBoxExcel.Margin = new Padding(4, 5, 4, 5);
            pictureBoxExcel.Name = "pictureBoxExcel";
            pictureBoxExcel.Size = new Size(393, 145);
            pictureBoxExcel.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxExcel.TabIndex = 0;
            pictureBoxExcel.TabStop = false;
            // 
            // labelExcelFile
            // 
            labelExcelFile.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelExcelFile.Location = new Point(4, 155);
            labelExcelFile.Margin = new Padding(4, 0, 4, 0);
            labelExcelFile.Name = "labelExcelFile";
            labelExcelFile.RightToLeft = RightToLeft.No;
            labelExcelFile.Size = new Size(390, 59);
            labelExcelFile.TabIndex = 1;
            labelExcelFile.Text = "Drop you .xlsx file here!";
            labelExcelFile.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxAllString);
            groupBox1.Controls.Add(checkBoxCellJson);
            groupBox1.Controls.Add(textBoxExculdePrefix);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(comboBoxSheetName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBoxDateFormat);
            groupBox1.Controls.Add(btnReimport);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxLowcase);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBoxHeader);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBoxEncoding);
            groupBox1.Controls.Add(comboBoxType);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(12, 254);
            groupBox1.Margin = new Padding(12, 13, 12, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(404, 547);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // checkBoxAllString
            // 
            checkBoxAllString.AutoSize = true;
            checkBoxAllString.Location = new Point(30, 384);
            checkBoxAllString.Margin = new Padding(4, 5, 4, 5);
            checkBoxAllString.Name = "checkBoxAllString";
            checkBoxAllString.Size = new Size(98, 24);
            checkBoxAllString.TabIndex = 16;
            checkBoxAllString.Text = "All String";
            checkBoxAllString.UseVisualStyleBackColor = true;
            // 
            // checkBoxCellJson
            // 
            checkBoxCellJson.AutoSize = true;
            checkBoxCellJson.Location = new Point(30, 349);
            checkBoxCellJson.Margin = new Padding(4, 5, 4, 5);
            checkBoxCellJson.Name = "checkBoxCellJson";
            checkBoxCellJson.Size = new Size(221, 24);
            checkBoxCellJson.TabIndex = 15;
            checkBoxCellJson.Text = "Convert Json String in Cell";
            checkBoxCellJson.UseVisualStyleBackColor = true;
            // 
            // textBoxExculdePrefix
            // 
            textBoxExculdePrefix.Location = new Point(171, 300);
            textBoxExculdePrefix.Margin = new Padding(4, 5, 4, 5);
            textBoxExculdePrefix.Name = "textBoxExculdePrefix";
            textBoxExculdePrefix.Size = new Size(223, 27);
            textBoxExculdePrefix.TabIndex = 14;
            // 
            // comboBoxSheetName
            // 
            comboBoxSheetName.DisplayMember = "0";
            comboBoxSheetName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSheetName.FormattingEnabled = true;
            comboBoxSheetName.Items.AddRange(new object[] { "Yes", "No" });
            comboBoxSheetName.Location = new Point(171, 255);
            comboBoxSheetName.Margin = new Padding(4, 5, 4, 5);
            comboBoxSheetName.Name = "comboBoxSheetName";
            comboBoxSheetName.Size = new Size(223, 28);
            comboBoxSheetName.TabIndex = 10;
            comboBoxSheetName.ValueMember = "0";
            // 
            // comboBoxDateFormat
            // 
            comboBoxDateFormat.DisplayMember = "0";
            comboBoxDateFormat.FormattingEnabled = true;
            comboBoxDateFormat.Items.AddRange(new object[] { "yyyy/MM/dd", "yyyy/MM/dd hh:mm:ss" });
            comboBoxDateFormat.Location = new Point(171, 212);
            comboBoxDateFormat.Margin = new Padding(4, 5, 4, 5);
            comboBoxDateFormat.Name = "comboBoxDateFormat";
            comboBoxDateFormat.Size = new Size(223, 28);
            comboBoxDateFormat.TabIndex = 8;
            comboBoxDateFormat.ValueMember = "0";
            // 
            // btnReimport
            // 
            btnReimport.Dock = DockStyle.Bottom;
            btnReimport.Location = new Point(4, 502);
            btnReimport.Margin = new Padding(4, 5, 4, 5);
            btnReimport.Name = "btnReimport";
            btnReimport.Size = new Size(396, 40);
            btnReimport.TabIndex = 7;
            btnReimport.Text = "Reimport";
            btnReimport.UseVisualStyleBackColor = true;
            btnReimport.Click += btnReimport_Click;
            // 
            // comboBoxLowcase
            // 
            comboBoxLowcase.DisplayMember = "0";
            comboBoxLowcase.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLowcase.FormattingEnabled = true;
            comboBoxLowcase.Items.AddRange(new object[] { "Yes", "No" });
            comboBoxLowcase.Location = new Point(171, 125);
            comboBoxLowcase.Margin = new Padding(4, 5, 4, 5);
            comboBoxLowcase.Name = "comboBoxLowcase";
            comboBoxLowcase.Size = new Size(223, 28);
            comboBoxLowcase.TabIndex = 5;
            comboBoxLowcase.ValueMember = "0";
            // 
            // comboBoxHeader
            // 
            comboBoxHeader.DisplayMember = "0";
            comboBoxHeader.FormattingEnabled = true;
            comboBoxHeader.Items.AddRange(new object[] { "2", "3", "4", "5", "6" });
            comboBoxHeader.Location = new Point(171, 168);
            comboBoxHeader.Margin = new Padding(4, 5, 4, 5);
            comboBoxHeader.Name = "comboBoxHeader";
            comboBoxHeader.Size = new Size(223, 28);
            comboBoxHeader.TabIndex = 3;
            comboBoxHeader.ValueMember = "0";
            // 
            // comboBoxEncoding
            // 
            comboBoxEncoding.DisplayMember = "0";
            comboBoxEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEncoding.FormattingEnabled = true;
            comboBoxEncoding.Location = new Point(171, 81);
            comboBoxEncoding.Margin = new Padding(4, 5, 4, 5);
            comboBoxEncoding.Name = "comboBoxEncoding";
            comboBoxEncoding.Size = new Size(223, 28);
            comboBoxEncoding.TabIndex = 0;
            comboBoxEncoding.ValueMember = "0";
            // 
            // comboBoxType
            // 
            comboBoxType.DisplayMember = "0";
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Array", "Dict Object" });
            comboBoxType.Location = new Point(171, 39);
            comboBoxType.Margin = new Padding(4, 5, 4, 5);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(223, 28);
            comboBoxType.TabIndex = 0;
            comboBoxType.ValueMember = "0";
            // 
            // tabControlCode
            // 
            tabControlCode.Controls.Add(tabPageJSON);
            tabControlCode.Controls.Add(tabCSharp);
            tabControlCode.Dock = DockStyle.Fill;
            tabControlCode.Location = new Point(0, 0);
            tabControlCode.Margin = new Padding(4, 5, 4, 5);
            tabControlCode.Name = "tabControlCode";
            tabControlCode.SelectedIndex = 0;
            tabControlCode.Size = new Size(840, 857);
            tabControlCode.TabIndex = 0;
            // 
            // tabPageJSON
            // 
            tabPageJSON.Location = new Point(4, 29);
            tabPageJSON.Margin = new Padding(4, 5, 4, 5);
            tabPageJSON.Name = "tabPageJSON";
            tabPageJSON.Padding = new Padding(4, 5, 4, 5);
            tabPageJSON.Size = new Size(832, 824);
            tabPageJSON.TabIndex = 0;
            tabPageJSON.Text = "JSON";
            tabPageJSON.UseVisualStyleBackColor = true;
            // 
            // tabCSharp
            // 
            tabCSharp.Location = new Point(4, 29);
            tabCSharp.Margin = new Padding(4, 5, 4, 5);
            tabCSharp.Name = "tabCSharp";
            tabCSharp.Padding = new Padding(4, 5, 4, 5);
            tabCSharp.Size = new Size(832, 824);
            tabCSharp.TabIndex = 1;
            tabCSharp.Text = "C#";
            tabCSharp.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 936);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip);
            Controls.Add(statusStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1191, 968);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Excel2JsonEX";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panelExcelDropBox.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxExcel).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControlCode.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnImportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnCopyJSON;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelExcelDropBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxExcel;
        private System.Windows.Forms.Label labelExcelFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxLowcase;
        private System.Windows.Forms.ComboBox comboBoxHeader;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripButton btnSaveJson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnReimport;
        private System.Windows.Forms.TabControl tabControlCode;
        private System.Windows.Forms.TabPage tabPageJSON;
        private System.Windows.Forms.ComboBox comboBoxDateFormat;
        private System.Windows.Forms.ComboBox comboBoxSheetName;
        private System.Windows.Forms.TabPage tabCSharp;
        private System.Windows.Forms.ToolStripButton btnCopyCSharp;
        private System.Windows.Forms.ToolStripButton btnSaveCSharp;
        private System.Windows.Forms.TextBox textBoxExculdePrefix;
        private System.Windows.Forms.CheckBox checkBoxCellJson;
        private System.Windows.Forms.CheckBox checkBoxAllString;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
