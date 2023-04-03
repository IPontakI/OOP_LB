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
            lblAnswer.Text = "Answer: ";
            comboBox1.SelectedIndex = 0;

            tbGetA.MaxLength = 5;            
            tbGetB.MaxLength = 5;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double answer;
            double a;
            double b;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        try
                        {
                            a = Convert.ToDouble(tbGetA.Text);
                            b = Convert.ToDouble(tbGetB.Text);
                            answer = b - a;
                            lblAnswer.Text = "Answer: X = " + answer.ToString();
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Exception message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        break;
                    }
                case 1:
                    {
                        try
                        {
                            a = Convert.ToDouble(tbGetA.Text);
                            b = Convert.ToDouble(tbGetB.Text);
                            answer = -(b - a);
                            lblAnswer.Text = "Answer: X = " + answer.ToString();
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Exception message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        break;
                    }
                case 2:
                    {                        
                        try
                        {
                            a = Convert.ToDouble(tbGetA.Text);
                            b = Convert.ToDouble(tbGetB.Text);
                            answer = b / a;
                            lblAnswer.Text = "Answer: X = " + answer.ToString();
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Exception message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        break;
                    }
                case 3:
                    {
                        try
                        {
                            a = Convert.ToDouble(tbGetA.Text);
                            b = Convert.ToDouble(tbGetB.Text);
                            if(a == 0)
                            {
                                throw new Exception("Ви намагаєтеся виконати ділення на нуль.");
                            }
                            if (b == 0)
                            {
                                throw new Exception("X не може дорівнювати нулю.");
                            }
                            answer = b * a;
                            lblAnswer.Text = "Answer: X = " + answer.ToString();
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message, "Exception message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbGetA.Text = "";
                            tbGetB.Text = "";
                        }
                        break;
                    }
            }                      
        }
    }
}
