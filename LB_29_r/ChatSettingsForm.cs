using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr29
{
    public partial class ChatSettingsForm : Form
    {
        public ChatSettingsForm()
        {
            InitializeComponent();
        }
        public string ChatLogPath { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            chatLogPathTextBox.Text = ChatLogPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChatLogPath = chatLogPathTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
