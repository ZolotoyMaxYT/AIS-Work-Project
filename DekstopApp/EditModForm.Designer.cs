namespace DekstopApp
{
    partial class EditModForm
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
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ModpackInput = new TextBox();
            AuthorInput = new TextBox();
            NameInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            RankInput = new NumericUpDown();
            tableLayoutPanel2 = new TableLayoutPanel();
            label9 = new Label();
            VersionAInput = new NumericUpDown();
            label10 = new Label();
            VersionBInput = new NumericUpDown();
            label11 = new Label();
            VersionCInput = new NumericUpDown();
            label12 = new Label();
            VersionTypeInput = new ComboBox();
            DescriptionInput = new TextBox();
            IDText = new Label();
            TypeText = new Label();
            UpdateButton = new Button();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RankInput).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VersionAInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VersionBInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VersionCInput).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(UpdateButton, 0, 1);
            tableLayoutPanel3.Location = new Point(12, 12);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.Size = new Size(454, 517);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(ModpackInput, 1, 7);
            tableLayoutPanel1.Controls.Add(AuthorInput, 1, 2);
            tableLayoutPanel1.Controls.Add(NameInput, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 7);
            tableLayoutPanel1.Controls.Add(RankInput, 1, 6);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 4);
            tableLayoutPanel1.Controls.Add(DescriptionInput, 1, 3);
            tableLayoutPanel1.Controls.Add(IDText, 1, 0);
            tableLayoutPanel1.Controls.Add(TypeText, 1, 5);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(448, 481);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // ModpackInput
            // 
            ModpackInput.AcceptsReturn = true;
            ModpackInput.AcceptsTab = true;
            ModpackInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModpackInput.Location = new Point(83, 346);
            ModpackInput.Multiline = true;
            ModpackInput.Name = "ModpackInput";
            ModpackInput.ScrollBars = ScrollBars.Both;
            ModpackInput.Size = new Size(362, 132);
            ModpackInput.TabIndex = 15;
            // 
            // AuthorInput
            // 
            AuthorInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AuthorInput.Location = new Point(83, 63);
            AuthorInput.Name = "AuthorInput";
            AuthorInput.Size = new Size(362, 23);
            AuthorInput.TabIndex = 10;
            // 
            // NameInput
            // 
            NameInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NameInput.Location = new Point(83, 33);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(362, 23);
            NameInput.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 30);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(74, 30);
            label2.TabIndex = 1;
            label2.Text = "Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(74, 30);
            label3.TabIndex = 2;
            label3.Text = "Author";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(74, 138);
            label4.TabIndex = 3;
            label4.Text = "Description";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(3, 228);
            label5.Name = "label5";
            label5.Size = new Size(74, 55);
            label5.TabIndex = 4;
            label5.Text = "Version";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(3, 283);
            label6.Name = "label6";
            label6.Size = new Size(74, 30);
            label6.TabIndex = 5;
            label6.Text = "Type";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(3, 313);
            label7.Name = "label7";
            label7.Size = new Size(74, 30);
            label7.TabIndex = 6;
            label7.Text = "Rank";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(3, 343);
            label8.Name = "label8";
            label8.Size = new Size(74, 138);
            label8.TabIndex = 7;
            label8.Text = "Modpacks";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankInput
            // 
            RankInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RankInput.Location = new Point(83, 316);
            RankInput.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            RankInput.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            RankInput.Name = "RankInput";
            RankInput.Size = new Size(362, 23);
            RankInput.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel2.Controls.Add(label9, 0, 1);
            tableLayoutPanel2.Controls.Add(VersionAInput, 0, 0);
            tableLayoutPanel2.Controls.Add(label10, 1, 1);
            tableLayoutPanel2.Controls.Add(VersionBInput, 1, 0);
            tableLayoutPanel2.Controls.Add(label11, 2, 1);
            tableLayoutPanel2.Controls.Add(VersionCInput, 2, 0);
            tableLayoutPanel2.Controls.Add(label12, 3, 1);
            tableLayoutPanel2.Controls.Add(VersionTypeInput, 3, 0);
            tableLayoutPanel2.Location = new Point(83, 231);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 55.10204F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 44.89796F));
            tableLayoutPanel2.Size = new Size(362, 49);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(3, 27);
            label9.Name = "label9";
            label9.Size = new Size(48, 22);
            label9.TabIndex = 1;
            label9.Text = "A";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionAInput
            // 
            VersionAInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionAInput.Location = new Point(3, 0);
            VersionAInput.Margin = new Padding(3, 0, 3, 0);
            VersionAInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            VersionAInput.Name = "VersionAInput";
            VersionAInput.Size = new Size(48, 23);
            VersionAInput.TabIndex = 0;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(57, 27);
            label10.Name = "label10";
            label10.Size = new Size(48, 22);
            label10.TabIndex = 3;
            label10.Text = "B";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionBInput
            // 
            VersionBInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionBInput.Location = new Point(57, 0);
            VersionBInput.Margin = new Padding(3, 0, 3, 0);
            VersionBInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            VersionBInput.Name = "VersionBInput";
            VersionBInput.Size = new Size(48, 23);
            VersionBInput.TabIndex = 2;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.Location = new Point(111, 27);
            label11.Name = "label11";
            label11.Size = new Size(48, 22);
            label11.TabIndex = 5;
            label11.Text = "C";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionCInput
            // 
            VersionCInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionCInput.Location = new Point(111, 0);
            VersionCInput.Margin = new Padding(3, 0, 3, 0);
            VersionCInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            VersionCInput.Name = "VersionCInput";
            VersionCInput.Size = new Size(48, 23);
            VersionCInput.TabIndex = 4;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(165, 27);
            label12.Name = "label12";
            label12.Size = new Size(194, 22);
            label12.TabIndex = 6;
            label12.Text = "type";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionTypeInput
            // 
            VersionTypeInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionTypeInput.FormattingEnabled = true;
            VersionTypeInput.Items.AddRange(new object[] { "ALPHA", "BETA", "RELEASE" });
            VersionTypeInput.Location = new Point(165, 0);
            VersionTypeInput.Margin = new Padding(3, 0, 3, 0);
            VersionTypeInput.Name = "VersionTypeInput";
            VersionTypeInput.Size = new Size(194, 23);
            VersionTypeInput.TabIndex = 7;
            // 
            // DescriptionInput
            // 
            DescriptionInput.AcceptsReturn = true;
            DescriptionInput.AcceptsTab = true;
            DescriptionInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionInput.Location = new Point(83, 93);
            DescriptionInput.Multiline = true;
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.ScrollBars = ScrollBars.Both;
            DescriptionInput.Size = new Size(362, 132);
            DescriptionInput.TabIndex = 14;
            // 
            // IDText
            // 
            IDText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IDText.AutoSize = true;
            IDText.Location = new Point(83, 0);
            IDText.Name = "IDText";
            IDText.Size = new Size(362, 30);
            IDText.TabIndex = 16;
            IDText.Text = "label13";
            IDText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TypeText
            // 
            TypeText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TypeText.AutoSize = true;
            TypeText.Location = new Point(83, 283);
            TypeText.Name = "TypeText";
            TypeText.Size = new Size(362, 30);
            TypeText.TabIndex = 17;
            TypeText.Text = "label13";
            TypeText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UpdateButton
            // 
            UpdateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UpdateButton.Location = new Point(0, 487);
            UpdateButton.Margin = new Padding(0);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(454, 30);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // EditModForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 541);
            Controls.Add(tableLayoutPanel3);
            Name = "EditModForm";
            Text = "Mod info";
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RankInput).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VersionAInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)VersionBInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)VersionCInput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox ModpackInput;
        private TextBox AuthorInput;
        private TextBox NameInput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox IDInput;
        private NumericUpDown RankInput;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label9;
        private NumericUpDown VersionAInput;
        private Label label10;
        private NumericUpDown VersionBInput;
        private Label label11;
        private NumericUpDown VersionCInput;
        private Label label12;
        private ComboBox VersionTypeInput;
        private TextBox DescriptionInput;
        private Button UpdateButton;
        private Label IDText;
        private Label TypeText;
    }
}