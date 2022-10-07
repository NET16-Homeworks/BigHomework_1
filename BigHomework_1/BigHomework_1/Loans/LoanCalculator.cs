using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loans
{
    internal static class LoanCalculator
    {
        public static void Calculate(double creditSum, int creditMonths, double InterestRate)
        {
            double percentInterestRate = InterestRate / 100 / 12;
            double monthlyPayment = Math.Round((creditSum * (percentInterestRate /
                ((Math.Pow(1 + percentInterestRate, creditMonths)) - 1)
                + percentInterestRate)));

            double balanceCurrPeriod = creditSum - monthlyPayment;
            double balanceNextPeriod = balanceCurrPeriod - monthlyPayment + balanceCurrPeriod * percentInterestRate;
            
            Console.WriteLine(monthlyPayment);
            Console.WriteLine(balanceNextPeriod);
        }
    }
}
