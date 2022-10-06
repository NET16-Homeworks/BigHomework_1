using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal static class LoanCalculator
    {
        public static void Calculate(double sumOfLoan, int monthCount, double percent)
        {
            double percentRate = percent / 1200;
            double remainderOfCurrentPeriod;
            double amountOfCredit = sumOfLoan * (percentRate + (percentRate / (Math.Pow(1 + percentRate, monthCount) - 1)));
            double mainDept;
            for (int i = 1; i < monthCount + 1; i++)
            {
                Console.WriteLine($"Amount of payment for {i} month: {amountOfCredit}");
                mainDept = amountOfCredit - sumOfLoan * percentRate;
                remainderOfCurrentPeriod = sumOfLoan - mainDept;
                Console.WriteLine($"Remainder: {remainderOfCurrentPeriod}");
                Console.WriteLine("=========");
                sumOfLoan = remainderOfCurrentPeriod;
            }
        }
    }
}
