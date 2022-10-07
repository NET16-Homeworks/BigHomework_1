using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;
using BigHomework_1.UserService;
using BigHomework_1.Loans;


namespace BigHomework_1.LoanService
{
    internal class LoanManager
    {
        UserServ userServ = new UserServ();
        private static Dictionary<string, List<Loan>> _userLoans = new Dictionary<string, List<Loan>>();
        List<Loan> userloan = new List<Loan>();
        double[] _loanRate = new double[] { 10, 11.5, 13.4 };

        public void SuggestLoan()
        {
            Console.WriteLine("Please insert your email:");
            string email = Console.ReadLine();

            if (!userServ.DoesUserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            Console.WriteLine("Please insert loan amount:");
            double loanAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Please insert loan term:");
            int loanTerm = int.Parse(Console.ReadLine());
            //можно ли след образом:?
            //loan.LoanTerm = int.Parse(Console.ReadLine());

            foreach (var loanRate in _loanRate)
            {

                Console.WriteLine($"Available loan rates: + {loanRate} + \t");

            }
            Console.WriteLine("Please type the suitable loan rate.");
            var loanrate = double.Parse(Console.ReadLine());
            foreach (var loanRate in _loanRate)
            {
                if (loanrate == _loanRate[0] || loanrate == _loanRate[1] || loanrate == _loanRate[2])
                {
                    break;
                }
                else
                {
                    throw new Exception("There is no such loan rate. Please use the existing one");
                }
            }
            userloan.Add(new Loan { LoanAmount = loanAmount, LoanRate = loanrate, LoanTerm = loanTerm });
            LoanCalculator.Calculate(loanAmount, loanTerm, loanrate);

            Console.WriteLine("If you agree with the conditions, please press yes; otherwise, no to");
            var response = Console.ReadLine();
            if (response == "yes")
            {
                _userLoans.Add(email, new List<Loan>(userloan));
                Console.WriteLine("Your application has been sumitted. Please wait for our feedback within 1 working day.");
                //вывести и юзера и его кредиты: создавать доп метод в юзерсервисе и лоанменеджере,через форич 
                //выводить на консольего данные и креиты соотв-но, вызвать эти методы в мэйне
            }

            else

            {
                Console.WriteLine("Cancelling the app.");
            }
        }              
    }
}
