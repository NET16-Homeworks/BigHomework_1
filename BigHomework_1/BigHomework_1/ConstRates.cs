using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class ConstRates
    {
        public static double[] Rates = { 10.0, 11.5, 13.4 };

        public static double EnterRates()
        {
            int index = -1;
            int i = 0;
                do
                {
                    string s = "Введите индекс процентной ставки";
                    foreach (var rate in Rates)
                    {
                        s = s + Environment.NewLine + Convert.ToString(rate) + " : index = " + Convert.ToString(i);
                        i++;
                    }
                    Console.WriteLine(s);

                    if (int.TryParse(Console.ReadLine(), out int ii))
                    {
                        index = ii;
                    };
                    i = 0;
                } while (index < 0 || index >= Rates.Length);
            return Rates[index];
        }
    }
}
