using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Thread thread1;
        Thread thread2;
        Thread thread3;

        string input;

        public Form1()
        {
            InitializeComponent();
            thread1 = new Thread(new ThreadStart(fu));
            thread2 = new Thread(new ThreadStart(fu2));
            thread3 = new Thread(new ThreadStart(fu3));
        }

        public void fu() 
        {
            Encrypt(plaintext, key, encryptedText);                
        }

        string hashedValue;

        public void fu2()
        {
            hashedValue = ComputeHash(input, 8);
        }

        byte[] encryptedData;

        public void fu3()
        {
            var rsa = new RSACryptoServiceProvider();
            var publicKey = rsa.ExportParameters(false);
            encryptedData = Encrypt2(Encoding.UTF8.GetBytes(textBox3.Text), publicKey);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            button3.Enabled = false;
            button4.Enabled = false;

            button5.Enabled = false;
            button6.Enabled = false;

            button7.Enabled = false;
            button8.Enabled = false;

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private static int[] sBox = new int[8] { 5, 2, 1, 6, 3, 4, 7, 0 };

        public static void Encrypt(string plaintext, string key, string encryptedText)
        {
            // Перевірка валідності ключа та тексту
            if (string.IsNullOrEmpty(plaintext) || string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Пустий текст або ключ.");
            }

            // Доповнення ключа
            if (key.Length < 8)
            {
                key = key.PadRight(8, '0');
            }
            else if (key.Length > 8)
            {
                key = key.Substring(0, 8);
            }

            // Шифрування
            int[] block = new int[8];
            string ciphertext = string.Empty;

            for (int i = 0; i < plaintext.Length; i += 8)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i + j < plaintext.Length)
                    {
                        block[j] = (int)plaintext[i + j];
                    }
                    else
                    {
                        block[j] = 0; // Доповнення нулями
                    }
                }

                int[] roundKey = GenerateRoundKey(key);
                for (int round = 0; round < 16; round++)
                {
                    block = RoundFunction(block, roundKey);
                    roundKey = GenerateRoundKey(roundKey.ToString());
                }

                for (int j = 0; j < 8; j++)
                {
                    ciphertext += (char)block[j];
                }
            }
            encryptedText = ciphertext;

            //return ciphertext;
        }

        private static int[] GenerateRoundKey(string key)
        {
            int[] roundKey = new int[8];
            for (int i = 0; i < 8; i++)
            {
                roundKey[i] = (int)key[i];
            }

            // Логічне сумування з ключем
            roundKey[0] ^= 1;
            roundKey[1] ^= 2;
            roundKey[2] ^= 4;
            roundKey[3] ^= 8;
            roundKey[4] ^= 16;
            roundKey[5] ^= 32;
            roundKey[6] ^= 64;
            roundKey[7] ^= 128;

            return roundKey;
        }

        private static int[] RoundFunction(int[] block, int[] roundKey)
        {
            // Логічне сумування з ключем
            for (int i = 0; i < 8; i++)
            {
                block[i] ^= roundKey[i];
            }           
            
            // Застосування S-блоку
            for (int i = 0; i < 8; i++)
            {
               //block[i] = sBox[block[i]-1];
            }

            // Зсув ліворуч
            int temp = block[0];
            for (int i = 0; i < 7; i++)
            {
                block[i] = block[i + 1];
            }
            block[7] = temp;

            return block;
        }
        string plaintext = "Hello, world!";
        string key = "mysecret";
        string encryptedText;
        private void button1_Click(object sender, EventArgs e)
        {
            //thread1.Start();
            Encrypt(plaintext, key, encryptedText);
            label1.Text = encryptedText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
        }
        public static string ComputeHash(string input, int n)
        {
            using (var algorithm = SHA256.Create()) // Використовуйте вибраний алгоритм хешування
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = algorithm.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2")); // Представлення хешу в шістнадцятковому форматі
                }

                return stringBuilder.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //thread2.Start();
            hashedValue = ComputeHash(input, 8);
            input = textBox2.Text;            
            label2.Text = hashedValue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thread2.Suspend();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
                button2.Enabled = false;

                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    button7.Enabled = true;
                    button8.Enabled = true;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                button3.Enabled = false;
                button4.Enabled = false;

                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    button7.Enabled = true;
                    button8.Enabled = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                button5.Enabled = false;
                button6.Enabled = false;

                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
                button6.Enabled = true;

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    button7.Enabled = true;
                    button8.Enabled = true;
                }
            }           
        }

        public static byte[] Encrypt2(byte[] data, RSAParameters publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(data, true);
            }
        }        

        private void button5_Click(object sender, EventArgs e)
        {
            //thread3.Start();
            var rsa = new RSACryptoServiceProvider();
            var publicKey = rsa.ExportParameters(false);
            encryptedData = Encrypt2(Encoding.UTF8.GetBytes(textBox3.Text), publicKey);

            label3.Text = Convert.ToBase64String(encryptedData);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            thread3.Suspend();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
            thread2.Suspend();
            thread3.Suspend();
        }
    }
}
