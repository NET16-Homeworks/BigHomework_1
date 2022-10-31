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
        private static readonly UserService.UserService _userServ = new UserService.UserService();
        private static readonly Dictionary<string, List<Loan>> _userLoans = new Dictionary<string, List<Loan>>();
        private static readonly List<Loan> _userloan = new List<Loan>();
        private static readonly double[] _loanRate = new double[] { 10, 11.5, 13.4 };

        public void SuggestLoan()
        {
            Console.WriteLine("Please insert your email:");
            string email = Console.ReadLine();

            if (!_userServ.DoesUserExist(email))
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

            if (!_loanRate.Contains(loanrate))
            {
                throw new ObjectNotFoundException("There is no such loan rate. Please use the existing one");
            }
            else
            {
                _userloan.Add(new Loan { LoanAmount = loanAmount, LoanRate = loanrate, LoanTerm = loanTerm });
                LoanCalculator.Calculate(loanAmount, loanTerm, loanrate);
            }

            Console.WriteLine("If you agree with the conditions, please press yes; otherwise, no to");
            var response = Console.ReadLine();
            if (response == "yes")
            {
                _userLoans.Add(email, new List<Loan>(_userloan));
                Console.WriteLine("Your application has been submitted. Please wait for our feedback within 1 working day.");
            }

            else
            {
                Console.WriteLine("Cancelling the app.");
            }
        }              
    }
}
