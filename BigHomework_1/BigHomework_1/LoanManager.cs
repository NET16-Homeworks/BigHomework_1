using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class LoanManager
    {
        private static Dictionary<string, List<Loan>> userLoans = new Dictionary<string, List<Loan>>();
        private static List<double> Rates = new List<double>() { 10.0, 11.5, 13.4 };

        public static void SuggestLoan()
        {
            Console.WriteLine("Введите Email пользователя:");
            string email = Console.ReadLine();

            if (!UserService.UserExists(email))
            {
                throw new ObjectNotFoundException(email);
            }

            Console.WriteLine("Введите сумму займа:");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите срок кредита в месяцах:");
            int loanTerm = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите процент по кредиту. Доступные сейчас ставки: 10%; 11.5%, 13.4%");
            double loanRate = double.Parse(Console.ReadLine());
            if (!Rates.Contains(loanRate))
            {
                throw new ObjectNotFoundException("Ваша ставка из доступных: 10%; 11.5%, 13.4%");
            }

            Console.WriteLine($"Расчет вашего кредита в сумме {loanAmount} на срок {loanTerm} мес. по ставке {loanRate}% годовых:");
            LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);

            Console.WriteLine("Согласны на текующие условия? д/н");
            string yesOrNo = Console.ReadLine();

            if (yesOrNo == "д")
            {
                if (userLoans.ContainsKey(email))
                {
                    userLoans[email].Add(new Loan(loanAmount, loanTerm, loanRate, email));
                }
                else
                {
                    List<Loan> userLoanList = new List<Loan>();
                    userLoanList.Add(new Loan(loanAmount, loanTerm, loanRate, email));
                    userLoans.Add(email, userLoanList);
                }
                Console.WriteLine($"Кредит добавлен пользователю {email}");

            }
            else if (yesOrNo == "н")
            {
                Console.WriteLine("Кредит отклонен");
            }
            else throw new ObjectNotFoundException("Да или нет");
        }

        public static void PrintLoan()
        {
            Console.WriteLine("Введите Email пользователя:");
            string email = Console.ReadLine();

            if (userLoans.ContainsKey(email))
            {
                foreach (var loan in userLoans[email])
                {
                    Console.WriteLine($"Email: {loan.Email}, сумма: {loan.LoanAmount}, ставка:{loan.LoanRate}, срок: {loan.LoanTerm} мес");
                }
            }
            else throw new ObjectNotFoundException(email);
        }
    }
}
