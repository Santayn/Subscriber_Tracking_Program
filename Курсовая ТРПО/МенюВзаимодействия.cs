using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
namespace Курсовая_ТРПО
{
    public partial class МенюВзаимодействия : Form
    {
        public static string MyyConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=18.mdb";
        private int iD;
        private string login;
        private int Role;
        public int I;
        public string NameBlamer;
        private OleDbConnection MyConnection;
        public МенюВзаимодействия(string login, int ID, int Role, string NameBlamer)
        {
            InitializeComponent();
            this.iD = ID;
            this.login = login;
            this.Role = Role;
            this.NameBlamer = NameBlamer;
            MyConnection = new OleDbConnection(MyyConnection);
            MyConnection.Open();
            CheckRole();
            richTextBox2.Visible = false;
            BackButton.Visible = false;
        }
        private void МенюВзаимодействия_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if  (Role == 3)
            {
                string query1 = $"SELECT Телефон From Абонент WHERE Код = {iD}";
                string query2 = $"SELECT Телефон From Blamer WHERE Логин = '{login}'";
                OleDbCommand command1 = new OleDbCommand(query1, MyConnection);
                OleDbCommand command2 = new OleDbCommand(query2, MyConnection);
                string phoneS = command1.ExecuteScalar().ToString();
                string phoneR = command2.ExecuteScalar().ToString();
                string query = $"DELETE * FROM Абонент WHERE Код = {iD}";
                OleDbCommand command = new OleDbCommand(query, MyConnection);
                command.Parameters.AddWithValue("?", iD);
                command.ExecuteNonQuery();
                string query4 = $"DELETE * FROM Чат WHERE Отправитель = '{phoneS}' AND Получатель = '{phoneR}'";
                OleDbCommand command4 = new OleDbCommand(query4, MyConnection);
                command4.ExecuteNonQuery();

                Close();
            }
            else
            {
                string query3 = $"SELECT Телефон From Blamer WHERE Код = {iD}";
                OleDbCommand command3 = new OleDbCommand(query3, MyConnection);
                string BlamRole = command3.ExecuteScalar().ToString();
                if(BlamRole != "1")
                {
                    string query1 = $"SELECT Телефон From Blamer WHERE Код = {iD}";
                    OleDbCommand command1 = new OleDbCommand(query1, MyConnection);
                    string phoneS = command1.ExecuteScalar().ToString();
                    string query4 = $"DELETE  FROM Чат WHERE Отправитель = '{phoneS}' ";
                    OleDbCommand command4 = new OleDbCommand(query4, MyConnection);
                    string query = $"DELETE  FROM Абонент WHERE Пользователь = '{NameBlamer}'";
                    OleDbCommand command = new OleDbCommand(query, MyConnection);
                    command.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    string query2 = $"DELETE  FROM Blamer WHERE Логин = '{NameBlamer}'";
                    OleDbCommand command2 = new OleDbCommand(query2, MyConnection);
                    command2.ExecuteNonQuery();
                    Close();
                }
  
            }
            
        }
        private void МенюВзаимодействия_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormController.Instance.Pop();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            string PhoneNumber = textBox2.Text;
            string[] lines = richTextBox1.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string Texti = lines.Length > 2
                ? string.Join(Environment.NewLine, lines.Skip(2))
                : string.Empty;
            string query = $"UPDATE Абонент SET Телефон = '{PhoneNumber}', Примечание = '{Texti}' WHERE Код = {iD}";
            OleDbCommand command = new OleDbCommand(query, MyConnection);
            command.ExecuteNonQuery();
            MessageBox.Show($"Добавление успешно: ",
                "Уведомление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            string InfoAboutStatus = textBox4.Text;
            if (InfoAboutStatus == ("Blamer") || (InfoAboutStatus == ("3")))
            {
                string query22 = $"UPDATE Blamer SET Роль = '3',  Статус = 'Blamer' WHERE Код = {iD}";
                OleDbCommand command22 = new OleDbCommand(query22, MyConnection);
                command22.ExecuteNonQuery();
                MessageBox.Show("Обновление данных успешно");
            }
            else if (InfoAboutStatus == ("Админ") || InfoAboutStatus == ("2"))
            {
                string query22 = $"UPDATE Blamer SET Роль = '2',  Статус = 'Админ' WHERE Код = {iD}";
                OleDbCommand command22 = new OleDbCommand(query22, MyConnection);
                command22.ExecuteNonQuery();
                MessageBox.Show("Обновление данных успешно");
            }
            else
            {
                MessageBox.Show("Введены некоректные или отсутствующие данные");

            }
            richTextBox1.Clear();
            ICanSee (false);

        }
        private void Info_Click(object sender, EventArgs e)
        {
            try
            {
                if (Role == 3)
                {
                    ICanSee(true);
                    textBox4.Visible = false;
                    label3.Visible = false;
                    string query = $"SELECT  Абонент.Статус, Абонент.Примечание, Абонент.Телефон, Абонент.ДатаРегистрации FROM Абонент WHERE Код = {iD}";
                    OleDbCommand command = new OleDbCommand(query, MyConnection);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox2.Text = reader["Телефон"].ToString();
                            textBox4.Text = reader["Статус"].ToString();
                            richTextBox1.Text += "Дата регистрации\r" + reader["ДатаРегистрации"].ToString();
                            richTextBox1.Text += Environment.NewLine;
                            richTextBox1.Text += reader["Примечание"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Данные для указанного пользователя не найдены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                else
                {
                    ICanSee(true);
                    string query = $"SELECT  Blamer.Статус, Blamer.Примечание, Blamer.Телефон, Blamer.ДатаРегистрации FROM Blamer WHERE Логин = '{NameBlamer}'";
                    OleDbCommand command = new OleDbCommand(query, MyConnection);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox2.Text = reader["Телефон"].ToString();
                            textBox4.Text = reader["Статус"].ToString();
                            richTextBox1.Text += "Дата регистрации\r" + reader["ДатаРегистрации"].ToString();
                            richTextBox1.Text += Environment.NewLine;
                            richTextBox1.Text += reader["Примечание"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Данные для указанного пользователя не найдены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ICanSee(bool info)
        {
            if (info == true)
            {
                textBox2.Visible = true;
                textBox4.Visible = true;
                richTextBox1.Visible = true;
                label1.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                Save.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
                textBox4.Visible = false;
                richTextBox1.Visible = false;
                label1.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                Save.Visible = false;
            }
        }

        private void Chat_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            richTextBox2.Visible = true;
            Chat.Visible = false;
            BackButton.Visible = true;
            SendEmail.Visible = true;
            var (senderPhone, recipientPhone) = LoadUserNamesHelp();
            LoadUserNames(senderPhone, recipientPhone);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Chat.Visible = false;
                var (senderPhone, recipientPhone) = LoadUserNamesHelp();
                // Insert chat message
                string insertChatQuery = "INSERT INTO Чат (Текст, Отправитель, Получатель) VALUES (@Text, @Sender, @Recipient)";
                OleDbCommand insertCommand = new OleDbCommand(insertChatQuery, MyConnection);
                insertCommand.Parameters.AddWithValue("@Text", richTextBox2.Text);
                insertCommand.Parameters.AddWithValue("@Sender", senderPhone);
                insertCommand.Parameters.AddWithValue("@Recipient", recipientPhone);
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
                LoadUserNames(senderPhone, recipientPhone);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        public  (string, string) LoadUserNamesHelp()
        {
            // Retrieve sender's phone number
            string senderPhoneQuery = $"SELECT Телефон FROM Blamer WHERE Логин = '{login}'";
            OleDbCommand senderCommand = new OleDbCommand(senderPhoneQuery, MyConnection);

            object senderPhoneResult = senderCommand.ExecuteScalar();
            if (senderPhoneResult == null)
            {
                MessageBox.Show("Sender phone number not found.");
                
            }
            string senderPhone = senderPhoneResult.ToString();
            if (Role !=3)
            {
                string recipientPhoneQuery = $"SELECT Телефон FROM Blamer WHERE Код = {iD}";
                OleDbCommand recipientCommand = new OleDbCommand(recipientPhoneQuery, MyConnection);
                object recipientPhoneResult = recipientCommand.ExecuteScalar();
                if (recipientPhoneResult == null)
                {
                    MessageBox.Show("Recipient phone number not found.");

                }
                string recipientPhone = recipientPhoneResult.ToString();
                return (senderPhone, recipientPhone);
            }
            else
            {
                // Retrieve recipient's phone number
                string recipientPhoneQuery = $"SELECT Телефон FROM Абонент WHERE Код = {iD}";
                OleDbCommand recipientCommand = new OleDbCommand(recipientPhoneQuery, MyConnection);
                object recipientPhoneResult = recipientCommand.ExecuteScalar();
                if (recipientPhoneResult == null)
                {
                    MessageBox.Show("Recipient phone number not found.");

                }
                string recipientPhone = recipientPhoneResult.ToString();
                return (senderPhone, recipientPhone);
            }
            
        }
        private void LoadUserNames(string Sender, string Reciver)
        {
            try
            {
                flowLayoutPanel2.Visible = true;
                string query = $"SELECT Текст, Отправитель FROM Чат WHERE (Отправитель = '{Sender}' And Получатель ='{Reciver}') OR (Отправитель = '{Reciver}' And Получатель ='{Sender}') ORDER BY ВремяОтправки";

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
                            Font = new Font("Arial", 20, FontStyle.Regular)
                        };

                        // Если сообщение отправлено пользователем (Sender), выравниваем его вправо
                        if (messageSender == Sender)
                        {
                            messageLabel.TextAlign = ContentAlignment.MiddleRight;
                            messageLabel.Dock = DockStyle.Right;
                            messageLabel.BackColor = Color.LightBlue; // Добавить фон для выделения сообщений пользователя
                            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                            flowLayoutPanel2.Controls.Add(messageLabel);
                        }
                        else
                        {
                            // Если сообщение отправлено получателем (Reciver), выравниваем его влево
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

        private void CheckRole()
        {
            ICanSee(false);
            flowLayoutPanel2.Visible = true;
            SendEmail.Visible = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Chat.Visible = true;
            BackButton.Visible = false;
            richTextBox2.Visible = false;
            SendEmail.Visible = false;

        }
    }
}
