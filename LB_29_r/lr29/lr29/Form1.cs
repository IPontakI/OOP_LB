using System;
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
        bool alive = false;

        
        const int LOCALPORT = 8002; // порт для приймання повідомлень
        const int REMOTEPORT = 8002; // порт для передавання повідомлень
        const int TTL = 20;

        string userName; // ім’я користувача в чаті
        string chatLogPath; // шлях до файлу логу чату

        UdpClient client;
        IPAddress groupAddress; // адреса для групового розсилання
        private IPEndPoint HOST;        

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true; 
            button3.Enabled = false;  
            button2.Enabled = false; 
            richTextBox1.ReadOnly = true;

            chatLogPath = "chatlogSaver.txt"; 
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
                string message = userName + " entered chat!";
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
                        richTextBox1.Text = message + "\r\n" + richTextBox1.Text;
                        // Записуємо лог чату у файл
                        WriteChatLog(message);
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
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        // Запис логу чату у файл
        private void WriteChatLog(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(chatLogPath, true))
                {
                    writer.WriteLine(message);
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

        private void button5_Click(object sender, EventArgs e)
        {
            userNameTextBox.ReadOnly = false;
        }
    }
}
