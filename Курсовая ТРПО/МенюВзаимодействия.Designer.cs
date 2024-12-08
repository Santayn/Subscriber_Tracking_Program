namespace Курсовая_ТРПО
{
    partial class МенюВзаимодействия
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(МенюВзаимодействия));
            this.Chat = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.дополнительныеФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmail = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chat
            // 
            this.Chat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Chat.AutoSize = true;
            this.Chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat.Location = new System.Drawing.Point(378, 35);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(162, 41);
            this.Chat.TabIndex = 2;
            this.Chat.Text = "Начать чат";
            this.Chat.UseVisualStyleBackColor = true;
            this.Chat.Click += new System.EventHandler(this.Chat_Click);
            // 
            // Save
            // 
            this.Save.AutoSize = true;
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(368, 507);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(180, 34);
            this.Save.TabIndex = 3;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(368, 272);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(180, 227);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(368, 217);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(368, 160);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(180, 20);
            this.textBox4.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(353, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Номер телефона";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(410, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 16;
            this.label3.Text = "Статус";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(374, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Примечания";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дополнительныеФункцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // дополнительныеФункцииToolStripMenuItem
            // 
            this.дополнительныеФункцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Delete,
            this.Info});
            this.дополнительныеФункцииToolStripMenuItem.Name = "дополнительныеФункцииToolStripMenuItem";
            this.дополнительныеФункцииToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.дополнительныеФункцииToolStripMenuItem.Text = "Функции";
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(284, 22);
            this.Delete.Text = "Удалить Абонента";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(284, 22);
            this.Info.Text = "Добавить или обновить информацию";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // SendEmail
            // 
            this.SendEmail.BackColor = System.Drawing.Color.Transparent;
            this.SendEmail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SendEmail.BackgroundImage")));
            this.SendEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SendEmail.FlatAppearance.BorderSize = 0;
            this.SendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendEmail.ForeColor = System.Drawing.Color.Transparent;
            this.SendEmail.Location = new System.Drawing.Point(842, 532);
            this.SendEmail.Name = "SendEmail";
            this.SendEmail.Size = new System.Drawing.Size(49, 51);
            this.SendEmail.TabIndex = 19;
            this.SendEmail.UseVisualStyleBackColor = false;
            this.SendEmail.Click += new System.EventHandler(this.button5_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackButton.BackgroundImage")));
            this.BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.ForeColor = System.Drawing.Color.Transparent;
            this.BackButton.Location = new System.Drawing.Point(842, 38);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(37, 38);
            this.BackButton.TabIndex = 20;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.619952F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.38005F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.Controls.Add(this.SendEmail, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Chat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BackButton, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.70946F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 588);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BackColor = System.Drawing.Color.ForestGreen;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox2.Location = new System.Drawing.Point(83, 532);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(753, 51);
            this.richTextBox2.TabIndex = 22;
            this.richTextBox2.Text = "";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(83, 82);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(753, 444);
            this.flowLayoutPanel2.TabIndex = 23;
            // 
            // МенюВзаимодействия
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 588);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "МенюВзаимодействия";
            this.Text = "МенюВзаимодействия";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.МенюВзаимодействия_FormClosed);
            this.Load += new System.EventHandler(this.МенюВзаимодействия_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Chat;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem дополнительныеФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.Button SendEmail;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}