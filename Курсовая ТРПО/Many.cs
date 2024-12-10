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
        private string User;
        private int Role;
        public int Role2;
        public int I=0;
        public Many(string login)
        {
            InitializeComponent();
            this.User = login;
            button1.Visible = false;
            Role = ReturnRole();
            Role2 = 3;
        }
        private void Many_Load(object sender, EventArgs e)
        {
            LoadUserNames(Role2);
        }
        private void LoadUserNames(int role)
        {
            try
            {
                SQL sQL = new SQL();
                OleDbDataReader reader = sQL.Loading(Role2, User);
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
        private void UpdateUserNames(string filters = "")
        {
            SQL sQL = new SQL();
            if (Role2 < 3)
            {               
                flowLayoutPanel1.Controls.Clear();
                using (OleDbDataReader reader = sQL.updateUserNames(Role2, filters).ExecuteReader())
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
                OleDbCommand command = sQL.updateUserNames(User, filters);
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
            try
            {
                string Name = textBox1.Text;
                SQL sQL = new SQL();
                OleDbCommand command = sQL.AddAbonent(User, Name);
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
                SQL sQL = new SQL();
                if (Role2 == 3)
                {
                    Next_Form(Name, sQL.workWith(Role,Name,User));
                }
                else
                {
                    Next_Form(Name, sQL.workWith(Role, Name, User));
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста перепроверьте введённые данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Next_Form(string Name, string query)
        {
            SQL sQL = new SQL();
            object result = sQL.Next_Form(query);
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
            string FIO = textBox1.Text;
            // Переходим к следующей форме
            МенюВзаимодействия form3 = new МенюВзаимодействия(User, ID, Role2, Name, FIO);
            FormController.Instance.PushAndHide(form3);
        }
        private void Many_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormController.Instance.Pop();
        }
        public int ReturnRole()
        {
            SQL sQL = new SQL();
            int Role = Convert.ToInt32(sQL.ReturnRole(User).ExecuteScalar());
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