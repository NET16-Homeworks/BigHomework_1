using BigHomework_1.Exceptions;
using BigHomework_1.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Loan
{
    internal class LoanManager
    {
        private static Dictionary<string, List<Loan>> userLoans = new Dictionary<string, List<Loan>>();
        private static UserService userService = new UserService();
        public void SuggestLoan()
        {

            string email = string.Empty;
            double loanAmount = 0;
            int loanTerm = 0;
            double loanRate = 0;

            bool isTaskCompletedSucess = false;
            while (!isTaskCompletedSucess)
            {


                Console.WriteLine("1. Enter user Email");
                while (!isTaskCompletedSucess)
                {
                    email = Console.ReadLine();

                    if (!userService.IsUserExist(email))
                    {
                        throw new ObjectNotFoundException(email);
                    }
                    if (!String.IsNullOrWhiteSpace(email))
                    {
                        isTaskCompletedSucess = true;
                    }
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("2. Enter loan amount");
                while (!isTaskCompletedSucess)
                {
                    if (double.TryParse(Console.ReadLine(), out loanAmount) && loanAmount > 0)
                    {
                        isTaskCompletedSucess = true;
                    }
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("3. Enter loan term");
                while (!isTaskCompletedSucess)
                {
                    if (int.TryParse(Console.ReadLine(), out loanTerm) && loanTerm > 0)
                    {
                        isTaskCompletedSucess = true;
                    }
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("4. Enter loan rate (avaliable rates - 10%, 11,5%, 13,4%)");
                List<double> avaliableRates = new List<double>() {10, 11.5, 13.4};
                while (!isTaskCompletedSucess)
                {
                    if (double.TryParse(Console.ReadLine(), out loanRate) && avaliableRates.Contains(loanRate))
                    {
                        isTaskCompletedSucess = true;
                    }
                }
                isTaskCompletedSucess = false;


                Console.WriteLine("Your loan payments will be:");
                LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);

                Console.WriteLine("Type y (yes) to accept terms or n (no) to decline");
                while (!isTaskCompletedSucess)
                {
                    string acceptOrNot = Console.ReadLine();
                    switch (acceptOrNot)
                    {
                        case "y":
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
                            isTaskCompletedSucess = true;
                            Console.WriteLine($"Loan added sucesfully to \"{email}\" user!");
                            break;

                        case "n":
                            isTaskCompletedSucess = true;
                            Console.WriteLine("You declined this loan");
                            break;

                        default:
                            Console.WriteLine("Type only \"y\" or \"n\"");
                            break;
                    }
                }
            }
        }

        public void ShowLoan(string email)
        {
            if (userLoans.ContainsKey(email))
            {
                foreach (var loan in userLoans[email])
                {
                    Console.WriteLine($"Email : {loan.Email} - Amount : {loan.LoanAmount}, Rate :{loan.LoanRate}, Term : {loan.LoanTerm}");
                }
            }
            else throw new ObjectNotFoundException(email);
        }
    }
}
