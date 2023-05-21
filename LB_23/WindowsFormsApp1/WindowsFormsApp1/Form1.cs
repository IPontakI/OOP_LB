using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3f);
            Point[] points = new Point[1000];

            Point[] lineX = new Point[800];
            Pen penLineX = new Pen(Color.Black, 2f);
            Point[] lineY = new Point[400];
            Pen penLineY = new Pen(Color.Black, 2f);

            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            for (int i = 0; i < 400; i++)
            {

                lineY[i] = new Point(0 + 400, i);
                if (i % 20 == 0)
                {
                    int num = 0;
                    if (i <= 200)
                    {
                        num = Math.Abs(200 - i);
                    }
                    else
                    {
                        num = -Math.Abs(-200 + i);
                    }
                    graphics.DrawString(Convert.ToString(num), drawFont, drawBrush, 400, i);

                }

            }
            for (int i = 0; i < 800; i++)
            {
                lineX[i] = new Point(i, 0 + 200);
                if (i % 20 == 0)
                {
                    int numX = 0;
                    if (i <= 400)
                    {
                        numX = -Math.Abs(400 - i);
                    }
                    else
                    {
                        numX = Math.Abs(-400 + i);
                    }
                    graphics.DrawString(Convert.ToString(numX), drawFont, drawBrush, i, 200);
                }
            }
            graphics.DrawCurve(pen, points);
            graphics.DrawLines(penLineX, lineX);
            graphics.DrawLines(penLineY, lineY);

            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text); 
            int x0 = Convert.ToInt32(textBox3.Text) + 400; 
            int y0 = Convert.ToInt32(textBox4.Text) + 200; 
            

            Pen penX = new Pen(Color.Red, 3f);
            Point[] pointsX = new Point[800];
            Pen penY = new Pen(Color.Blue, 3f);
            Point[] pointsY = new Point[800];
            int val = 0;
            for (int i = 0; i < 800; i++)
            {
                int x = x0 + a * (int)(Math.Cos((double)i));
                int y = y0 + b * (int)(Math.Sin((double)i));

                pointsX[i] = new Point(x, i);
                pointsY[i] = new Point(i, y);
                val = x - 400;
            }

            graphics.DrawCurve(penX, pointsX);
            graphics.DrawCurve(penY, pointsY);
            label1.Text = "Область визначення червоного графіка: [ " + val + " ]";
            label2.Text = "Область визначення синього графіка: ( -∞; ∞)";
        }
    }
}
