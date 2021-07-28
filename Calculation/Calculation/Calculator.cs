using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class Calculator
    {

        public List<int> FiboNumbers = new List<int>{1,1,2,3,5,8,13};

        public bool IsOdd(int value)
        {
            return (value % 2) == 1;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }

        public double AddDouble(double a, double b)
        {
            return a + b;
        }
    }
}
