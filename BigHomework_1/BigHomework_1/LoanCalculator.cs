using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal static class LoanCalculator
    {
        public static void Calculate(double s, int n, double loanRate)
        {
            double p = loanRate / 100 / 12;
            double x = Math.Round(s * (p + p / (Math.Pow(1 + p, n) - 1)));
            Console.WriteLine($"Ежемесячный платеж: {x}");
            double y = s;

            for (int i = 1; i <= n; i++)
            {
                y = Math.Round(y - x + y * p);
                if (y < 0) y = 0;
                Console.WriteLine($"Месяц: {i}, остаток по кредиту: {y}");
            }
        }
    }
}
