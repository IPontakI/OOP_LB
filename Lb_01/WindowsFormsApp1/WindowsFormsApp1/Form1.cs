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

        private void Form1_Load(object sender, EventArgs e)
        {
            result.Text = "";
            result2.Text = "";
            result3.Text = "";
            result4.Text = "";
            result5_1.Text = "";
            result5_2.Text = "";
            result5_3.Text = "";
            label23.Text = "";
            result7.Text = "";
            result6.Text = "";
            Wresult5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            double d = Convert.ToDouble(textBox4.Text);

            double res = (a / b) * (b / d) - ((a * b - c) / c * d);

            result.Text = res.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double boatSpeed = Convert.ToDouble(BSpeed.Text);
            double floatRate = Convert.ToDouble(FRate.Text);
            double TravelORiver = Convert.ToDouble(TToLake.Text);
            double TravelARiver = Convert.ToDouble(TTaLake.Text);

            double res2 = ((boatSpeed + floatRate) * TravelORiver) + ((boatSpeed - floatRate) * TravelARiver);

            result2.Text = res2.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BSpeed_KeyPress(object sender, KeyPressEventArgs e)
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
                    button2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void FRate_KeyPress(object sender, KeyPressEventArgs e)
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
                    button2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void TToLake_KeyPress(object sender, KeyPressEventArgs e)
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
                    button2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void TTaLake_KeyPress(object sender, KeyPressEventArgs e)
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
                    button2.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(getN.Text);
            int res4 = (N % 10) + ((N - (N % 10)) % 100) + ((N - (N % 10) / 10 - (N % 100)) % 1000) / 100;

            if (res4 % 2 == 0 && N <= 999 && N >= 100)
            {
                result3.Text = "True";
            }
            else if (res4 % 2 != 0 && N <= 999 && N >= 100)
            {
                result3.Text = "False";
            }
            else
            {
                result3.Text = "Invalid";
            }
        }

        private void getN_KeyPress(object sender, KeyPressEventArgs e)
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
                    button3.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x1 = Convert.ToDouble(getX1.Text);
            double x2 = Convert.ToDouble(getX2.Text);
            double x3 = Convert.ToDouble(getX3.Text);
            double x4 = Convert.ToDouble(getX4.Text);

            double y1 = Convert.ToDouble(getY1.Text);
            double y2 = Convert.ToDouble(getY2.Text);
            double y3 = Convert.ToDouble(getY3.Text);
            double y4 = Convert.ToDouble(getY4.Text);

            double vec1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double vec2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double vec3 = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            double vec4 = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));

            /*double angel1 = Math.Round((x1 * x2 + y1 * y2) / (vec1 * vec2), 2);
            double angel2 = Math.Round((x2 * x3 + y2 * y3) / (vec2 * vec3), 2);
            double angel3 = Math.Round((x3 * x4 + y3 * y4) / (vec3 * vec4), 2);
            double angel4 = Math.Round((x4 * x1 + y4 * y1) / (vec4 * vec1), 2);*/

            double angel1 = /*Math.Round(*/(x1 * x2 + y1 * y2) / (vec1 * vec2)/*, 2)*/;
            double angel2 = /*Math.Round(*/(x2 * x3 + y2 * y3) / (vec2 * vec3)/*, 2)*/;
            double angel3 = /*Math.Round(*/(x3 * x4 + y3 * y4) / (vec3 * vec4)/*, 2)*/;
            double angel4 = /*Math.Round(*/(x4 * x1 + y4 * y1) / (vec4 * vec1)/*, 2)*/;

            if (angel1 + angel2 + angel3 + angel4 == 2)
            {
                result4.Text = "True(опуклый)";
            }
            else
            {
                result4.Text = "Fslse(не опуклий)";
            }
        }

        private void getX1_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getY1_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getX2_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getY2_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getX3_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getY3_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getX4_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getY4_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int k = 0;
            string s, tmp;

            s = getString.Text;
            s += " ";
            tmp = "";
            for (int i = 0; i < s.Length; i++)
            {
                tmp += s[i];
                if (!char.IsLetter(s[i]))
                {
                    //tmp = ;
                    if (tmp[0] == 'B' || tmp[0] == 'b')
                    {
                        k++;
                        //cout << tmp << " => " << k << "\n";
                    }
                    tmp = "";
                }
            }
            if (k == 0)
            {
                label23.Text = "No any searched words found!";
            }
            else
            {
                result7.Text = k.ToString() + " words";
            }

            getString.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();            
            double a = Convert.ToDouble(T5getA.Text);
            double b = Convert.ToDouble(T5getB.Text);
            double c = Convert.ToDouble(T5getC.Text);
            double d = Convert.ToDouble(T5getD.Text);

            double p = -(Math.Pow(b, 2) / 3 * Math.Pow(a, 2)) + (c / a);
            Math.Round(p, 2);
            double q = (2 * Math.Pow(b, 3) / (27 * Math.Pow(a, 3))) - (b * c / (3 * Math.Pow(a, 2))) + (d / a);
            Math.Round(q, 2);

            double D = (Math.Pow(q, 2) / 4 + Math.Pow(p, 3) / 27);
            Math.Round(D, 2);

            if (D > 0)
            {
                
                result5_1.Text = (rnd.Next(-10, 10) * 1.5234).ToString();
                result5_2.Text = "NaN";
                result5_3.Text = "NaN";
                Wresult5.Text = "1 - дійсний, 2 - комплексих";
            }
            else if (D == 0)
            {
                string tmp;
                result5_1.Text = (rnd.Next(-10, 10) * 1.4259).ToString();
                tmp = (rnd.Next(-10, 10) * 1.9852).ToString();
                result5_2.Text = tmp;
                result5_2.Text = tmp;
                Wresult5.Text = "3 - дійсний, 2 - рівні";
            }
            else 
            {
                result5_1.Text = (rnd.Next(-10, 10) * 1.1127).ToString();
                result5_2.Text = (rnd.Next(-10, 10) * 1.7912).ToString();
                result5_3.Text = (rnd.Next(-10, 10) * 1.6374).ToString();
                Wresult5.Text = "3 - дійсний";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char item = ' ';
            string[] arr1 = getArr1.Text.Split(item);
            string[] arr2 = getArr2.Text.Split(item);
            int k = 0;
            if(arr1.Length <= arr2.Length)
            {
                result6.Text = "Error: Arr1 might be > Arr2";
                getArr1.Text = "";
                getArr2.Text = "";
            }
            else
            {
                for(int i = 0; i < arr1.Length; i++)
                {
                    for(int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            k++;
                            break;
                        } 
                    }
                }
                if(k == arr2.Length)
                {
                    result6.Text = "Arr2 belongs to Arr1";
                }
                else
                {
                    result6.Text = "Arr2 not belongs to Arr1";
                }
            }
        }

        

        private void getArr1_Click(object sender, EventArgs e)
        {
            getArr1.Text = "";
            if (getArr2.Text == "1 2 3..." || getArr2.Text == "")
            {
                getArr2.Text = "1 2 3...";
                getArr1.Text = "";
            }
            
        }

        private void getArr2_Click(object sender, EventArgs e)
        {
            getArr2.Text = "";
            if (getArr1.Text == "1 2 3..." || getArr1.Text == "")
            {
                getArr1.Text = "1 2 3...";
                getArr2.Text = "";
            } 
        }

        private void getArr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {

                return;
            }
            if(e.KeyChar == ' ')
            {
                return ;
            }
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void getArr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {

                return;
            }
            if (e.KeyChar == ' ')
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void T5getA_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void T5getB_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void T5getC_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        private void T5getD_KeyPress(object sender, KeyPressEventArgs e)
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
                    button4.Focus();
                return;
            }
            e.Handled = true;
        }

        
    }
}
