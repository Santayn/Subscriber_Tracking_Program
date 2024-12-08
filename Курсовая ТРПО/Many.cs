using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Курсовая_ТРПО
{
    public partial class Many : Form
    {
        public static string MyyConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=18.mdb";
        private string User;
        private int Role;
        private OleDbConnection MyConnection;
        public int Role2;
        public int I=0;
        public Many(string login)
        {
            InitializeComponent();
            this.User = login;
            MyConnection = new OleDbConnection(MyyConnection);
            MyConnection.Open();
            button1.Visible = false;
            Role = ReturnRole();
            Role2 = 3;
           // UpdateUserNames();
        }
        private void Many_Load(object sender, EventArgs e)
        {
            LoadUserNames(Role2);
        }
        private void LoadUserNames(int role)
        {
            try
            {
                OleDbDataReader reader = Loading(Role2);
                if (reader == null)
                {
                    MessageBox.Show("Ошибка: загрузка данных вернула null", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0); // Получаем значение столбца "ФИО"
                        Label nameLabel = new Label
                        {
                            Text = name,
                            AutoSize = true,
                            Margin = new Padding(5),
                            Font = new Font("Arial", 14, FontStyle.Regular)
                        };
                        flowLayoutPanel1.Controls.Add(nameLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserNames(string filters = "")    //tyta
        {
            if (Role2 < 3)
            {
                string query = "SELECT Логин FROM Blamer ";
                if (!string.IsNullOrWhiteSpace(filters))
                    query += $" WHERE Логин LIKE '%{filters}%'";
                OleDbCommand command = new OleDbCommand(query, MyConnection);
                flowLayoutPanel1.Controls.Clear();
                using (OleDbDataReader reader = command.ExecuteReader())
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
                        flowLayoutPanel1.Controls.Add(nameLabel);
                    }
                }
            }
            else
            {
                string query = $"SELECT ФИО FROM Абонент WHERE Пользователь = '{User}'";
                if (!string.IsNullOrWhiteSpace(filters))
                    query += $" And ФИО LIKE '%{filters}%'";
                OleDbCommand command = new OleDbCommand(query, MyConnection);
                flowLayoutPanel1.Controls.Clear();
                using (OleDbDataReader reader = command.ExecuteReader())
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
                        flowLayoutPanel1.Controls.Add(nameLabel);
                    }
                }

            }
        }

        private void AddAbonent_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string Name = textBox1.Text;
            string query = $"INSERT INTO Абонент (Пользователь, ФИО, ДатаРегистрации) VALUES ('{User}','{Name}','{now}')";
            try
            {
                OleDbCommand command = new OleDbCommand(query, MyConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Регистрация успешна", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Обновляем список имен
                flowLayoutPanel1.Controls.Clear();
                LoadUserNames(Role2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WorkWith_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            if (Name != "")
            {
                if (Role2 == 3)
                {
                    string query = $"SELECT Код FROM Абонент WHERE Пользователь = '{User}' AND ФИО = '{Name}'";
                    Next_Form(Name, query);
                }
                else
                {
                    string query = $"SELECT Код FROM Blamer WHERE Логин = '{Name}'";
                    Next_Form(Name, query);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста перепроверьте введённые данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Next_Form(string Name, string query)
        {
            OleDbCommand command = new OleDbCommand(query, MyConnection);

            // Выполняем запрос и проверяем результат
            object result = command.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Результат запроса не найден. Убедитесь, что данные введены корректно.",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем результат в число
            int ID = Convert.ToInt32(result);

            // Переходим к следующей форме
            МенюВзаимодействия form3 = new МенюВзаимодействия(User, ID, Role2, Name);
            FormController.Instance.PushAndHide(form3);
        }

        private void Many_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormController.Instance.Pop();
        }
        public int ReturnRole()
        {
            string query = $"SELECT Роль FROM Blamer WHERE Логин = '{User}'";
            OleDbCommand command = new OleDbCommand(query, MyConnection);
            int Role = Convert.ToInt32(command.ExecuteScalar());
            if (Role < 3)
                button1.Visible = true;
            return Role;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            I++;
            if(I ==1)
            {
                Role2 = Role;
                button1.Text = ("Перейти в режим Пользователя");
            }
            else 
            {
                Role2 = 3;
                I = 0;
                button1.Text = ("Перейти в режим админа");
            }
            flowLayoutPanel1.Controls.Clear();
            LoadUserNames(Role2);
        }
        public OleDbDataReader Loading(int role) 
        {
            OleDbCommand command = null;
            switch (role)
            { 
                case 1:
                    string query = $"SELECT Логин FROM Blamer WHERE Роль <> '{role}'";
                    command = new OleDbCommand(query, MyConnection);
                    return command.ExecuteReader();
                case 2:
                    string query2 = $"SELECT Логин FROM Blamer WHERE Роль <> '{role}'";
                    command = new OleDbCommand(query2, MyConnection);
                    return command.ExecuteReader();
                case 3:
                    string query3 = $"SELECT ФИО FROM Абонент WHERE Пользователь = '{User}'";
                    command = new OleDbCommand(query3, MyConnection);
                    return command.ExecuteReader();
                default:
                    return null;
            }
        }

        private void поддержкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help(User, Role2) ;
            FormController.Instance.PushAndHide(help);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string TEX = textBox1.Text;
            UpdateUserNames(TEX);
            timer1.Stop();
        }
    }
}