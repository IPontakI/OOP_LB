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
            lblIntegerOut.Text = "";
            tbGetA.MaxLength = 6;
            tbGetB.MaxLength = 6;
            tbGetC.MaxLength = 6;
        }

        long INTEG;
        private void btn1_Click(object sender, EventArgs e)
        {
            if (tbGetA.Text == "" || tbGetB.Text == "" || tbGetC.Text == "")
            {
                lblIntegerOut.ForeColor = Color.Red;
                lblIntegerOut.Text = "You enter somthing wrong!";
                tbGetA.Text = "";
                tbGetB.Text = "";
                tbGetC.Text = "";
            }
            else
            {
                lblIntegerOut.ForeColor = Color.Green;
                INTEG = long.Parse(tbGetA.Text + tbGetB.Text + tbGetC.Text);
                lblIntegerOut.Text = Convert.ToString(INTEG);
                tbGetA.Text = "";
                tbGetB.Text = "";
                tbGetC.Text = "";
            }

        }

        private void tbGetA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                    btn1.Focus();
                return;
            }
            e.Handled = true;
        }        
    }
}
