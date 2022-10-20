using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Services
{
    internal static class LoanCalculator
    {
        public static void Calculate(double loanAmount, int loanTerm, double loanRate)
        {
            double monthLoanRate = loanRate / 1200;
            double monthPayment = loanAmount * (monthLoanRate + (monthLoanRate / (Math.Pow(1 + monthLoanRate, (double)loanTerm) - 1)));
            double balance = loanAmount - monthPayment + loanAmount * monthLoanRate;
            Console.WriteLine("Остаток по кредиту   Ежемесячный платеж");
            for (int i = 0; i < loanTerm; i++)
            {
                Console.WriteLine("{0:f2}\t\t\t{1:f2}", balance, monthPayment);
                balance = balance - monthPayment + balance * monthLoanRate;
            }

        }
    }
}
