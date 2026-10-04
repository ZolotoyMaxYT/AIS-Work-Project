namespace DekstopApp
{
    partial class NewModForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            AuthorInput = new TextBox();
            NameInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            IDInput = new TextBox();
            DescriptionInput = new TextBox();
            VersionInput = new VersionInput();
            TagsInput = new TextBox();
            label8 = new Label();
            label7 = new Label();
            RankInput = new NumericUpDown();
            label6 = new Label();
            IsJavaInput = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            MinecraftVersionFirstInput = new VersionInput();
            MinecraftVersionLastInput = new VersionInput();
            tableLayoutPanel3 = new TableLayoutPanel();
            CreateButton = new Button();
            label9 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RankInput).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(AuthorInput, 1, 2);
            tableLayoutPanel1.Controls.Add(NameInput, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(IDInput, 1, 0);
            tableLayoutPanel1.Controls.Add(DescriptionInput, 1, 3);
            tableLayoutPanel1.Controls.Add(VersionInput, 1, 4);
            tableLayoutPanel1.Controls.Add(TagsInput, 1, 8);
            tableLayoutPanel1.Controls.Add(label8, 0, 8);
            tableLayoutPanel1.Controls.Add(label7, 0, 7);
            tableLayoutPanel1.Controls.Add(RankInput, 1, 7);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Controls.Add(IsJavaInput, 1, 6);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 5);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(616, 584);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // AuthorInput
            // 
            AuthorInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AuthorInput.Location = new Point(83, 63);
            AuthorInput.Name = "AuthorInput";
            AuthorInput.Size = new Size(530, 23);
            AuthorInput.TabIndex = 10;
            // 
            // NameInput
            // 
            NameInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NameInput.Location = new Point(83, 33);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(530, 23);
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
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(74, 167);
            label4.TabIndex = 3;
            label4.Text = "Description";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(3, 257);
            label5.Name = "label5";
            label5.Size = new Size(74, 50);
            label5.TabIndex = 4;
            label5.Text = "Version";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IDInput
            // 
            IDInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IDInput.Location = new Point(83, 3);
            IDInput.Name = "IDInput";
            IDInput.Size = new Size(530, 23);
            IDInput.TabIndex = 8;
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
            DescriptionInput.Size = new Size(530, 161);
            DescriptionInput.TabIndex = 14;
            // 
            // VersionInput
            // 
            VersionInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionInput.Location = new Point(83, 260);
            VersionInput.Name = "VersionInput";
            VersionInput.Size = new Size(530, 44);
            VersionInput.TabIndex = 16;
            // 
            // TagsInput
            // 
            TagsInput.AcceptsReturn = true;
            TagsInput.AcceptsTab = true;
            TagsInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TagsInput.Location = new Point(83, 420);
            TagsInput.Multiline = true;
            TagsInput.Name = "TagsInput";
            TagsInput.ScrollBars = ScrollBars.Both;
            TagsInput.Size = new Size(530, 161);
            TagsInput.TabIndex = 15;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(3, 417);
            label8.Name = "label8";
            label8.Size = new Size(74, 167);
            label8.TabIndex = 7;
            label8.Text = "Tags";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(3, 387);
            label7.Name = "label7";
            label7.Size = new Size(74, 30);
            label7.TabIndex = 6;
            label7.Text = "Rank";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RankInput
            // 
            RankInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RankInput.Location = new Point(83, 390);
            RankInput.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            RankInput.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            RankInput.Name = "RankInput";
            RankInput.Size = new Size(530, 23);
            RankInput.TabIndex = 11;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(3, 357);
            label6.Name = "label6";
            label6.Size = new Size(74, 30);
            label6.TabIndex = 5;
            label6.Text = "Type";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IsJavaInput
            // 
            IsJavaInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IsJavaInput.DisplayMember = "0";
            IsJavaInput.FormattingEnabled = true;
            IsJavaInput.Items.AddRange(new object[] { "is java mod", "is bedrock mod" });
            IsJavaInput.Location = new Point(83, 360);
            IsJavaInput.Name = "IsJavaInput";
            IsJavaInput.Size = new Size(530, 23);
            IsJavaInput.TabIndex = 12;
            IsJavaInput.ValueMember = "0";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(MinecraftVersionFirstInput, 0, 0);
            tableLayoutPanel2.Controls.Add(MinecraftVersionLastInput, 1, 0);
            tableLayoutPanel2.Location = new Point(80, 307);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(536, 50);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // MinecraftVersionFirstInput
            // 
            MinecraftVersionFirstInput.Location = new Point(3, 3);
            MinecraftVersionFirstInput.Name = "MinecraftVersionFirstInput";
            MinecraftVersionFirstInput.Size = new Size(262, 44);
            MinecraftVersionFirstInput.TabIndex = 0;
            // 
            // MinecraftVersionLastInput
            // 
            MinecraftVersionLastInput.Location = new Point(271, 3);
            MinecraftVersionLastInput.Name = "MinecraftVersionLastInput";
            MinecraftVersionLastInput.Size = new Size(262, 44);
            MinecraftVersionLastInput.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(CreateButton, 0, 1);
            tableLayoutPanel3.Location = new Point(12, 12);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.Size = new Size(622, 620);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // CreateButton
            // 
            CreateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CreateButton.Location = new Point(0, 590);
            CreateButton.Margin = new Padding(0);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(622, 30);
            CreateButton.TabIndex = 1;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(3, 307);
            label9.Name = "label9";
            label9.Size = new Size(74, 50);
            label9.TabIndex = 18;
            label9.Text = "Minecraft version";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewModForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 644);
            Controls.Add(tableLayoutPanel3);
            Name = "NewModForm";
            Text = "NewModForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RankInput).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox AuthorInput;
        private TextBox NameInput;
        private TextBox IDInput;
        private NumericUpDown RankInput;
        private ComboBox IsJavaInput;
        private TextBox TagsInput;
        private TextBox DescriptionInput;
        private TableLayoutPanel tableLayoutPanel3;
        private Button CreateButton;
        private VersionInput VersionInput;
        private TableLayoutPanel tableLayoutPanel2;
        private VersionInput MinecraftVersionFirstInput;
        private VersionInput MinecraftVersionLastInput;
        private Label label9;
    }
}