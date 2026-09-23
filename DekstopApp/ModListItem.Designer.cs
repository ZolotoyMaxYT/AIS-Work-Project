namespace DekstopApp
{
    partial class ModListItem
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
            Title = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            OpenButton = new Button();
            DeleteButton = new Button();
            Modpacks = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.BackColor = SystemColors.ControlLightLight;
            Title.Location = new Point(0, 0);
            Title.Margin = new Padding(0);
            Title.Name = "Title";
            Title.Size = new Size(329, 32);
            Title.TabIndex = 0;
            Title.Text = "AAAA v1.0.0 (AAA) by AAAAA";
            Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.62573F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.37427F));
            tableLayoutPanel1.Controls.Add(Title, 0, 0);
            tableLayoutPanel1.Controls.Add(OpenButton, 1, 0);
            tableLayoutPanel1.Controls.Add(DeleteButton, 1, 1);
            tableLayoutPanel1.Controls.Add(Modpacks, 0, 1);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(394, 65);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // OpenButton
            // 
            OpenButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OpenButton.Location = new Point(329, 0);
            OpenButton.Margin = new Padding(0);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(65, 32);
            OpenButton.TabIndex = 1;
            OpenButton.Text = "Open";
            OpenButton.UseVisualStyleBackColor = true;
            OpenButton.Click += OpenButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DeleteButton.Location = new Point(329, 32);
            DeleteButton.Margin = new Padding(0);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(65, 33);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // Modpacks
            // 
            Modpacks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Modpacks.AutoSize = true;
            Modpacks.BackColor = SystemColors.Control;
            Modpacks.Location = new Point(0, 32);
            Modpacks.Margin = new Padding(0);
            Modpacks.Name = "Modpacks";
            Modpacks.Size = new Size(329, 33);
            Modpacks.TabIndex = 3;
            Modpacks.Text = "AAA, AAA, AAA";
            Modpacks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ModListItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(0, 3, 0, 3);
            Name = "ModListItem";
            Size = new Size(400, 71);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label Title;
        private TableLayoutPanel tableLayoutPanel1;
        private Button OpenButton;
        private Button DeleteButton;
        private Label Modpacks;
    }
}
