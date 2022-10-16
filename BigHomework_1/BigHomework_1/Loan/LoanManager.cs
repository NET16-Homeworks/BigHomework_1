using BigHomework_1.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.User;
using BigHomework_1.Exceptions;
namespace BigHomework_1.Loan
{
    internal class LoanManager
    {
        private static Dictionary<string, List<Loan>> loansForUsers = new Dictionary<string, List<Loan>>();
        private static UserService userService = new UserService();
        private static List<double> Rates = new List<double>() { 5, 7.2, 10.2, 15.4 };

        public void SuggestLoan()
        {
            string email = string.Empty;
            double loanAmount = 0;
            int loanTerm = 0;
            double loanRate = 0;

            Console.WriteLine("1. Введите Email Юзера");
            email = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrEmpty(email))
            {
                throw new Exception("Неверно введeн email");
            }
            if (!userService.IsUserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            Console.WriteLine("2. Введите сумму займа");
            loanAmount = double.Parse(Console.ReadLine());
            if (loanAmount <= 0)
            {
                throw new Exception($"Некорректно введена сумма займа{loanAmount}");
            }
            Console.WriteLine("3. Введите срок кредита в месяцах");
            loanTerm = int.Parse(Console.ReadLine());
            if (loanTerm <= 0)
            {
                throw new InvalidValueException<double>(loanTerm);
            }
            Console.WriteLine("4. Введите процент по вкладу (Доступные процентные ставки - 5.0%, 7.2%, 10.2%, 15.4%)");
            loanRate = double.Parse(Console.ReadLine());
            if (!Rates.Contains(loanRate))
            {
                throw new Exception($"вы выбрали несуществующую процентную ставку {loanRate}");
            }
            Console.WriteLine("Ваши кредитные условия следующие:");
            LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);
            Console.WriteLine("Введите (1) чтобы подтвердить ваш выбор или (2) чтоб отклонить выбор");
            string OneOrTwo = Console.ReadLine();
            switch (OneOrTwo)
            {
                case "1":
                    if (loansForUsers.ContainsKey(email))
                    {
                        loansForUsers[email].Add(new Loan(loanAmount, loanTerm, loanRate, email));
                    }
                    else
                    {
                        List<Loan> userLoanList = new List<Loan>();
                        userLoanList.Add(new Loan(loanAmount, loanTerm, loanRate, email));
                        loansForUsers.Add(email, userLoanList);
                    }
                    Console.WriteLine($"Кредит успешно добавлен к пользователю с почтой: \"{email}\" ");
                    break;

                case "2":
                    Console.WriteLine("Вы отклонили кредит с выбранными условиями.");
                    break;

                default:
                    Console.WriteLine("Введите \"1\" или \"2\"");
                    break;
            }
        }
        public void ShowLoan(string email)
        {
            if (loansForUsers.ContainsKey(email))
            {
                foreach (var loan in loansForUsers[email])
                {
                    Console.WriteLine($"Email : {loan.Email}" + Environment.NewLine + $"Сумма Кредита : {loan.LoanAmount}" + Environment.NewLine +
                        $"Процент по вкладу :{loan.LoanRate}" + Environment.NewLine + $"Срок кредита:{loan.LoanTerm}");
                }
            }
            else throw new ObjectNotFoundException(email);
        }
    } 
}
 