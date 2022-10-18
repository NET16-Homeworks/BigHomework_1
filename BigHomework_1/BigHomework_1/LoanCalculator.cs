using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal static class LoanCalculator
    {
        public static void Calculate(double loanAmount, int loanTerm, double loanRate)
        {
            double monthlyPayment = 0;
            double loanRateShare = loanRate / 100 / 12;
            double periodBalance = loanAmount;

            monthlyPayment = loanAmount * (loanRateShare + (loanRateShare / (Math.Pow(1 + loanRateShare, Convert.ToDouble(loanTerm)) - 1)));
            
            Console.WriteLine("------------------Calculate-----------------");
            for (int i = 1; i <= loanTerm; i++)
            {
                periodBalance = periodBalance - monthlyPayment + periodBalance * loanRateShare;
                Console.WriteLine($"{i}-й месяц: {monthlyPayment} : {periodBalance}");
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}
