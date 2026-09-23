namespace DekstopApp
{
    partial class InfoModForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            TitleText = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            TypeText = new Label();
            VersionText = new Label();
            RankText = new Label();
            AuthorText = new Label();
            ChangeButton = new Button();
            label6 = new Label();
            DescriptionText = new TextBox();
            ModpackText = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(ChangeButton, 0, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(DescriptionText, 0, 1);
            tableLayoutPanel1.Controls.Add(ModpackText, 0, 3);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(683, 554);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackColor = SystemColors.ControlLightLight;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 266F));
            tableLayoutPanel2.Controls.Add(TitleText, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Location = new Point(1, 1);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(681, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // TitleText
            // 
            TitleText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TitleText.AutoSize = true;
            TitleText.BorderStyle = BorderStyle.FixedSingle;
            TitleText.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TitleText.Location = new Point(0, 0);
            TitleText.Margin = new Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new Size(415, 100);
            TitleText.TabIndex = 0;
            TitleText.Text = "[ID] NAME";
            TitleText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(label3, 0, 1);
            tableLayoutPanel3.Controls.Add(label4, 0, 2);
            tableLayoutPanel3.Controls.Add(label5, 0, 3);
            tableLayoutPanel3.Controls.Add(TypeText, 1, 2);
            tableLayoutPanel3.Controls.Add(VersionText, 1, 3);
            tableLayoutPanel3.Controls.Add(RankText, 1, 1);
            tableLayoutPanel3.Controls.Add(AuthorText, 1, 0);
            tableLayoutPanel3.Location = new Point(415, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.Size = new Size(266, 100);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.Location = new Point(4, 1);
            label2.Name = "label2";
            label2.Size = new Size(57, 23);
            label2.TabIndex = 8;
            label2.Text = "Author";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(4, 25);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 6;
            label3.Text = "Rank";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(4, 49);
            label4.Name = "label4";
            label4.Size = new Size(57, 23);
            label4.TabIndex = 7;
            label4.Text = "Type";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.Location = new Point(4, 73);
            label5.Name = "label5";
            label5.Size = new Size(57, 26);
            label5.TabIndex = 5;
            label5.Text = "Version";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TypeText
            // 
            TypeText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TypeText.AutoSize = true;
            TypeText.Font = new Font("Segoe UI", 9.75F);
            TypeText.Location = new Point(68, 49);
            TypeText.Name = "TypeText";
            TypeText.Size = new Size(194, 23);
            TypeText.TabIndex = 4;
            TypeText.Text = "Java Mod";
            TypeText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VersionText
            // 
            VersionText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionText.AutoSize = true;
            VersionText.Font = new Font("Segoe UI", 9.75F);
            VersionText.Location = new Point(68, 73);
            VersionText.Name = "VersionText";
            VersionText.Size = new Size(194, 26);
            VersionText.TabIndex = 2;
            VersionText.Text = "v1.0.0 (Alpha)";
            VersionText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankText
            // 
            RankText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RankText.AutoSize = true;
            RankText.Font = new Font("Segoe UI", 9.75F);
            RankText.Location = new Point(68, 25);
            RankText.Name = "RankText";
            RankText.Size = new Size(194, 23);
            RankText.TabIndex = 3;
            RankText.Text = "100";
            RankText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AuthorText
            // 
            AuthorText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AuthorText.AutoSize = true;
            AuthorText.Font = new Font("Segoe UI", 9.75F);
            AuthorText.Location = new Point(68, 1);
            AuthorText.Name = "AuthorText";
            AuthorText.Size = new Size(194, 23);
            AuthorText.TabIndex = 1;
            AuthorText.Text = "ZMYT";
            AuthorText.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ChangeButton
            // 
            ChangeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChangeButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ChangeButton.Location = new Point(1, 503);
            ChangeButton.Margin = new Padding(0);
            ChangeButton.Name = "ChangeButton";
            ChangeButton.Size = new Size(681, 50);
            ChangeButton.TabIndex = 1;
            ChangeButton.Text = "Edit mod";
            ChangeButton.UseVisualStyleBackColor = true;
            ChangeButton.Click += ChangeButton_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(4, 335);
            label6.Name = "label6";
            label6.Size = new Size(675, 50);
            label6.TabIndex = 3;
            label6.Text = "Modpacks";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DescriptionText
            // 
            DescriptionText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionText.BorderStyle = BorderStyle.None;
            DescriptionText.Location = new Point(4, 105);
            DescriptionText.Multiline = true;
            DescriptionText.Name = "DescriptionText";
            DescriptionText.ReadOnly = true;
            DescriptionText.ScrollBars = ScrollBars.Both;
            DescriptionText.Size = new Size(675, 226);
            DescriptionText.TabIndex = 5;
            // 
            // ModpackText
            // 
            ModpackText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModpackText.BorderStyle = BorderStyle.None;
            ModpackText.Location = new Point(4, 389);
            ModpackText.Multiline = true;
            ModpackText.Name = "ModpackText";
            ModpackText.ReadOnly = true;
            ModpackText.ScrollBars = ScrollBars.Both;
            ModpackText.Size = new Size(675, 110);
            ModpackText.TabIndex = 6;
            // 
            // InfoModForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(707, 578);
            Controls.Add(tableLayoutPanel1);
            Name = "InfoModForm";
            Text = "InfoModForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label TitleText;
        private TableLayoutPanel tableLayoutPanel3;
        private Label VersionText;
        private Label AuthorText;
        private Label RankText;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label TypeText;
        private Button ChangeButton;
        private Label label6;
        private TextBox DescriptionText;
        private TextBox ModpackText;
    }
}