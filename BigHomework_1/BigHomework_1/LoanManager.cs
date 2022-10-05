using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{   
    internal class LoanManager
    {
      static public List<Loan> Loans = new List<Loan>();

        public bool SuggestLoan()
        {
            bool f = true;
            try
            {
                string sEmail = UserService.EnterEmail(" кредитополучателя");
                if (UserService.UserExists(sEmail))
                {
                    double amountLoan = 0d;
                    do
                    {
                        Console.WriteLine("Введите сумму кредита");
                        if (double.TryParse(Console.ReadLine().Replace(',', '.'), out double _amountLoan))
                        { amountLoan = _amountLoan;}
                    } while (amountLoan <= 0d);
                    int countMonth = 0;
                    do
                    {
                        Console.WriteLine("Введите период погашения кредита в месяцах (целое число)");
                        if (int.TryParse(Console.ReadLine().Replace(',', '.'), out int _countMonth))
                        {countMonth = _countMonth; }
                    } while (countMonth <= 0);

                    double rate = ConstRates.EnterRates();

                    LoanCalculator.Calculate(amountLoan, countMonth, rate);

                    string ch = "0";
                    do
                    {
                        Console.WriteLine($"Если {sEmail} согласкен на кредит: нажмите 1, иначе нажмите 2");
                        string cch = Console.ReadKey(true).KeyChar.ToString();
                        if (cch == "1" || cch == "2")
                        { ch = cch; }
                    } while (ch == "0");

                    if (ch == "1")
                    { 
                    Loan loan = new Loan(amountLoan, countMonth, rate, sEmail);
                    Loans.Add(loan);    
                    }
                }
                else
                {
                    ObjectNotFoundException objectNotFoundException = new ObjectNotFoundException(sEmail);
                }
            }
            catch (Exception E)
            {
                f = false;
                throw;
            }
            return f;
        }
    }
}
