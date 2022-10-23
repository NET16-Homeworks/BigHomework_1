using BigHomework_1.Entities;
using BigHomework_1.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Services
{
    /*
     Условие: Сделайте его таким образом, чтобы к одному email можно было добавлять несколько кредитов, т.е. email опять должен быть уникальным. 
     Если к одному емаилу можно добавлять несколько кредитов, то получается, что емаил не уникальный, если я правильно понял. В итоге делаю так
     что к одному емеилу - несколько кредитов, т.е у класса Loan email не будет уникален. Возможно просто 2 часа ночи и я чего-то не понимаю.
    */
    internal class LoanManager
    {
        private static List<Loan> _userLoans = new List<Loan>();
        private UserService userService = new UserService();

        public void SuggestedLoan()
        {
            double[] loanRates = new double[3] { 10.0, 11.5, 13.4 };
            bool rateExists = false;


            Console.Write("Введите e-mail: ");
            string email = InputCheckMethods.StringReadAndCheck();
            if (!userService.UserExists(email))
            {
                throw new ObjectNotFoundException(email);
            }

            Console.Write("Введите сумму займа: ");
            double loanAmount = InputCheckMethods.DoubleReadAndCheck();

            Console.Write("Введите период кредитования: ");
            int loanTerm = InputCheckMethods.IntReadAndCheck();

            Console.Write("Введите годовой процент (только 10, 11.5, 13.4): ");
            double loanRate = InputCheckMethods.DoubleReadAndCheck();
            foreach (var item in loanRates)
            {
                if (item == loanRate)
                {
                    rateExists = true;
                    break;
                }
            }
            if (!rateExists)
            {
                throw new ObjectNotFoundException(loanRate.ToString());
            }

            LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);

            Console.WriteLine("Согласны ли вы с условиями кредита? (да/нет)");
            string? response = InputCheckMethods.StringReadAndCheck();
            response.Trim()
                    .ToLower();
            if (response == "да")
            {
                var loan = new Loan();
                loan.Email = email;
                loan.LoanAmount = loanAmount;
                loan.LoanTerm = loanTerm;
                loan.LoanRate = loanRate;
                _userLoans.Add(loan);
                Console.WriteLine("Кредит получен!");
            }
            else
            {
                Console.WriteLine("Кредит не выдан!");
            }

        }
    }
}
