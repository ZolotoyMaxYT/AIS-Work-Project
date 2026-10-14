namespace DekstopApp
{
    partial class BanForm
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
            BanButton = new Button();
            IdInput = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(BanButton, 0, 1);
            tableLayoutPanel1.Controls.Add(IdInput, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42.8571434F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 57.1428566F));
            tableLayoutPanel1.Size = new Size(773, 70);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // BanButton
            // 
            BanButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BanButton.Location = new Point(3, 33);
            BanButton.Name = "BanButton";
            BanButton.Size = new Size(767, 34);
            BanButton.TabIndex = 0;
            BanButton.Text = "BAN";
            BanButton.UseVisualStyleBackColor = true;
            BanButton.Click += BanButton_Click;
            // 
            // IdInput
            // 
            IdInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IdInput.FormattingEnabled = true;
            IdInput.Location = new Point(3, 3);
            IdInput.Name = "IdInput";
            IdInput.Size = new Size(767, 23);
            IdInput.TabIndex = 1;
            // 
            // BanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 92);
            Controls.Add(tableLayoutPanel1);
            Name = "BanForm";
            Text = "BanForm";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button BanButton;
        private ComboBox IdInput;
    }
}