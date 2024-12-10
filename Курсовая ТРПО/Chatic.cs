using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_ТРПО
{
    internal class Chatic
    {
        public void printMessegeThisTopic(OleDbDataReader reader, string Sender, FlowLayoutPanel flowLayoutPanel2)
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
        public void loadNamesTopics(OleDbDataReader reader, FlowLayoutPanel flowLayoutPanel2)
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
                    Font = new Font("Arial", 20, FontStyle.Regular)
                };
                // Добавляем метку в контейнер (например, FlowLayoutPanel)
                nameLabel.BackColor = Color.LightBlue; // Добавить фон для выделения сообщений пользователя
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel2.Controls.Add(nameLabel);
            }
        }
    }
}
