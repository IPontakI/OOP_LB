using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Integer : Number <int>
    {
        public int numA;
        public int numB;

        public void setNumA(int a)
        {
            this.numA = a;
        }

        public void setNumB(int b)
        {
            this.numB = b;
        }

       /* public int Add()
        {
            return numA + numB;
            throw new NotImplementedException();
        }*/

        public override int Add()
        {
            return numA + numB;
            throw new NotImplementedException();
        }

        public override int division()
        {
            return numA - numB;
            throw new NotImplementedException();
        }

        public override int multiplication()
        {
            return numA * numB;
            throw new NotImplementedException();
        }

        public override int subtraction()
        {
            return numA / numB;
            throw new NotImplementedException();
        }



        /* public int add() { return numA + numB; }
         public int subtraction() { return numA - numB; }
         public int multiplication() { return numA * numB; }
         public int division() { return numA / numB; }*/

    }    
}
