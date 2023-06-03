using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Word.Application word = new Word.Application();
        Word.Document doc = new Word.Document();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Select();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string fn = @"D:\!Валик\Универ\ООП\c#\LB_26\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Invitation.dotx";

                Object missingObj = System.Reflection.Missing.Value;
                Object trueObj = true;
                Object falseObj = false;
                Object templatePathObj = fn;

                doc = word.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
                doc.Activate();
                try
                {
                    foreach (Word.FormField f in doc.FormFields)
                    {
                        switch (f.Name)
                        {
                            case "mainName":
                                f.Range.Text = textBox1.Text;
                                break;
                            case "invName":
                                f.Range.Text = textBox2.Text;
                                break;
                            case "time":
                                f.Range.Text = dateTimePicker1.Text;
                                break;
                            case "place":
                                f.Range.Text = textBox4.Text;
                                break;
                            case "invName2":
                                f.Range.Text = textBox2.Text;
                                break;
                        }
                    }
                    word.Visible = true;
                }
                catch (Exception error)
                {
                    doc.Close();
                    word.Quit();
                    doc = null;
                    word = null;
                    throw error;
                }
            }
            else
            {
                string fn = @"D:\!Валик\Универ\ООП\c#\LB_26\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Invitation2.dotx";

                Object missingObj = System.Reflection.Missing.Value;
                Object trueObj = true;
                Object falseObj = false;
                Object templatePathObj = fn;

                doc = word.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
                doc.Activate();
                try
                {
                    foreach (Word.FormField f in doc.FormFields)
                    {
                        switch (f.Name)
                        {
                            case "name":
                                f.Range.Text = textBox1.Text;
                                break;
                            case "City":
                                f.Range.Text = textBox2.Text;
                                break;
                            case "ТекстовоеПоле3":
                                f.Range.Text = dateTimePicker1.Text;
                                break;
                            case "Name2":
                                f.Range.Text = textBox1.Text;
                                break;                            
                        }
                    }
                    word.Visible = true;
                }
                catch (Exception error)
                {
                    doc.Close();
                    word.Quit();
                    doc = null;
                    word = null;
                    throw error;
                }
            }           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Invitator";

            label1.Location = new Point(418, 344);//+
            label2.Location = new Point(418, 388);//+
            label3.Location = new Point(418, 429);//+
            label4.Location = new Point(418, 470);//+
            label4.Visible = true;
            label5.Location = new Point(490, 272);//+

            textBox1.Location = new Point(539, 347);
            textBox2.Location = new Point(539, 388);

            dateTimePicker1.Location = new Point(539, 432);

            textBox4.Location = new Point(539, 470);
            textBox4.Visible = true;

            button1.Location = new Point(417, 520);
            button2.Location = new Point(417, 614);

            radioButton1.Location = new Point(400, 579);
            radioButton2.Location = new Point(597, 579);

            MaximumSize = new Size(1126, 700);
            MinimumSize = new Size(1126, 700);

            Image myimage = new Bitmap(@"D:\!Валик\Универ\ООП\c#\LB_26\Template\1.png");
            this.BackgroundImage = myimage;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "City";

            label1.Location = new Point(255, 262);
            label2.Location = new Point(255, 306);
            label3.Location = new Point(255, 347);
            label4.Location = new Point(418, 470);
            label4.Visible = false;
            label5.Location = new Point(327, 190);

            textBox1.Location = new Point(376, 265);
            textBox2.Location = new Point(376, 306);

            dateTimePicker1.Location = new Point(376, 350);

            textBox4.Location = new Point(539, 347);
            textBox4.Visible = false;

            button1.Location = new Point(254, 388);
            button2.Location = new Point(254, 482); 

            radioButton1.Location = new Point(237, 447);
            radioButton2.Location = new Point(434, 447);

            MaximumSize = new Size(765, 618);
            MinimumSize = new Size(765, 618);

            Image myimage = new Bitmap(@"D:\!Валик\Универ\ООП\c#\LB_26\Template\2.jpg");
            this.BackgroundImage = myimage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Process.Start(@"D:\!Валик\Универ\ООП\c#\LB_26\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Invitation.dotx");
            }
            else
            {
                Process.Start(@"D:\!Валик\Универ\ООП\c#\LB_26\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Invitation2.dotx");
            }
            
        }
    }
}
