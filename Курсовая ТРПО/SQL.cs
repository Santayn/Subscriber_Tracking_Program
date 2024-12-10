using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовая_ТРПО
{

    internal class SQL
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=18.mdb";
        private OleDbConnection myConnection;
        public SQL()
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }
        public int findUser(string login, string password)
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
        public void Registration(string login, string password, string phone)
        {
            string query = $"INSERT INTO Blamer (Логин, Пароль, Телефон) VALUES ('{login}', '{password}', '{phone}')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show($"Регистрация успешна: ",
                "Уведомление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void close()
        {
            myConnection.Close();
        }
        public OleDbDataReader Loading(int role, string User)
        {
            OleDbCommand command = null;
            switch (role)
            {
                case 1:
                    string query = $"SELECT Логин FROM Blamer WHERE Роль <> '{role}'";
                    command = new OleDbCommand(query, myConnection);
                    return command.ExecuteReader();
                case 2:
                    string query2 = $"SELECT Логин FROM Blamer WHERE Роль >= '{role}'";
                    command = new OleDbCommand(query2, myConnection);
                    return command.ExecuteReader();
                case 3:
                    string query3 = $"SELECT ФИО FROM Абонент WHERE Пользователь = '{User}'";
                    command = new OleDbCommand(query3, myConnection);
                    return command.ExecuteReader();
                default:
                    return null;
            }
        }
        public OleDbCommand updateUserNames(string User, string filters = "")
        {

            string query = $"SELECT ФИО FROM Абонент WHERE Пользователь = '{User}'";
            if (!string.IsNullOrWhiteSpace(filters))
                query += $" And ФИО LIKE '%{filters}%'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;

        }
        public OleDbCommand updateUserNames(int Role, string filters = "")
        {

            string query = $"SELECT Логин FROM Blamer WHERE Роль >= '{Role}'";
            if (!string.IsNullOrWhiteSpace(filters))
                query += $" And Логин LIKE '%{filters}%'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;

        }
        public OleDbCommand AddAbonent(string User, string Name)
        {
            string query = $"INSERT INTO Абонент (Пользователь, ФИО) VALUES ('{User}','{Name}')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;
        }
        public string workWith(int Role, string Name, string User)
        {
            switch (Role)
            {
                case 3:
                    string query = $"SELECT Код FROM Абонент WHERE Пользователь = '{User}' AND ФИО = '{Name}'";
                    return query;
                default:
                    string query2 = $"SELECT Код FROM Blamer WHERE Логин = '{Name}'";
                    return query2;
            }
        }
        public OleDbCommand ReturnRole(string User)
        {
            string query = $"SELECT Роль FROM Blamer WHERE Логин = '{User}'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;
        }
        public object Next_Form(string query)
        {
            OleDbCommand command = new OleDbCommand(query, myConnection);
            object result = command.ExecuteScalar();
            return result;
        }
        public void Delete(int Role, int iD, string login, string NameBlamer)
        {
            switch (Role)
            {
                case 3:
                    string query1 = $"SELECT Телефон From Абонент WHERE Код = {iD}";
                    string query2 = $"SELECT Телефон From Blamer WHERE Логин = '{login}'";
                    OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                    OleDbCommand command2 = new OleDbCommand(query2, myConnection);
                    string phoneS = command1.ExecuteScalar().ToString();
                    string phoneR = command2.ExecuteScalar().ToString();
                    string query = $"DELETE * FROM Абонент WHERE Код = {iD}";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.Parameters.AddWithValue("?", iD);
                    command.ExecuteNonQuery();
                    string query4 = $"DELETE * FROM Чат WHERE Отправитель = '{phoneS}' AND Получатель = '{phoneR}'";
                    OleDbCommand command4 = new OleDbCommand(query4, myConnection);
                    command4.ExecuteNonQuery();
                    return;
                default:
                    string query3 = $"SELECT Телефон From Blamer WHERE Код = {iD}";
                    OleDbCommand command3 = new OleDbCommand(query3, myConnection);
                    string BlamRole = command3.ExecuteScalar().ToString();
                    if (BlamRole != "1")
                    {
                        string query5 = $"SELECT Телефон From Blamer WHERE Код = {iD}";
                        OleDbCommand command5 = new OleDbCommand(query5, myConnection);
                        string phoneSS = command5.ExecuteScalar().ToString();
                        string query6 = $"DELETE  FROM Чат WHERE Отправитель = '{phoneSS}' ";
                        OleDbCommand command6 = new OleDbCommand(query6, myConnection);
                        string query7 = $"DELETE  FROM Абонент WHERE Пользователь = '{NameBlamer}'";
                        OleDbCommand command7 = new OleDbCommand(query7, myConnection);
                        command7.ExecuteNonQuery();
                        command6.ExecuteNonQuery();
                        string query8 = $"DELETE  FROM Blamer WHERE Логин = '{NameBlamer}'";
                        OleDbCommand command8 = new OleDbCommand(query8, myConnection);
                        command8.ExecuteNonQuery();
                        return;
                    }
                    return;
            }
        }
        public OleDbCommand Info(int Role, int iD, string NameBlamer)
        {
            switch (Role)
            {
                case 3:
                    string query = $"SELECT  Абонент.Статус, Абонент.Примечание, Абонент.Телефон, Абонент.ДатаРегистрации FROM Абонент WHERE Код = {iD}";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    return command;
                default:
                    string query2 = $"SELECT  Blamer.Статус, Blamer.Примечание, Blamer.Телефон, Blamer.ДатаРегистрации FROM Blamer WHERE Логин = '{NameBlamer}'";
                    OleDbCommand command2 = new OleDbCommand(query2, myConnection);
                    return command2;
            }
        }
        public OleDbCommand LoadUserNames(string Sender, string Reciver)
        {
            string query = $"SELECT Текст, Отправитель FROM Чат WHERE (Отправитель = '{Sender}' And Получатель ='{Reciver}') OR (Отправитель = '{Reciver}' And Получатель ='{Sender}') ORDER BY ВремяОтправки";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;

        }
        public void Save(string PhoneNumber, string Texti, int iD, string InfoAboutStatus)
        {
            string query = $"UPDATE Абонент SET Телефон = '{PhoneNumber}', Примечание = '{Texti}' WHERE Код = {iD}";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            if (InfoAboutStatus == ("Blamer") || (InfoAboutStatus == ("3")))
            {
                string query22 = $"UPDATE Blamer SET Роль = '3',  Статус = 'Blamer' WHERE Код = {iD}";
                OleDbCommand command22 = new OleDbCommand(query22, myConnection);
                command22.ExecuteNonQuery();
                MessageBox.Show("Обновление данных успешно");
            }
            else if (InfoAboutStatus == ("Админ") || InfoAboutStatus == ("2"))
            {
                string query22 = $"UPDATE Blamer SET Роль = '2',  Статус = 'Админ' WHERE Код = {iD}";
                OleDbCommand command22 = new OleDbCommand(query22, myConnection);
                command22.ExecuteNonQuery();
                MessageBox.Show("Обновление данных успешно");
            }
            else
            {
                MessageBox.Show("Проверьте данные");
            }
        }
        public OleDbCommand loadUserNamesHelp(string login, int iD, int Role, int casee)
        {
            switch (casee)
            {
                case 1:
                    string senderPhoneQuery = $"SELECT Телефон FROM Blamer WHERE Логин = '{login}'";
                    OleDbCommand senderCommand = new OleDbCommand(senderPhoneQuery, myConnection);
                    return senderCommand;
                case 2:
                    string recipientPhoneQuery2 = $"SELECT Телефон FROM Blamer WHERE Код = {iD}";
                    OleDbCommand recipientCommand2 = new OleDbCommand(recipientPhoneQuery2, myConnection);
                    return recipientCommand2;
                case 3:
                    // Retrieve recipient's phone number
                    string recipientPhoneQuery = $"SELECT Телефон FROM Абонент WHERE Код = {iD}";
                    OleDbCommand recipientCommand = new OleDbCommand(recipientPhoneQuery, myConnection);
                    return recipientCommand;
                default:
                    return null;
            }
        }
        public OleDbCommand button5_Click(string richTextBox2, string senderPhone, string recipientPhone)
        {
            // Insert chat message
            string insertChatQuery = "INSERT INTO Чат (Текст, Отправитель, Получатель) VALUES (@Text, @Sender, @Recipient)";
            OleDbCommand insertCommand = new OleDbCommand(insertChatQuery, myConnection);
            insertCommand.Parameters.AddWithValue("@Text", richTextBox2);
            insertCommand.Parameters.AddWithValue("@Sender", senderPhone);
            insertCommand.Parameters.AddWithValue("@Recipient", recipientPhone);
            return insertCommand;
        }
        public OleDbDataReader LoadNamesTopicsBlamerNotBlamer(int Role, string User)
        {
            OleDbCommand command = null;
            switch (Role)
            {
                case 1:
                    string query = $"SELECT Тема FROM Обращение_В_Поддержку Group by Тема";
                    command = new OleDbCommand(query, myConnection);
                    return command.ExecuteReader();
                case 2:
                    string query2 = $"SELECT Тема FROM Обращение_В_Поддержку Group by Тема";
                    command = new OleDbCommand(query2, myConnection);
                    return command.ExecuteReader();
                case 3:
                    string query3 = $"SELECT Тема FROM Обращение_В_Поддержку WHERE Отправитель = '{User}' Group by Тема";
                    command = new OleDbCommand(query3, myConnection);
                    return command.ExecuteReader();
                default:
                    return null;
            }
        }
        public OleDbCommand sentMessegeHelp(string Text, string senderPhone, string recipientPhone, string Temka)
        {
            // Insert chat message
            string insertChatQuery = "INSERT INTO Обращение_В_Поддержку (Текст, Отправитель, Получатель, Тема) VALUES (@Text, @Sender, @Recipient, @Temka)";
            OleDbCommand insertCommand = new OleDbCommand(insertChatQuery, myConnection);
            insertCommand.Parameters.AddWithValue("@Text", Text);
            insertCommand.Parameters.AddWithValue("@Sender", senderPhone);
            insertCommand.Parameters.AddWithValue("@Recipient", recipientPhone);
            insertCommand.Parameters.AddWithValue("@Temka", Temka);
            return insertCommand;
        }
        public OleDbCommand FindTema(string Text)
        {
            string qwert = $"Select Отправитель From Обращение_В_Поддержку WHERE Тема = '{Text}'";
            OleDbCommand command = new OleDbCommand(qwert, myConnection);
            return command;
        }
        public OleDbCommand PrintMessegeThisTopic(string Sender, string Reciver, string Tem)
        {
            string query = $"SELECT Текст, Отправитель FROM Обращение_В_Поддержку WHERE ((Отправитель = '{Sender}' And Получатель ='{Reciver}') OR (Отправитель = '{Reciver}' And Получатель ='{Sender}')) AND Тема ='{Tem}' ORDER BY ВремяОтправки";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command;
        }
        public int IDAbonent(string NameBlamer, string FIO)
        {
            string query = $"SELECT Код FROM Абонент WHERE Пользователь ='{NameBlamer}' And ФИО ='{FIO}'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            int Command =Convert.ToInt32(command.ExecuteScalar());
            return Command;

        }
    }
}
