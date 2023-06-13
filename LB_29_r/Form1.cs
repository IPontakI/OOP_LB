using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lr29
{
    public partial class Form1 : Form
    {

        bool alive = false; // чи буде працювати потік для приймання
        UdpClient client;
        const int LOCALPORT = 8001; // порт для приймання повідомлень
        const int REMOTEPORT = 8001; // порт для передавання повідомлень
        const int TTL = 20;
        IPAddress groupAddress; // адреса для групового розсилання
        string userName; // ім’я користувача в чаті

        // Нові змінні для налаштування чату
        string chatLogPath; // шлях до файлу логу чату
        private IPEndPoint HOST;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true; // кнопка входу
            button3.Enabled = false; // кнопка виходу
            button2.Enabled = false; // кнопка отправки
            chatTextBox.ReadOnly = true; // поле для повідомлень


            chatLogPath = "chatlog.txt"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                // підєднання до групового розсилання
                client.JoinMulticastGroup(groupAddress, TTL);

                // Задача на приймання повідомлень
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // Перше повідомлення про вхід нового користувача
                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, new IPEndPoint(groupAddress, REMOTEPORT));
                button1.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // Добавляємо отримане повідомлення в текстове поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                        // Записуємо лог чату у файл
                        WriteChatLog(time, message);
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, new IPEndPoint(groupAddress, REMOTEPORT));
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExitChat();
        }
        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, new IPEndPoint(groupAddress, REMOTEPORT));
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            button1.Enabled = true;
            button3.Enabled = false;
            button2.Enabled = false;
        }

        // Обробник события закриття форми
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        // Запис логу чату у файл
        private void WriteChatLog(string time, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(chatLogPath, true))
                {
                    writer.WriteLine(time + " " + message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при записі логу чату: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
             ChatSettingsForm settingsForm = new ChatSettingsForm();
            settingsForm.ChatLogPath = chatLogPath;

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // Оновити налаштування чату
                chatLogPath = settingsForm.ChatLogPath;
            }
        }
    }
}
