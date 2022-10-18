using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class LoanManager
    {
        private static Dictionary<Loan, string> _userLoans = new Dictionary<Loan, string>();

        public static void SuggestLoan()
        {
            double[] loanRates = new double[] { 10, 11.5, 13.4 };
            Loan newLoan = new Loan();
            bool isNormal = false;
            string email = string.Empty;
            double loanAmount = 0;
            double loanRate = 0;
            int loanTerm = 0;

            Console.WriteLine("--------------Suggest Loan-------------");
            try
            {
                while (!isNormal)
                {
                    Console.Write("1. Enter email: ");
                    email = Console.ReadLine();
                    if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("First name is null or empty! Try again!");
                        isNormal = false;
                    }
                    else if (email.IndexOf("@") == -1)
                    {
                        Console.WriteLine("User email should contain \"@\"!");
                        isNormal = false;
                    }
                    else if (!UserService.UserExsist(email))
                    {
                        throw new ObjectNotFoundException(email);
                    }
                    else
                    {
                        newLoan.Email = email;
                        isNormal = true;
                    }
                }

                isNormal = false;

                Console.Write("2. Enter \"Loan Amount\": ");
                loanAmount = Convert.ToDouble(Console.ReadLine());
                newLoan.LoanAmount = loanAmount;

                while (!isNormal)
                {
                    Console.Write("3. Enter \"Loan Rate\": ");
                    loanRate = Convert.ToDouble(Console.ReadLine());
                    for (int i = 0; i < loanRates.Length; i++)
                    {
                        if (loanRate == loanRates[i])
                        {
                            newLoan.LoanRate = loanRate;
                            isNormal = true;
                            break;
                        }
                        else
                        {
                            throw new ObjectNotFoundException(Convert.ToString(loanRate));
                        }
                    }
                }

                Console.Write("4. Enter \"Loan Term\": ");
                loanTerm = Convert.ToInt32(Console.ReadLine());
                newLoan.LoanTerm = loanTerm;

                LoanCalculator.Calculate(loanAmount, loanTerm, loanRate);
                Console.WriteLine("Do you agree with the terms of the loan (\"Yes\" or \"No\")?");
                string answer = Console.ReadLine();
                if ((answer != string.Empty || !string.IsNullOrEmpty(answer) || !string.IsNullOrWhiteSpace(answer)) && answer == "Yes")
                {
                    _userLoans.Add(newLoan, email);
                }
                Console.WriteLine("---------------------------------------");
            }
            catch(Exception exceptionInformation)
            {
                Console.WriteLine(exceptionInformation.Message);
            }
        }
    }
}
