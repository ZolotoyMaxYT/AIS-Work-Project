namespace DekstopApp
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
            CreateButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            ModList = new FlowLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CreateButton.Location = new Point(78, 357);
            CreateButton.Margin = new Padding(0, 2, 0, 2);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(573, 32);
            CreateButton.TabIndex = 0;
            CreateButton.Text = "New mod";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7474575F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.50508F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7474575F));
            tableLayoutPanel2.Controls.Add(CreateButton, 1, 1);
            tableLayoutPanel2.Controls.Add(ModList, 1, 0);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.94827F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.051724F));
            tableLayoutPanel2.Size = new Size(730, 391);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // ModList
            // 
            ModList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModList.AutoScroll = true;
            ModList.FlowDirection = FlowDirection.TopDown;
            ModList.ImeMode = ImeMode.NoControl;
            ModList.Location = new Point(81, 3);
            ModList.Name = "ModList";
            ModList.Size = new Size(567, 349);
            ModList.TabIndex = 1;
            ModList.WrapContents = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 415);
            Controls.Add(tableLayoutPanel2);
            Name = "MainForm";
            Text = "Main";
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button CreateButton;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel ModList;
    }
}
