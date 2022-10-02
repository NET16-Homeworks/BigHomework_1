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


        public void SuggestLoan()
        {
            string email = string.Empty;
            double loanAmount = 0;
            int loanTerm = 0;
            double loanRate = 0;

            bool isOkay = false;
            while (!isOkay)
            {
                Console.WriteLine("1. Введите Email Юзера");
                while (!isOkay)
                {
                    email = Console.ReadLine();

                    if (!userService.UserExist(email))
                    {
                        throw new ObjectNotFoundException(email);
                    }
                    if (String.IsNullOrWhiteSpace(email) || String.IsNullOrEmpty(email))
                    {
                        throw new Exception("Неверно введeн email");
                    }
                    else
                    {
                        isOkay = true;
                    }
                }
                isOkay = false;

                Console.WriteLine("2. Введите сумму займа");
                while (!isOkay)
                {
                    loanAmount = double.Parse(Console.ReadLine());
                    if (loanAmount<=0)
                    {
                        throw new Exception("Некорректно введена сумма займа");
                    }
                    else 
                    {
                        isOkay = true;
                    }
                }
                isOkay = false;

                Console.WriteLine("3. Введите срок кредита в месяцах");
                while (!isOkay)
                {
                    loanTerm = int.Parse(Console.ReadLine());
                    if (loanTerm <= 0)
                    {
                        throw new Exception("Неверно введен срок кредита");
                    }
                    else
                    {
                        isOkay = true;
                    }
                }
                isOkay = false;

                Console.WriteLine("4. Введите процент по вкладу (Доступные процентные ставки - 5.0%, 7.2%, 10.2%, 15.4%)");
                List<double> Rates = new List<double>() { 5, 7.2, 10.2, 15.4};
                while (!isOkay)
                {
                    loanRate = double.Parse(Console.ReadLine());
                    if (Rates.Contains(loanRate))
                    {
                        isOkay = true;
                    }
                    else
                    {
                        throw new Exception("вы выбрали несуществующую процентную ставку");
                    }
                }
                isOkay = false;
                Console.WriteLine("Ваши кредитные условия следующие:");
                LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);

                Console.WriteLine("Введите (1) чтобы подтвердить ваш выбор или (2) чтоб отклонить выбор");
                while (!isOkay)
                {
                    string yesOrNo = Console.ReadLine();
                    switch (yesOrNo)
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
                            isOkay = true;
                            Console.WriteLine($"Кредит успешно добавлен к пользователю с почтой: \"{email}\" ");
                            break;

                        case "2":
                            isOkay = true;
                            Console.WriteLine("Вы отклонили кредит с выбранными условиями.");
                            break;

                        default:
                            Console.WriteLine("Введите \"1\" или \"2\"");
                            break;
                    }
                }
            }
        }


        public void ShowLoan(string email)
        {
            if (loansForUsers.ContainsKey(email))
            {
                foreach (var loan in loansForUsers[email])
                {
                    Console.WriteLine($"Email : {loan.Email}" + Environment.NewLine + $"Сумма Кредита : {loan.LoanAmount}"+Environment.NewLine+
                        $"Процент по вкладу :{loan.LoanRate}"+Environment.NewLine+$"Срок кредита:{loan.LoanTerm}");
                }
            }
            else throw new ObjectNotFoundException(email);
        }




    }
}
