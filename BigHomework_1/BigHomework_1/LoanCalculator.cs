using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    static internal class LoanCalculator
    {

        static public void Calculate(double amountCredit, int countMonth, double percent)
        {
            double P = Math.Round(percent / 100 / countMonth, 2);
            double nP = 1d;
            for (int j = 0; j < countMonth; j++)
            {
                nP *= Math.Round(1+P, 2);
            }
            double x = Math.Round(amountCredit * (P + P / (nP - 1)), 2);
            string res = String.Empty;
            double y = amountCredit;
            double Rest = y;
            int i;
            for (i = 1; i <= countMonth; i++)
            {
                Rest = Math.Round(y - x + y * P);
                if (Rest < 0 ) Rest = y;
                res = res + Environment.NewLine; 
                res = res = res + $"Месяц {i}  : Остаток = {y}, Платить = {x}";
                y = Rest;
            }
            Console.WriteLine(res); 
        }        
    }
}
