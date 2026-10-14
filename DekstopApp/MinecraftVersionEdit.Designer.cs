namespace DekstopApp
{
    partial class MinecraftVersionEdit
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
            versionInput1 = new VersionInput();
            OkButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(versionInput1, 0, 0);
            tableLayoutPanel1.Controls.Add(OkButton, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.1052628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.8947372F));
            tableLayoutPanel1.Size = new Size(422, 95);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // versionInput1
            // 
            versionInput1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            versionInput1.Location = new Point(3, 3);
            versionInput1.Name = "versionInput1";
            versionInput1.Size = new Size(416, 53);
            versionInput1.TabIndex = 0;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OkButton.Location = new Point(3, 62);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(416, 30);
            OkButton.TabIndex = 1;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // MinecraftVersionEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 119);
            Controls.Add(tableLayoutPanel1);
            Name = "MinecraftVersionEdit";
            Text = "MinecraftVersionEdit";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private VersionInput versionInput1;
        private Button OkButton;
    }
}