using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loans
{
    internal static class LoanCalculator
    {
        public static void Calculate(double creditSum, int creditMonthsTerm, double interestRate)
        {
            double percentInterestRate = interestRate / 100 / 12;
            double doubleCreditMonthsTerm = creditMonthsTerm;
            double creditRemainder = creditSum;
            double monthlyPayment = Math.Round(creditSum * (percentInterestRate + (percentInterestRate /
                (Math.Pow(1 + percentInterestRate, doubleCreditMonthsTerm) - 1))), 2);

            for (int i = 0; i <= creditMonthsTerm; i++)
            {
                creditRemainder = Math.Round(creditRemainder - monthlyPayment + creditRemainder * interestRate);
                if (creditRemainder < 0)
                {
                    creditRemainder = 0;
                }
                Console.WriteLine($"Month {i} / Monthly payment {monthlyPayment}");
                Console.WriteLine($" Remainder of credit sum for the next period: {creditRemainder}");
            }
        }
    }
}
