using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp90
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string host = hostTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // TODO: Перевірити правильність введення, якщо необхідно

            string settingsFilePath = "settings.txt";

            // Зберегти налаштування у текстовий файл
            using (StreamWriter writer = new StreamWriter(settingsFilePath))
            {
                writer.WriteLine(host);
                writer.WriteLine(username);
                writer.WriteLine(password);
            }

            MessageBox.Show("Налаштування збережено.");

            DialogResult = DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
