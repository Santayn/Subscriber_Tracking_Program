using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Курсовая_ТРПО
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=18.mdb";
        private OleDbConnection myConnection;
        public int Count = 0;
        public Form1()
        {
            InitializeComponent();
            FormController.Instance.PushAndHide(this);
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();  
            textBox3.Visible = false;
            label4.Visible = false;
        }     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string Read()
        {
            Hashing hashing = new Hashing();
            // Получение текста из текстового поля
            string Passvord = textBox2.Text;
            // Вызов метода хэширования
            string Hash = hashing.HashString(Passvord);
            return Hash;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
        }
        public int FindUser(string login, string password)
        {
            try
            {
                // Передача строки подключения в OleDbConnection
                using (OleDbConnection connection = new OleDbConnection(connectString))
                {
                    connection.Open();

                    // SQL-запрос для поиска пользователя
                    string query = "SELECT COUNT(*) FROM Blamer WHERE Логин = ? AND Пароль = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Параметры запроса добавляются в порядке их использования
                        command.Parameters.AddWithValue("?", login);
                        command.Parameters.AddWithValue("?", password);
                        // Выполнение запроса
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        // Если пользователь найден, возвращаем true
                        return userCount;
                    }
                }
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке (или пишем в лог)
                MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return 0;
            }
        }
        private void Open_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = Read(); // Предположительно, метод Read() возвращает пароль.
            
            // Проверяем пользователя
            try
            {
                if (FindUser(login, password) == 1)
                {
                    // Передаём логин в форму Many
                    Many form2 = new Many(login);
                    FormController.Instance.PushAndHide(form2); // Используем существующую форму
                }
                else
                {
                    MessageBox.Show("Данные отсутствуют или введены некорректно",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Все поля должны быть заполнены",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void Registration_Click(object sender, EventArgs e)
        {
            Count++;
            try
            {
                
                if (Count > 1)
                {
                    string password = Read();
                    string login = textBox1.Text;
                    string phone = textBox3.Text;
                    if (FindUser(login, Read() ) == 0)
                    {
                        string query = $"INSERT INTO Blamer (Логин, Пароль, Телефон) VALUES ('{login}', '{password}', '{phone}')";
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Регистрация успешна: ",
                            "Уведомление",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Вы уже зарегистрированы, пожалуйста войдите: ",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    label4.Visible = false;
                    textBox3.Visible = false;
                    Count = 0;
                }
                if (Count == 1)
                {
                    label4.Visible = true;
                    textBox3.Visible = true;
                }
            }
            catch 
            {
                MessageBox.Show("Все поля должны быть заполнены",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}