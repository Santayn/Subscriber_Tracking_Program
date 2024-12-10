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
        public int Count = 0;
        public Form1()
        {
            InitializeComponent();
            FormController.Instance.PushAndHide(this);
            textBox3.Visible = false;
            label4.Visible = false;
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
            SQL sql = new SQL();
            sql.close();
        }
        public int? FindUser(string login, string password)
        {
            try
            {
                SQL sql = new SQL();
                sql.findUser(login, password);
                return 1;
            }
            catch (Exception ex)
            {
                // Выводим сообщение об ошибке (или пишем в лог)
                MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
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
                    if (FindUser(login, Read()) == 1)
                    {
                        SQL sql = new SQL();
                        sql.Registration(login, password, phone);
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
    }
}