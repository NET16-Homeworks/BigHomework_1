using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loan
{
    internal static class LoanCalculator
    {
        public static void Calculate(double summOfCredit,int countOfMonths,double creditPercents)
        {
            double everyMonthlyPayingAmount;
            double intToDoubleCountOfMonth = countOfMonths;
            double ostatokSummOfCredit = summOfCredit;
            double percentageStavka = creditPercents / 100 / 12;

            everyMonthlyPayingAmount = Math.Round(summOfCredit * percentageStavka + ((summOfCredit *percentageStavka) / ((Math.Pow((1 + percentageStavka), intToDoubleCountOfMonth) - 1))),4);

            for (int i = 1; i <= countOfMonths; i++)
            {
                ostatokSummOfCredit = Math.Round(ostatokSummOfCredit - everyMonthlyPayingAmount + (ostatokSummOfCredit * creditPercents / 100 / 12), 3);
                if (ostatokSummOfCredit < 0)
                    ostatokSummOfCredit = 0;
                Console.WriteLine($"Месяц{i}, Ежемесячный платеж: {everyMonthlyPayingAmount}" +Environment.NewLine+ $"Остаток: {ostatokSummOfCredit}");
            }



        }
    }
}
