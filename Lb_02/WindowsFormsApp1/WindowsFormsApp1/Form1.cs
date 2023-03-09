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



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Adress item = new Adress();
        bool infoIsGot = false;
        private void button1_Click(object sender, EventArgs e)
        {          
            
            if (textBox1.Text == "")
            {
                label8.Text = "required field";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            if (textBox2.Text == "")
            {
                label9.Text = "required field";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            if (textBox3.Text == "")
            {
                label10.Text = "required field";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            if (textBox4.Text == "")
            {
                label11.Text = "required field";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                item.setValues(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                infoIsGot = true;

                try
                {             
                  File.WriteAllText("userPostalAdress.txt", item.getInfo());                    
                }
                catch(IOException exp)
                {
                    Console.WriteLine("error: " + exp.Message);
                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            if (infoIsGot)
            {
                label7.Text = item.getInfo();                
            }
            else
            {
                label7.Text = "";
            }
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 15;
            textBox2.MaxLength = 15;
            textBox3.MaxLength = 15;
            textBox4.MaxLength = 20;
            textBox5.MaxLength = 5;
            textBox6.MaxLength = 5;

            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {                
                return;
            }
            if(e.KeyChar == '/')
            {
                return;
            }            
           
            if (Char.IsControl(e.KeyChar))
            {                
                if (e.KeyChar == (char)Keys.Enter)                    
                    textBox5.Focus();
                return;
            }            
            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {              
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    textBox5.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox1.Text == ""))
                {
                    item.setValueUsername(textBox1.Text);
                    textBox1.Text = "";
                    label8.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label8.Text = "required field";

                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox2.Text == ""))
                {
                    item.setValueContry(textBox2.Text);
                    textBox2.Text = "";
                    label9.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label9.Text = "required field";

                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox3.Text == ""))
                {
                    item.setValueCity(textBox3.Text);
                    textBox3.Text = "";
                    label10.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label10.Text = "required field";
                    textBox3.Text = "";
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox4.Text == ""))
                {
                    item.setValueStreet(textBox4.Text);
                    textBox4.Text = "";
                    label11.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label11.Text = "required field";

                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox5.Text == ""))
                {
                    item.setValueHouse(textBox5.Text);
                    textBox5.Text = "";
                    label12.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label12.Text = "required field";

                }
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!infoIsGot)
            {
                label7.Text = "Enter post adress at first!";
            }
            else
            {
                if (!(textBox6.Text == ""))
                {
                    item.setValueRoom(textBox6.Text);
                    textBox6.Text = "";
                    label13.Text = "";
                    File.WriteAllText("userPostalAdress.txt", item.getInfo());
                }
                else
                {
                    label13.Text = "required field";

                }
            }
            
        }        
    }
}
