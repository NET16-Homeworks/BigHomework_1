using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loan
{
    internal static class LoanCalculator
    {
        

        public static void Calculate(double creditAmount, int creditMonthDuration, double creditPercentage)
        {
            double creditMonthDurationDouble = creditMonthDuration;
            double loanBalance = creditAmount ;
            double monthlyPayingAmount = 0;
            double percentageRate = creditPercentage / 100 / 12;

            monthlyPayingAmount = Math.Round(creditAmount * (percentageRate + (percentageRate / (Math.Pow(1 + percentageRate, creditMonthDurationDouble) - 1))), 2);

            for (int i = 1; i <= creditMonthDuration; i++)
            {
                loanBalance = Math.Round(loanBalance - monthlyPayingAmount + (loanBalance * creditPercentage / 100 / 12), 2);
                if (loanBalance < 0) loanBalance = 0;       
                Console.WriteLine($"Month {i}, paying {monthlyPayingAmount}, loan balance - {loanBalance}");
            }         
        }
    }
}
