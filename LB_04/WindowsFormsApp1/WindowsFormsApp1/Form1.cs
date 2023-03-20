using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            lblPrintArr.Text = "";
            lblMultiplication.Text = "";
            lblSumm.Text = "";
            lblPrintPairArr.Text = "";
            lblPrintPairArrSorted.Text = "";
            lblPrintOddArr.Text = "";
            lblPrintOddArrSorted.Text = "";
            lblRightDownCorner.Text = "";
            lblLeftUpCorner.Text = "";

            //dataGridView1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            double[] array = new double[10];
            string arrStr = "";
            string arrStr1 = "";

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-20, 30);
                arrStr += array[i].ToString() + " ";
            }
            //Console.WriteLine("Array:");
            lblPrintArr.Text = arrStr;
            arrStr = "";

            //Console.WriteLine("\tFirst task a)");
            double summ = 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    summ *= array[i];
                }
            }
            //Console.WriteLine("Summ value = " + summ);
            lblMultiplication.Text = "Summ value = " + summ;

            //Console.WriteLine("\n\tFirst task b)");
            double minEl = array[0];
            summ = 0;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (minEl > array[i])
                {
                    minEl = array[i];
                    minIndex = i;
                }
            }

            for (int i = 0; i < minIndex; i++)
            {
                summ += array[i];
            }
            lblSumm.Text = "Summ value = " + summ;

            //Console.WriteLine("\n\tSorting");

            double[] arrPair = new double[10];
            
            double[] arrOdd = new double[10];
            
            for (int i = 0, p = 0, o = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {                    
                    arrOdd[o] = array[i];
                    arrStr1 += arrOdd[o] + " ";
                    o++;
                }
                else
                {
                    arrPair[p] = array[i];
                    arrStr += arrPair[p] + " ";
                    p++;
                }
            }

            //Console.WriteLine("Pair arr:");
            lblPrintPairArr.Text = "Pair arr: " + arrStr;
            //Console.WriteLine("Pair arr sorted:");
            arrStr = "";
            Array.Sort(arrPair);            
            for(int i = 0; i < arrPair.Length; i++)
            {
                if (arrPair[i] != 0)
                {
                    arrStr += arrPair[i] + " ";
                }
            }
            lblPrintPairArrSorted.Text = "Pair arr sorted: " + arrStr;


            //Console.WriteLine("Odd arr:");
            lblPrintOddArr.Text = "Odd arr: " + arrStr1;
            //Console.WriteLine("Odd arr sorted:");
            arrStr1 = "";
            Array.Sort(arrOdd);            
            for (int i = 0; i < arrOdd.Length; i++)
            {
                if(arrOdd[i] != 0)
                {
                    arrStr1 += arrOdd[i] + " ";
                }                
            }
            lblPrintOddArrSorted.Text = "Odd arr sorted: " + arrStr1;
            //--------------------------------------------
            //Console.WriteLine("\tSecond task 1)");

            int[,] array2 = new int[5, 5];
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 5;

            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array2[i, j] = rnd.Next(-20, 30);
                    dataGridView1.Rows[i].Cells[j].Value = array2[i, j].ToString();
                }
            }        
                    
            lblRightDownCorner.Text = "Right-down corner: \t" + array2[4, 4];

            lblLeftUpCorner.Text = "Left-up corner: \t" + array2[0, 0];
        }
    }
}
