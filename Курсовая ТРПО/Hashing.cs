using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_ТРПО
{
    internal class Hashing
    {

        public string HashString(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentException("Входная строка не должна быть пустой или null.", nameof(input));
                }

                using (SHA256 sha256 = SHA256.Create())
                {
                    // Преобразуем строку в байты
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                    // Вычисляем хэш
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);

                    // Преобразуем хэш-байты в строку в шестнадцатеричном формате
                    StringBuilder hashStringBuilder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hashStringBuilder.Append(b.ToString("x2"));
                    }

                    return hashStringBuilder.ToString();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Укажите пароль: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
