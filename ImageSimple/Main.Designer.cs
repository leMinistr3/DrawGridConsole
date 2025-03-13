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
            btnSelectGridColor = new Button();
            label3 = new Label();
            cbGridType = new ComboBox();
            gbGridDisabled = new GroupBox();
            cbGridDisabled = new CheckBox();
            gbSplitterDisabled = new GroupBox();
            cbSplitterDisabled = new CheckBox();
            gbSplitter = new GroupBox();
            tbSplitterThickness = new TextBox();
            label9 = new Label();
            tbSplitterRows = new TextBox();
            label8 = new Label();
            tbSplitterColomns = new TextBox();
            label7 = new Label();
            btnSelectSplitterColor = new Button();
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
            gbGridDisabled.SuspendLayout();
            gbSplitterDisabled.SuspendLayout();
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
            gbGrid.Controls.Add(btnSelectGridColor);
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
            tbYOffset.ReadOnly = true;
            tbYOffset.Size = new Size(55, 23);
            tbYOffset.TabIndex = 2;
            // 
            // tbXOffset
            // 
            tbXOffset.Location = new Point(365, 9);
            tbXOffset.Name = "tbXOffset";
            tbXOffset.ReadOnly = true;
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
            tbGridThickness.TextChanged += tbGridThickness_TextChanged;
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
            tbGridSize.TextChanged += tbGridSize_TextChanged;
            tbGridSize.KeyPress += OnlyNumberTextBox_KeyPress;
            // 
            // tbarYOffset
            // 
            tbarYOffset.Location = new Point(422, 41);
            tbarYOffset.Maximum = 100;
            tbarYOffset.Name = "tbarYOffset";
            tbarYOffset.Size = new Size(400, 45);
            tbarYOffset.TabIndex = 11;
            tbarYOffset.VisibleChanged += tbarYOffset_VisibleChanged;
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
            tbarXOffset.ValueChanged += tbarXOffset_ValueChanged;
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
            // btnSelectGridColor
            // 
            btnSelectGridColor.Location = new Point(5, 59);
            btnSelectGridColor.Name = "btnSelectGridColor";
            btnSelectGridColor.Size = new Size(68, 23);
            btnSelectGridColor.TabIndex = 7;
            btnSelectGridColor.Text = "Color";
            btnSelectGridColor.UseVisualStyleBackColor = true;
            btnSelectGridColor.Click += btnSelectGridColor_Click;
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
            cbGridType.SelectedIndexChanged += cbGridType_SelectedIndexChanged;
            // 
            // gbGridDisabled
            // 
            gbGridDisabled.Controls.Add(cbGridDisabled);
            gbGridDisabled.Location = new Point(761, 3);
            gbGridDisabled.Name = "gbGridDisabled";
            gbGridDisabled.Size = new Size(74, 88);
            gbGridDisabled.TabIndex = 2;
            gbGridDisabled.TabStop = false;
            gbGridDisabled.Text = "DISABLE";
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
            // gbSplitterDisabled
            // 
            gbSplitterDisabled.Controls.Add(cbSplitterDisabled);
            gbSplitterDisabled.Location = new Point(12, 44);
            gbSplitterDisabled.Name = "gbSplitterDisabled";
            gbSplitterDisabled.Size = new Size(85, 47);
            gbSplitterDisabled.TabIndex = 3;
            gbSplitterDisabled.TabStop = false;
            gbSplitterDisabled.Text = "DISABLE";
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
            gbSplitter.Controls.Add(btnSelectSplitterColor);
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
            tbSplitterThickness.TextChanged += tbSplitterThickness_TextChanged;
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
            tbSplitterRows.TextChanged += tbSplitterRows_TextChanged;
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
            tbSplitterColomns.TextChanged += tbSplitterColomns_TextChanged;
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
            // btnSelectSplitterColor
            // 
            btnSelectSplitterColor.Location = new Point(232, 15);
            btnSelectSplitterColor.Name = "btnSelectSplitterColor";
            btnSelectSplitterColor.Size = new Size(91, 23);
            btnSelectSplitterColor.TabIndex = 7;
            btnSelectSplitterColor.Text = "Preview Color";
            btnSelectSplitterColor.UseVisualStyleBackColor = true;
            btnSelectSplitterColor.Click += btnSelectSplitterColor_Click;
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
            pBoxImage.BackgroundImageLayout = ImageLayout.None;
            pBoxImage.Location = new Point(12, 97);
            pBoxImage.Name = "pBoxImage";
            pBoxImage.Size = new Size(1660, 431);
            pBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
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
            btnPreviousImage.Click += btnPreviousImage_Click;
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
            btnGenerateImages.Click += btnGenerateImages_Click;
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
            btnNextImages.Click += btnNextImages_Click;
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
            Controls.Add(gbSplitterDisabled);
            Controls.Add(gbGrid);
            Controls.Add(gbImagePath);
            Controls.Add(gbGridDisabled);
            Name = "Main";
            Text = "Image Simple";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Resize += Main_Resize;
            gbImagePath.ResumeLayout(false);
            gbImagePath.PerformLayout();
            gbGrid.ResumeLayout(false);
            gbGrid.PerformLayout();
            gbGridPixel.ResumeLayout(false);
            gbGridPixel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbarYOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbarXOffset).EndInit();
            gbGridDisabled.ResumeLayout(false);
            gbGridDisabled.PerformLayout();
            gbSplitterDisabled.ResumeLayout(false);
            gbSplitterDisabled.PerformLayout();
            gbSplitter.ResumeLayout(false);
            gbSplitter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public TextBox tbFolderOutput;

        public CheckBox cbGridDisabled;
        public ComboBox cbGridType;
        public Button colorGrid;
        public TextBox tbGridSize;
        public TextBox tbGridThickness;
        public TextBox tbXOffset;
        public TextBox tbYOffset;
        public TrackBar tbarXOffset;
        public TrackBar tbarYOffset;

        public CheckBox cbSplitterDisabled;
        public Button colorSplitter;
        public TextBox tbSplitterRows;
        public TextBox tbSplitterColomns;
        public TextBox tbSplitterThickness;

        public PictureBox pBoxImage;
        public Button btnPreviousImage;
        public Button btnGenerateImages;
        public Button btnNextImages;

        private GroupBox gbImagePath;
        private Label label1;
        private Button BtOpenOutputDialog;
        private Button BtOpenInputDialog;
        private Label LbOutputFolder;
        private GroupBox gbGrid;
        private Label label3;
        private GroupBox gbGridDisabled;
        private Label label4;
        private Button btnSelectGridColor;
        private Label label2;
        private Label label5;
        private Label label12;
        private GroupBox gbGridPixel;
        private GroupBox gbSplitterDisabled;
        private GroupBox gbSplitter;
        private Label label8;
        private Label label7;
        private Label label9;
        private Button btnSelectSplitterColor;
    }
}
