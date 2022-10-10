using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class LoanManager
    {
        private static List<Loan> userLoans = new List<Loan>();
        public static void SuggestLoan()
        {
            string email;
            double loanAmount;
            int loanTerm;
            double[] loanRates = new double[] { 10, 11.5, 13.4 };
            double loanRate;
            PrintAndInitializeData(out email, out loanAmount, out loanTerm, out loanRate);
            bool isSearched = false;
            foreach (var rate in loanRates)
            {
                if(rate == loanRate)
                {
                    isSearched = true;
                }
            }
            if(!isSearched)
            {
                throw new ObjectNotFoundException(loanRate.ToString());
            }
            if (!UserService.UserExists(email))
            {
                throw new ObjectNotFoundException(email);
            }
            LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);
            Console.WriteLine("Are you agree?");
            string isAgree = Console.ReadLine().ToLower();
            if (isAgree == "yes")
            {
                Loan loan = new Loan();
                loan.LoanAmount = loanAmount;
                loan.LoanTerm = loanTerm;
                loan.LoanRate = loanRate;
                loan.Email = email;
                userLoans.Add(loan);
            }
        }
        public static void PrintAndInitializeData(out string email, out double loanAmount, out int loanTerm, out double loanRate)
        {
            Console.WriteLine("Enter email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter loan amount:");
            loanAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter loan term:");
            loanTerm = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter loan rate:");
            loanRate = double.Parse(Console.ReadLine());
        }
        public static void PrintInformationAboutUserLoans(string email)
        {
            foreach(var loan in userLoans)
            {
                if(loan.Email == email)
                {
                    Console.WriteLine($"Email: {loan.Email}, Loan amount: {loan.LoanAmount}, Loan Term: {loan.LoanTerm}, Loan Rate: {loan.LoanRate}");
                }
            }
        }
    }
}
