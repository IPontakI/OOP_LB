using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Real : Number <double>
    {
        private double numA;
        private double numB;

        public void setNumA(double a)
        {
            this.numA = a;
        }

        public void setNumB(double b)
        {
            this.numB = b;
        }

        public override double Add()
        {
            return numA + numB;
            throw new NotImplementedException();
        }

        public override double division()
        {
            return numA - numB;
            throw new NotImplementedException();
        }

        public override double multiplication()
        {
            return numA * numB;
            throw new NotImplementedException();
        }

        public override double subtraction()
        {
            return numA / numB;
            throw new NotImplementedException();
        }

        

        /* public double add() { return numA + numB; }
         public double subtraction() { return numA - numB; }
         public double multiplication() { return numA * numB; }
         public double division() { return numA / numB; }*/




    }
}
