namespace Курсовая_ТРПО
{
    partial class Many
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Many));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.WorkWith = new System.Windows.Forms.Button();
            this.AddAbonent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поддержкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Location = new System.Drawing.Point(345, 336);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(828, 236);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // WorkWith
            // 
            this.WorkWith.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WorkWith.Location = new System.Drawing.Point(345, 372);
            this.WorkWith.Name = "WorkWith";
            this.WorkWith.Size = new System.Drawing.Size(144, 23);
            this.WorkWith.TabIndex = 8;
            this.WorkWith.Text = "Взаимодействовать";
            this.WorkWith.UseVisualStyleBackColor = true;
            this.WorkWith.Click += new System.EventHandler(this.WorkWith_Click);
            // 
            // AddAbonent
            // 
            this.AddAbonent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddAbonent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AddAbonent.Location = new System.Drawing.Point(345, 412);
            this.AddAbonent.Name = "AddAbonent";
            this.AddAbonent.Size = new System.Drawing.Size(144, 23);
            this.AddAbonent.TabIndex = 4;
            this.AddAbonent.Text = "Добавить абонента";
            this.AddAbonent.UseVisualStyleBackColor = true;
            this.AddAbonent.Click += new System.EventHandler(this.AddAbonent_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.Location = new System.Drawing.Point(279, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Перейти в режим админа";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поддержкаToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // поддержкаToolStripMenuItem
            // 
            this.поддержкаToolStripMenuItem.Name = "поддержкаToolStripMenuItem";
            this.поддержкаToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.поддержкаToolStripMenuItem.Text = "Поддержка";
            this.поддержкаToolStripMenuItem.Click += new System.EventHandler(this.поддержкаToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(343, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Введите Логин";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AddAbonent, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.WorkWith, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 472);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Many
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 472);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Many";
            this.Text = "Many";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Many_FormClosed);
            this.Load += new System.EventHandler(this.Many_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button WorkWith;
        private System.Windows.Forms.Button AddAbonent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поддержкаToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}