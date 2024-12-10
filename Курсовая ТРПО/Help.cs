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
        private void LoadNamesTopics()
        {
            try
            {
                SQL sQL = new SQL();
                Chatic chatic = new Chatic();
                flowLayoutPanel2.Controls.Clear();
                using (OleDbDataReader reader = sQL.LoadNamesTopicsBlamerNotBlamer(Role, User)) 
                {
                    chatic.loadNamesTopics(reader, flowLayoutPanel2);
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
                SQL sQL = new SQL();
                Chatic chatic = new Chatic();
                string Tem = textBox4.Text;
                flowLayoutPanel2.Visible = true;
                using (OleDbDataReader reader = sQL.PrintMessegeThisTopic(Sender, Reciver, Tem).ExecuteReader())
                {
                    chatic.printMessegeThisTopic(reader, Sender, flowLayoutPanel2);
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
                SQL sQL = new SQL();
                string Temka = textBox4.Text;
                var (senderPhone, recipientPhone) = (Sen, Reci);
                int rowsAffected = sQL.sentMessegeHelp(richTextBox1.Text, senderPhone, recipientPhone, Temka).ExecuteNonQuery();
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
            SQL sql = new SQL();
            string Tem = textBox4.Text;
            return sql.FindTema(Tem);
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
