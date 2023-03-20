using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Number <T>
    {
        public abstract T Add();
        public abstract T subtraction();
        public abstract T multiplication();
        public abstract T division();
    }
}
