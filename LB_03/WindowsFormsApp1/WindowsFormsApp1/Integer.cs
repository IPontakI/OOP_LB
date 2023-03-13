using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Integer : Number
    {
        private int numA;
        private int numB;

        public void setNumA(int a)
        {
            this.numA = a;
        }

        public void setNumB(int b)
        {
            this.numB = b;
        }

        public int add() { return numA + numB; }
        public int subtraction() { return numA - numB; }
        public int multiplication() { return numA * numB; }
        public int division() { return numA / numB; }
    }
}
