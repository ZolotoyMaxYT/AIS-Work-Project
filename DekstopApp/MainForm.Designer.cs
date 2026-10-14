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
            MinecraftVersionButton = new Button();
            BanButton = new Button();
            ShadowBanButton = new Button();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CreateButton.Location = new Point(79, 402);
            CreateButton.Margin = new Padding(0, 2, 0, 2);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(577, 35);
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
            tableLayoutPanel2.Controls.Add(MinecraftVersionButton, 1, 2);
            tableLayoutPanel2.Controls.Add(BanButton, 2, 1);
            tableLayoutPanel2.Controls.Add(ShadowBanButton, 0, 1);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.94827F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.051724F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel2.Size = new Size(736, 479);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // ModList
            // 
            ModList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ModList.AutoScroll = true;
            ModList.FlowDirection = FlowDirection.TopDown;
            ModList.ImeMode = ImeMode.NoControl;
            ModList.Location = new Point(82, 3);
            ModList.Name = "ModList";
            ModList.Size = new Size(571, 394);
            ModList.TabIndex = 1;
            ModList.WrapContents = false;
            // 
            // MinecraftVersionButton
            // 
            MinecraftVersionButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MinecraftVersionButton.Location = new Point(79, 439);
            MinecraftVersionButton.Margin = new Padding(0);
            MinecraftVersionButton.Name = "MinecraftVersionButton";
            MinecraftVersionButton.Padding = new Padding(3);
            MinecraftVersionButton.Size = new Size(577, 40);
            MinecraftVersionButton.TabIndex = 2;
            MinecraftVersionButton.Text = "Minecraft version is v1.7.10 (click to change)";
            MinecraftVersionButton.UseVisualStyleBackColor = true;
            MinecraftVersionButton.Click += MinecraftVersionButton_Click;
            // 
            // BanButton
            // 
            BanButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BanButton.Location = new Point(659, 403);
            BanButton.Name = "BanButton";
            BanButton.Size = new Size(74, 33);
            BanButton.TabIndex = 3;
            BanButton.Text = "BAN";
            BanButton.UseVisualStyleBackColor = true;
            BanButton.Click += BanButton_Click;
            // 
            // ShadowBanButton
            // 
            ShadowBanButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ShadowBanButton.Location = new Point(3, 403);
            ShadowBanButton.Name = "ShadowBanButton";
            ShadowBanButton.Size = new Size(73, 33);
            ShadowBanButton.TabIndex = 4;
            ShadowBanButton.Text = "SHADOW";
            ShadowBanButton.UseVisualStyleBackColor = true;
            ShadowBanButton.Click += ShadowBanButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 503);
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
        private Button MinecraftVersionButton;
        private Button BanButton;
        private Button ShadowBanButton;
    }
}
