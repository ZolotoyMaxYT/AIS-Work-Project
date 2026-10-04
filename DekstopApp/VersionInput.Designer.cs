namespace DekstopApp
{
    partial class VersionInput
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel2 = new TableLayoutPanel();
            label9 = new Label();
            VersionAInput = new NumericUpDown();
            label10 = new Label();
            VersionBInput = new NumericUpDown();
            label11 = new Label();
            VersionCInput = new NumericUpDown();
            label12 = new Label();
            VersionTypeInput = new ComboBox();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VersionAInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VersionBInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VersionCInput).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(label9, 0, 1);
            tableLayoutPanel2.Controls.Add(VersionAInput, 0, 0);
            tableLayoutPanel2.Controls.Add(label10, 1, 1);
            tableLayoutPanel2.Controls.Add(VersionBInput, 1, 0);
            tableLayoutPanel2.Controls.Add(label11, 2, 1);
            tableLayoutPanel2.Controls.Add(VersionCInput, 2, 0);
            tableLayoutPanel2.Controls.Add(label12, 3, 1);
            tableLayoutPanel2.Controls.Add(VersionTypeInput, 3, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 55.10204F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 44.89796F));
            tableLayoutPanel2.Size = new Size(410, 46);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(3, 25);
            label9.Name = "label9";
            label9.Size = new Size(76, 21);
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
            VersionAInput.Size = new Size(76, 23);
            VersionAInput.TabIndex = 0;
            VersionAInput.ValueChanged += VersionAInput_ValueChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label10.Location = new Point(85, 25);
            label10.Name = "label10";
            label10.Size = new Size(76, 21);
            label10.TabIndex = 3;
            label10.Text = "B";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionBInput
            // 
            VersionBInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionBInput.Location = new Point(85, 0);
            VersionBInput.Margin = new Padding(3, 0, 3, 0);
            VersionBInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            VersionBInput.Name = "VersionBInput";
            VersionBInput.Size = new Size(76, 23);
            VersionBInput.TabIndex = 2;
            VersionBInput.ValueChanged += VersionBInput_ValueChanged;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.Location = new Point(167, 25);
            label11.Name = "label11";
            label11.Size = new Size(76, 21);
            label11.TabIndex = 5;
            label11.Text = "C";
            label11.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionCInput
            // 
            VersionCInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionCInput.Location = new Point(167, 0);
            VersionCInput.Margin = new Padding(3, 0, 3, 0);
            VersionCInput.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            VersionCInput.Name = "VersionCInput";
            VersionCInput.Size = new Size(76, 23);
            VersionCInput.TabIndex = 4;
            VersionCInput.ValueChanged += VersionCInput_ValueChanged;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(249, 25);
            label12.Name = "label12";
            label12.Size = new Size(158, 21);
            label12.TabIndex = 6;
            label12.Text = "type";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // VersionTypeInput
            // 
            VersionTypeInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VersionTypeInput.DisplayMember = "0";
            VersionTypeInput.FormattingEnabled = true;
            VersionTypeInput.Items.AddRange(new object[] { "ALPHA", "BETA", "RELEASE" });
            VersionTypeInput.Location = new Point(249, 0);
            VersionTypeInput.Margin = new Padding(3, 0, 3, 0);
            VersionTypeInput.Name = "VersionTypeInput";
            VersionTypeInput.Size = new Size(158, 23);
            VersionTypeInput.TabIndex = 7;
            VersionTypeInput.SelectedIndexChanged += VersionTypeInput_SelectedIndexChanged;
            // 
            // VersionInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel2);
            Name = "VersionInput";
            Size = new Size(410, 46);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VersionAInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)VersionBInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)VersionCInput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Label label9;
        private NumericUpDown VersionAInput;
        private Label label10;
        private NumericUpDown VersionBInput;
        private Label label11;
        private NumericUpDown VersionCInput;
        private Label label12;
        private ComboBox VersionTypeInput;
    }
}
