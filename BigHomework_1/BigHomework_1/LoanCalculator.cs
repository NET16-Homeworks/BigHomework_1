using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    public static class LoanCalculator
    {
        public static double Calculate(double LoanAmount, int LoanTerm, double LoanRate)
        {
            var P = LoanRate / 100 / 12;
            return LoanAmount * (P + (P / (Math.Pow(1 + P, LoanTerm) - 1)));
        }
    }
}
