using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовая_ТРПО
{
    public partial class Help : Form
    {
        public static string MyyConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=18.mdb";
        private OleDbConnection MyConnection;
        private string User;
        private int Role;
        public int I;

        public Help(string Name, int role)
        {
            this.User = Name;
            Role = role;
            InitializeComponent();
            MyConnection = new OleDbConnection(MyyConnection);
            MyConnection.Open();
            textBox4.Visible = false;
            richTextBox1.Visible = false;
            BackButton.Visible = false;
            SendEmail.Visible = false;
        }

        private void Help_Load(object sender, EventArgs e)
        {
        }
        private void LoadNamesTopics()
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();
                using (OleDbDataReader reader = LoadNamesTopicsBlamerNotBlamer()) 
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0); // Получаем значение столбца "ФИО"

                        // Создаем метку для отображения имени
                        Label nameLabel = new Label
                        {
                            Text = name,
                            AutoSize = true,
                            Margin = new Padding(5),
                            Font = new Font("Arial", 14, FontStyle.Regular)
                        };
                        // Добавляем метку в контейнер (например, FlowLayoutPanel)
                        nameLabel.BackColor = Color.LightBlue; // Добавить фон для выделения сообщений пользователя
                        flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel2.Controls.Add(nameLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrintMessegeThisTopic(string Sender, string Reciver)
        {
            try
            {
                string Tem = textBox4.Text;
                flowLayoutPanel2.Visible = true;
                string query = $"SELECT Текст, Отправитель FROM Обращение_В_Поддержку WHERE ((Отправитель = '{Sender}' And Получатель ='{Reciver}') OR (Отправитель = '{Reciver}' And Получатель ='{Sender}')) AND Тема ='{Tem}' ORDER BY ВремяОтправки";

                OleDbCommand command = new OleDbCommand(query, MyConnection);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string messageText = reader.GetString(0);
                        string messageSender = reader.GetString(1);

                        // Создаем метку для текста сообщения
                        Label messageLabel = new Label
                        {
                            Text = messageText,
                            AutoSize = true,
                            Margin = new Padding(5),
                            Font = new Font("Arial", 12, FontStyle.Regular),
                            Width = flowLayoutPanel2.Width
                    };

                        // Если сообщение отправлено пользователем (Sender), выравниваем его вправо
                        if (messageSender == Sender)
                        {
                            messageLabel.Width = flowLayoutPanel2.Width;
                            messageLabel.TextAlign = ContentAlignment.MiddleRight;
                            messageLabel.Dock = DockStyle.Right;
                            messageLabel.BackColor = Color.LightBlue; // Добавить фон для выделения сообщений пользователя
                            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                            flowLayoutPanel2.Controls.Add(messageLabel);
                        }
                        else
                        {
                            // Если сообщение отправлено получателем (Reciver), выравниваем его влево
                            messageLabel.Width = flowLayoutPanel2.Width;
                            messageLabel.TextAlign = ContentAlignment.MiddleLeft;
                            messageLabel.Dock = DockStyle.Left;
                            messageLabel.BackColor = Color.LightGray; // Добавить фон для сообщений получателя
                            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                            flowLayoutPanel2.Controls.Add(messageLabel);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SentMessegeHelp(string Sen, string Reci)
        {
            try
            {
                string Temka = textBox4.Text;
                var (senderPhone, recipientPhone) = (Sen, Reci);
                // Insert chat message
                string insertChatQuery = "INSERT INTO Обращение_В_Поддержку (Текст, Отправитель, Получатель, Тема) VALUES (@Text, @Sender, @Recipient, @Temka)";
                OleDbCommand insertCommand = new OleDbCommand(insertChatQuery, MyConnection);
                insertCommand.Parameters.AddWithValue("@Text", richTextBox1.Text);
                insertCommand.Parameters.AddWithValue("@Sender", senderPhone);
                insertCommand.Parameters.AddWithValue("@Recipient", recipientPhone);
                insertCommand.Parameters.AddWithValue("@Temka", Temka);
                int rowsAffected = insertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Message sent successfully.");
                }
                else
                {
                    MessageBox.Show("Message could not be sent.");
                }

                flowLayoutPanel2.Controls.Clear();
                PrintMessegeThisTopic(senderPhone, recipientPhone);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
        private OleDbCommand FindTema()
        {
            string Tem = textBox4.Text;
            string qwert = $"Select Отправитель From Обращение_В_Поддержку WHERE Тема = '{Tem}'";
            OleDbCommand command = new OleDbCommand(qwert, MyConnection);
            return command;
        }
        private void Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormController.Instance.Pop();
        }
        private void SendEmail_Click(object sender, EventArgs e)
        {
            if ((Role == 3) && (textBox4.Text != ""))
            {
                SentMessegeHelp(User, "12");
                richTextBox1.Clear();
            }
                
            else if (textBox4.Text != "")
            {
                SentMessegeHelp("12", FindTema().ExecuteScalar().ToString());
                richTextBox1.Clear();
            }
            else
            {
                MessageBox.Show($"Заполните все строки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateQuestion_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            richTextBox1.Visible = true;
            flowLayoutPanel2.Controls.Clear();
            I = 3;
            CreateQuestion.Visible = false;
            SeeAllQueshns.Visible = false;
            OpenChat.Visible = false;
            BackButton.Visible = true;
            SendEmail.Visible = true;

        }
        private void OpenChat_Click(object sender, EventArgs e)
        {
            I = 2;
            OpenChat.Visible = false;
            flowLayoutPanel2.Controls.Clear();
            PrintMessegeThisTopic("12", FindTema().ExecuteScalar().ToString());
            SendEmail.Visible = true;

        }
        private void SeeAllQueshns_Click(object sender, EventArgs e)
        {
            I = 1;
            BackButton.Visible = true;
            SeeAllQueshns.Visible = false;
            textBox4.Visible = true;
            richTextBox1.Visible = true;
            CreateQuestion.Visible = false;
            LoadNamesTopics();
            SendEmail.Visible = true;

        }
        private OleDbDataReader LoadNamesTopicsBlamerNotBlamer()
        {
            OleDbCommand command = null;
            switch (Role)
            {
                case 1:
                    string query = $"SELECT Тема FROM Обращение_В_Поддержку Group by Тема";
                    command = new OleDbCommand(query, MyConnection);
                    return command.ExecuteReader();
                case 2:
                    string query2 = $"SELECT Тема FROM Обращение_В_Поддержку Group by Тема";
                    command = new OleDbCommand(query2, MyConnection);
                    return command.ExecuteReader();
                case 3:
                    string query3 = $"SELECT Тема FROM Обращение_В_Поддержку WHERE Отправитель = '{User}' Group by Тема";
                    command = new OleDbCommand(query3, MyConnection);
                    return command.ExecuteReader();
                default:
                    return null;
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            switch(I)
            {
                case 1:
                    ResetCommonControls();
                    SeeAllQueshns.Visible=true;
                    BackButton.Visible = true;
                    BackButton.Visible = false;
                    CreateQuestion.Visible = true;
                    return;
                case 3:
                    ResetCommonControls();
                    SeeAllQueshns.Visible = true;
                    BackButton.Visible = false;
                    CreateQuestion.Visible = true;
                    OpenChat.Visible = true;
                    return;
                case 2:
                    ResetCommonControls();
                    BackButton.Visible = false;
                    SeeAllQueshns.Visible = true;
                    CreateQuestion.Visible = true;
                    OpenChat.Visible = true;
                    richTextBox1.Clear();
                    textBox4.Clear();
                    return;
            }
        }
        private void ResetCommonControls()
        {
            textBox4.Visible = false;
            richTextBox1.Visible = false;
            flowLayoutPanel2.Controls.Clear();
            SendEmail.Visible = false;
        }
    }
}
