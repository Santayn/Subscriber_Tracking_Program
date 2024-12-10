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
        private int iD;
        private string login;
        private int Role;
        public int I;
        public string NameBlamer;
        public string FIO;

        public МенюВзаимодействия(string login, int ID, int Role, string NameBlamer, string FIO)
        {
            InitializeComponent();
            this.iD = ID;
            this.login = login;
            this.Role = Role;
            this.FIO = FIO;
            this.NameBlamer = NameBlamer;
            CheckRole();
            richTextBox2.Visible = false;
            BackButton.Visible = false;
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            SQL sQL = new SQL();
            sQL.Delete(Role,iD,login,NameBlamer);
            Close();  
        }
        private void МенюВзаимодействия_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormController.Instance.Pop();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SQL sQL = new SQL();
            string PhoneNumber = textBox2.Text;
            string InfoAboutStatus = textBox4.Text;
            string[] lines = richTextBox1.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            string Texti = lines.Length > 2
                ? string.Join(Environment.NewLine, lines.Skip(2))
                : string.Empty;
            sQL.Save(PhoneNumber, Texti, sQL.IDAbonent(login, FIO), InfoAboutStatus);
            richTextBox1.Clear();
            ICanSee (false);
        }
        private void Info_Click(object sender, EventArgs e)
        {
            try
            {
                SQL sQL = new SQL();
                OleDbCommand command = sQL.Info(Role, sQL.IDAbonent(login, FIO), NameBlamer);
                if (Role == 3)
                {
                    ICanSee(true);
                    textBox4.Visible = false;
                    label3.Visible = false;
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
                SQL sQL = new SQL();
                int rowsAffected = sQL.button5_Click(richTextBox2.Text, senderPhone, recipientPhone).ExecuteNonQuery();
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
            SQL sQL = new SQL();
            // Retrieve sender's phone number
            object senderPhoneResult = sQL.loadUserNamesHelp(login, iD,Role,1).ExecuteScalar();
            if (senderPhoneResult == null)
            {
                MessageBox.Show("Sender phone number not found.");
            }
            string senderPhone = senderPhoneResult.ToString();
            if (Role !=3)
            {
                object recipientPhoneResult = sQL.loadUserNamesHelp(login, iD, Role, 2).ExecuteScalar();
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
                object recipientPhoneResult = sQL.loadUserNamesHelp(login, sQL.IDAbonent(login, FIO), Role, 3).ExecuteScalar();
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
                SQL sQL = new SQL();
                Chatic chatic = new Chatic();
                using (OleDbDataReader reader = sQL.LoadUserNames(Sender, Reciver).ExecuteReader())
                {
                     chatic.printMessegeThisTopic(reader, Sender, flowLayoutPanel2);
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
            flowLayoutPanel2.Controls.Clear();
        }
    }
}
