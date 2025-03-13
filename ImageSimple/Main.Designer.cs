namespace ImageSimple
{
    partial class Main
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
            gbImagePath = new GroupBox();
            BtOpenOutputDialog = new Button();
            BtOpenInputDialog = new Button();
            tbFolderOutput = new TextBox();
            LbOutputFolder = new Label();
            label1 = new Label();
            gbGrid = new GroupBox();
            tbYOffset = new TextBox();
            tbXOffset = new TextBox();
            gbGridPixel = new GroupBox();
            label4 = new Label();
            tbGridThickness = new TextBox();
            label2 = new Label();
            tbGridSize = new TextBox();
            tbarYOffset = new TrackBar();
            label12 = new Label();
            label5 = new Label();
            tbarXOffset = new TrackBar();
            colorGrid = new Button();
            button1 = new Button();
            label3 = new Label();
            cbGridType = new ComboBox();
            groupBox3 = new GroupBox();
            cbGridDisabled = new CheckBox();
            groupBox2 = new GroupBox();
            cbSplitterDisabled = new CheckBox();
            gbSplitter = new GroupBox();
            tbSplitterThickness = new TextBox();
            label9 = new Label();
            tbSplitterRows = new TextBox();
            label8 = new Label();
            tbSplitterColomns = new TextBox();
            label7 = new Label();
            button3 = new Button();
            colorSplitter = new Button();
            pBoxImage = new PictureBox();
            btnPreviousImage = new Button();
            btnGenerateImages = new Button();
            btnNextImages = new Button();
            gbImagePath.SuspendLayout();
            gbGrid.SuspendLayout();
            gbGridPixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbarYOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbarXOffset).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            gbSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxImage).BeginInit();
            SuspendLayout();
            // 
            // gbImagePath
            // 
            gbImagePath.Controls.Add(BtOpenOutputDialog);
            gbImagePath.Controls.Add(BtOpenInputDialog);
            gbImagePath.Controls.Add(tbFolderOutput);
            gbImagePath.Controls.Add(LbOutputFolder);
            gbImagePath.Controls.Add(label1);
            gbImagePath.Location = new Point(12, 3);
            gbImagePath.Name = "gbImagePath";
            gbImagePath.Size = new Size(743, 40);
            gbImagePath.TabIndex = 0;
            gbImagePath.TabStop = false;
            gbImagePath.Text = "Images Paths";
            // 
            // BtOpenOutputDialog
            // 
            BtOpenOutputDialog.Location = new Point(687, 14);
            BtOpenOutputDialog.Name = "BtOpenOutputDialog";
            BtOpenOutputDialog.Size = new Size(50, 23);
            BtOpenOutputDialog.TabIndex = 2;
            BtOpenOutputDialog.Text = "Open";
            BtOpenOutputDialog.UseVisualStyleBackColor = true;
            BtOpenOutputDialog.Click += BtOpenOutputDialog_Click;
            // 
            // BtOpenInputDialog
            // 
            BtOpenInputDialog.Anchor = AnchorStyles.Top;
            BtOpenInputDialog.Location = new Point(91, 11);
            BtOpenInputDialog.Name = "BtOpenInputDialog";
            BtOpenInputDialog.Size = new Size(50, 23);
            BtOpenInputDialog.TabIndex = 2;
            BtOpenInputDialog.Text = "Open";
            BtOpenInputDialog.UseVisualStyleBackColor = true;
            BtOpenInputDialog.Click += BtOpenInputDialog_Click;
            // 
            // tbFolderOutput
            // 
            tbFolderOutput.Location = new Point(212, 13);
            tbFolderOutput.Name = "tbFolderOutput";
            tbFolderOutput.ReadOnly = true;
            tbFolderOutput.Size = new Size(469, 23);
            tbFolderOutput.TabIndex = 1;
            // 
            // LbOutputFolder
            // 
            LbOutputFolder.AutoSize = true;
            LbOutputFolder.Location = new Point(158, 15);
            LbOutputFolder.Name = "LbOutputFolder";
            LbOutputFolder.Size = new Size(48, 15);
            LbOutputFolder.TabIndex = 0;
            LbOutputFolder.Text = "Output:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Images:";
            // 
            // gbGrid
            // 
            gbGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbGrid.Controls.Add(tbYOffset);
            gbGrid.Controls.Add(tbXOffset);
            gbGrid.Controls.Add(gbGridPixel);
            gbGrid.Controls.Add(tbarYOffset);
            gbGrid.Controls.Add(label12);
            gbGrid.Controls.Add(label5);
            gbGrid.Controls.Add(tbarXOffset);
            gbGrid.Controls.Add(colorGrid);
            gbGrid.Controls.Add(button1);
            gbGrid.Controls.Add(label3);
            gbGrid.Controls.Add(cbGridType);
            gbGrid.Location = new Point(844, 3);
            gbGrid.Name = "gbGrid";
            gbGrid.Size = new Size(828, 88);
            gbGrid.TabIndex = 1;
            gbGrid.TabStop = false;
            gbGrid.Text = "Grid";
            // 
            // tbYOffset
            // 
            tbYOffset.Location = new Point(366, 45);
            tbYOffset.Name = "tbYOffset";
            tbYOffset.Size = new Size(55, 23);
            tbYOffset.TabIndex = 2;
            // 
            // tbXOffset
            // 
            tbXOffset.Location = new Point(365, 9);
            tbXOffset.Name = "tbXOffset";
            tbXOffset.Size = new Size(55, 23);
            tbXOffset.TabIndex = 2;
            // 
            // gbGridPixel
            // 
            gbGridPixel.Controls.Add(label4);
            gbGridPixel.Controls.Add(tbGridThickness);
            gbGridPixel.Controls.Add(label2);
            gbGridPixel.Controls.Add(tbGridSize);
            gbGridPixel.Location = new Point(153, 9);
            gbGridPixel.Name = "gbGridPixel";
            gbGridPixel.Size = new Size(154, 73);
            gbGridPixel.TabIndex = 7;
            gbGridPixel.TabStop = false;
            gbGridPixel.Text = "In Pixel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 21);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 4;
            label4.Text = "Size";
            // 
            // tbGridThickness
            // 
            tbGridThickness.Location = new Point(80, 36);
            tbGridThickness.Name = "tbGridThickness";
            tbGridThickness.Size = new Size(68, 23);
            tbGridThickness.TabIndex = 6;
            tbGridThickness.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 21);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Thickness";
            // 
            // tbGridSize
            // 
            tbGridSize.Location = new Point(6, 36);
            tbGridSize.Name = "tbGridSize";
            tbGridSize.Size = new Size(68, 23);
            tbGridSize.TabIndex = 5;
            tbGridSize.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // tbarYOffset
            // 
            tbarYOffset.Location = new Point(422, 41);
            tbarYOffset.Maximum = 100;
            tbarYOffset.Name = "tbarYOffset";
            tbarYOffset.Size = new Size(400, 45);
            tbarYOffset.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(311, 48);
            label12.Name = "label12";
            label12.Size = new Size(49, 15);
            label12.TabIndex = 10;
            label12.Text = "Y Offset";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(311, 12);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 2;
            label5.Text = "X Offset";
            // 
            // tbarXOffset
            // 
            tbarXOffset.Location = new Point(422, 9);
            tbarXOffset.Maximum = 100;
            tbarXOffset.Name = "tbarXOffset";
            tbarXOffset.Size = new Size(400, 45);
            tbarXOffset.TabIndex = 9;
            // 
            // colorGrid
            // 
            colorGrid.BackColor = Color.Red;
            colorGrid.Enabled = false;
            colorGrid.Location = new Point(79, 59);
            colorGrid.Name = "colorGrid";
            colorGrid.Size = new Size(68, 23);
            colorGrid.TabIndex = 8;
            colorGrid.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Location = new Point(5, 59);
            button1.Name = "button1";
            button1.Size = new Size(68, 23);
            button1.TabIndex = 7;
            button1.Text = "Color";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 15);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "Type";
            // 
            // cbGridType
            // 
            cbGridType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGridType.FormattingEnabled = true;
            cbGridType.Location = new Point(5, 33);
            cbGridType.Name = "cbGridType";
            cbGridType.Size = new Size(142, 23);
            cbGridType.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbGridDisabled);
            groupBox3.Location = new Point(761, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(74, 88);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "DISABLE";
            // 
            // cbGridDisabled
            // 
            cbGridDisabled.AutoSize = true;
            cbGridDisabled.Location = new Point(24, 37);
            cbGridDisabled.Name = "cbGridDisabled";
            cbGridDisabled.Size = new Size(15, 14);
            cbGridDisabled.TabIndex = 0;
            cbGridDisabled.UseVisualStyleBackColor = true;
            cbGridDisabled.CheckedChanged += cbGridDisabled_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbSplitterDisabled);
            groupBox2.Location = new Point(12, 44);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(85, 47);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "DISABLE";
            // 
            // cbSplitterDisabled
            // 
            cbSplitterDisabled.AutoSize = true;
            cbSplitterDisabled.Location = new Point(27, 21);
            cbSplitterDisabled.Name = "cbSplitterDisabled";
            cbSplitterDisabled.Size = new Size(15, 14);
            cbSplitterDisabled.TabIndex = 0;
            cbSplitterDisabled.UseVisualStyleBackColor = true;
            cbSplitterDisabled.CheckedChanged += cbSplitterDisabled_CheckedChanged;
            // 
            // gbSplitter
            // 
            gbSplitter.Controls.Add(tbSplitterThickness);
            gbSplitter.Controls.Add(label9);
            gbSplitter.Controls.Add(tbSplitterRows);
            gbSplitter.Controls.Add(label8);
            gbSplitter.Controls.Add(tbSplitterColomns);
            gbSplitter.Controls.Add(label7);
            gbSplitter.Controls.Add(button3);
            gbSplitter.Controls.Add(colorSplitter);
            gbSplitter.Location = new Point(103, 44);
            gbSplitter.Name = "gbSplitter";
            gbSplitter.Size = new Size(652, 47);
            gbSplitter.TabIndex = 4;
            gbSplitter.TabStop = false;
            gbSplitter.Text = "Splitter";
            // 
            // tbSplitterThickness
            // 
            tbSplitterThickness.Location = new Point(577, 16);
            tbSplitterThickness.Name = "tbSplitterThickness";
            tbSplitterThickness.Size = new Size(60, 23);
            tbSplitterThickness.TabIndex = 10;
            tbSplitterThickness.Text = "2";
            tbSplitterThickness.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(403, 19);
            label9.Name = "label9";
            label9.Size = new Size(171, 15);
            label9.TabIndex = 9;
            label9.Text = "Preview Line Thickness in Pixel:";
            // 
            // tbSplitterRows
            // 
            tbSplitterRows.Location = new Point(173, 15);
            tbSplitterRows.Name = "tbSplitterRows";
            tbSplitterRows.Size = new Size(53, 23);
            tbSplitterRows.TabIndex = 7;
            tbSplitterRows.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(126, 20);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 6;
            label8.Text = "Rows: ";
            // 
            // tbSplitterColomns
            // 
            tbSplitterColomns.Location = new Point(67, 17);
            tbSplitterColomns.Name = "tbSplitterColomns";
            tbSplitterColomns.Size = new Size(53, 23);
            tbSplitterColomns.TabIndex = 5;
            tbSplitterColomns.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 21);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 0;
            label7.Text = "Columns:";
            // 
            // button3
            // 
            button3.Location = new Point(232, 15);
            button3.Name = "button3";
            button3.Size = new Size(91, 23);
            button3.TabIndex = 7;
            button3.Text = "Preview Color";
            button3.UseVisualStyleBackColor = true;
            // 
            // colorSplitter
            // 
            colorSplitter.BackColor = Color.Yellow;
            colorSplitter.Enabled = false;
            colorSplitter.Location = new Point(329, 15);
            colorSplitter.Name = "colorSplitter";
            colorSplitter.Size = new Size(68, 23);
            colorSplitter.TabIndex = 8;
            colorSplitter.UseVisualStyleBackColor = false;
            // 
            // pBoxImage
            // 
            pBoxImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pBoxImage.Location = new Point(12, 97);
            pBoxImage.Name = "pBoxImage";
            pBoxImage.Size = new Size(1660, 431);
            pBoxImage.TabIndex = 5;
            pBoxImage.TabStop = false;
            // 
            // btnPreviousImage
            // 
            btnPreviousImage.Anchor = AnchorStyles.None;
            btnPreviousImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPreviousImage.Location = new Point(12, 534);
            btnPreviousImage.Name = "btnPreviousImage";
            btnPreviousImage.Size = new Size(75, 23);
            btnPreviousImage.TabIndex = 6;
            btnPreviousImage.Text = "<--";
            btnPreviousImage.UseVisualStyleBackColor = true;
            // 
            // btnGenerateImages
            // 
            btnGenerateImages.Anchor = AnchorStyles.None;
            btnGenerateImages.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateImages.Location = new Point(103, 534);
            btnGenerateImages.Name = "btnGenerateImages";
            btnGenerateImages.Size = new Size(155, 23);
            btnGenerateImages.TabIndex = 7;
            btnGenerateImages.Text = "Generate Images";
            btnGenerateImages.UseVisualStyleBackColor = true;
            // 
            // btnNextImages
            // 
            btnNextImages.Anchor = AnchorStyles.None;
            btnNextImages.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextImages.Location = new Point(276, 534);
            btnNextImages.Name = "btnNextImages";
            btnNextImages.Size = new Size(75, 23);
            btnNextImages.TabIndex = 6;
            btnNextImages.Text = "-->";
            btnNextImages.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 561);
            Controls.Add(btnGenerateImages);
            Controls.Add(btnNextImages);
            Controls.Add(btnPreviousImage);
            Controls.Add(pBoxImage);
            Controls.Add(gbSplitter);
            Controls.Add(groupBox2);
            Controls.Add(gbGrid);
            Controls.Add(gbImagePath);
            Controls.Add(groupBox3);
            Name = "Main";
            Text = "Image Simple";
            FormClosing += Main_FormClosing;
            Resize += Main_Resize;
            gbImagePath.ResumeLayout(false);
            gbImagePath.PerformLayout();
            gbGrid.ResumeLayout(false);
            gbGrid.PerformLayout();
            gbGridPixel.ResumeLayout(false);
            gbGridPixel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbarYOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbarXOffset).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gbSplitter.ResumeLayout(false);
            gbSplitter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbImagePath;
        private Label label1;
        private Button BtOpenOutputDialog;
        private Button BtOpenInputDialog;
        private TextBox tbFolderOutput;
        private Label LbOutputFolder;
        private GroupBox gbGrid;
        private Label label3;
        private ComboBox cbGridType;
        private CheckBox cbGridDisabled;
        private GroupBox groupBox3;
        private TextBox tbGridSize;
        private Label label4;
        private Button colorGrid;
        private Button button1;
        private TextBox tbGridThickness;
        private Label label2;
        private TrackBar tbarXOffset;
        private Label label5;
        private TrackBar tbarYOffset;
        private Label label12;
        private GroupBox gbGridPixel;
        private TextBox tbYOffset;
        private TextBox tbXOffset;
        private GroupBox groupBox2;
        private CheckBox cbSplitterDisabled;
        private GroupBox gbSplitter;
        private Label label8;
        private TextBox tbSplitterColomns;
        private Label label7;
        private TextBox tbSplitterThickness;
        private Label label9;
        private TextBox tbSplitterRows;
        private Button button3;
        private Button colorSplitter;
        private PictureBox pBoxImage;
        private Button btnPreviousImage;
        private Button btnGenerateImages;
        private Button btnNextImages;
    }
}
