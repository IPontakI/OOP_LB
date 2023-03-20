using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            comboBox1.SelectedItem = "+";
            comboBox2.SelectedItem = "Integer";            
        }

        
        Integer integer = new Integer();
        Real real = new Real();

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                label3.Text = "You didn't enter any value!";
            }
            else
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        {
                            integer.setNumA(Convert.ToInt32(textBox1.Text));
                            integer.setNumB(Convert.ToInt32(textBox2.Text));
                            switch (comboBox1.SelectedIndex)
                            {
                                case -1:
                                    {
                                        label3.Text = "Answer = " + "Nothing choosed!";
                                        break;
                                    }
                                case 0:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(integer.Add());
                                        break;
                                    }
                                case 1:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(integer.subtraction());
                                        break;
                                    }
                                case 2:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(integer.multiplication());
                                        break;
                                    }
                                case 3:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(integer.division());
                                        break;
                                    }

                            }

                            break;
                        }
                    case 1:
                        {
                            real.setNumA(Convert.ToDouble(textBox1.Text));
                            real.setNumB(Convert.ToDouble(textBox2.Text));
                            switch (comboBox1.SelectedIndex)
                            {
                                case -1:
                                    {
                                        label3.Text = "Answer = " + "Nothing choosed!";
                                        break;
                                    }
                                case 0:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(real.Add());
                                        break;
                                    }
                                case 1:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(real.subtraction());
                                        break;
                                    }
                                case 2:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(real.multiplication());
                                        break;
                                    }
                                case 3:
                                    {
                                        label3.Text = "Answer = " + Convert.ToString(real.division());
                                        break;
                                    }

                            }

                            break;
                        }

                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {

                    if (e.KeyChar == (char)Keys.Enter)
                        button1.Focus();
                    return;
                }
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                if (e.KeyChar == '.')
                {

                    e.KeyChar = ',';
                }
                if (e.KeyChar == ',')
                {
                    if (textBox1.Text.IndexOf(',') != -1)
                    {

                        e.Handled = true;
                    }
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {

                    if (e.KeyChar == (char)Keys.Enter)
                        button1.Focus();
                    return;
                }
                e.Handled = true;
            }            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {

                    if (e.KeyChar == (char)Keys.Enter)
                        button1.Focus();
                    return;
                }
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                if (e.KeyChar == '.')
                {

                    e.KeyChar = ',';
                }
                if (e.KeyChar == ',')
                {
                    if (textBox2.Text.IndexOf(',') != -1)
                    {

                        e.Handled = true;
                    }
                    return;
                }
                if (Char.IsControl(e.KeyChar))
                {

                    if (e.KeyChar == (char)Keys.Enter)
                        button1.Focus();
                    return;
                }
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "";

            if (comboBox2.SelectedIndex == 0)
            {
                textBox1.MaxLength = 5;
                textBox2.MaxLength = 5;
                //textBox1.Enabled = true;                
            }
            else
            {
                textBox1.MaxLength = 8;
                textBox2.MaxLength = 8;
                //textBox1.Enabled = false;                
            }
        }
    }
}
