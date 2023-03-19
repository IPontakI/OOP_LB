using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public static void displayArray(double[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }  
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();            

            double[] array = new double[10];            

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-20, 30);
            }
            Console.WriteLine("Array:");
            displayArray(array);            

            Console.WriteLine("\tFirst task a)");
            double summ = 1;

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    summ *= array[i]; 
                }
            }
            Console.WriteLine("Summ value = " + summ);

            Console.WriteLine("\n\tFirst task b)");
            double minEl = array[0];
            summ = 0;
            int minIndex = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if(minEl > array[i])
                {                
                    minEl = array[i];
                    minIndex = i;
                }
            }            

            for(int i = 0; i < minIndex; i++)
            {
                summ += array[i];
            }
            Console.WriteLine("Summ value = " + summ);

            Console.WriteLine("\n\tSorting");           
            
            double[] arrPair = new double[5];
            double[] arrOdd = new double[5];
            for(int i = 0, p = 0, o = 0; i < array.Length; i++)
            {
                if(i % 2 == 0)
                {
                    arrPair[p] = array[i];
                    p++;
                }
                else
                {
                    arrOdd[o] = array[i];
                    o++;
                }
            }

            Console.WriteLine("Pair arr:");
            displayArray(arrPair);
            Console.WriteLine("Pair arr sorted:");
            Array.Sort(arrPair);
            displayArray(arrPair);

            Console.WriteLine("Odd arr:");
            displayArray(arrOdd);
            Console.WriteLine("Odd arr sorted:");
            Array.Sort(arrOdd);
            displayArray(arrOdd);
            //--------------------------------------------
            Console.WriteLine("\tSecond task 1)");

            int[,] array2 = new int[5,5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array2[i, j] = rnd.Next(1,30);
                }
            }       
            
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write(array2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\tSecond task 2)");
            Console.WriteLine("Right-down corner -\t" + array2[4, 4]);

            Console.WriteLine("\n\tSecond task 3)");
            Console.WriteLine("Left-up corner -\t" + array2[0, 0]);

        }
    }
}
