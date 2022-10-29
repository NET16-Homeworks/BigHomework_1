using BigHomework_1.Exceptions;
using BigHomework_1.Helpers;
using BigHomework_1.Services;

namespace BigHomework_1
{
    public sealed class LoanManager
    {
        private static UserService _userService = new UserService();
        private static Dictionary<string, List<Loan>> _userLoans = new Dictionary<string, List<Loan>>();
        private static double[] _loanRate = { 10, 11.5, 13.4 };

        public void SuggestLoan()
        {
            (string email, double loanAmount, int loanTerm, double loadRate) userLoanInfo
                = ConsoleHelper.ReadUserLoanInfo();

            var isUserExists = _userService.UserExists(userLoanInfo.email);
            if (isUserExists == false)
            {
                throw new ObjectNotFoundException(userLoanInfo.email);
            }

            var isLoanTermExists = _loanRate.Contains(userLoanInfo.loadRate);
            if (isLoanTermExists == false)
            {
                throw new ObjectNotFoundException(userLoanInfo.loadRate.ToString());
            }

            ShowLoanInfo(userLoanInfo.loanAmount, userLoanInfo.loanTerm, userLoanInfo.loadRate);

            Console.WriteLine("Are you agree? (y/n)");
            var answer = Console.ReadLine();

            if (answer == "y")
            {
                var loan = new Loan
                {
                    Email = userLoanInfo.email,
                    LoanAmount = userLoanInfo.loanAmount,
                    LoanTerm = userLoanInfo.loanTerm,
                    LoanRate = userLoanInfo.loadRate
                };

                AddLoan(loan);
            }
        }

        private void AddLoan(Loan loan)
        {
            if (_userLoans.ContainsKey(loan.Email))
            {
                _userLoans[loan.Email].Add(loan);
            }
            else
            {
                _userLoans.Add(loan.Email, new List<Loan> { loan });
            }
        }

        private void ShowLoanInfo(double loanAmount, int loanTerm, double loanRate)
        {
            //var P = loanRate / 100 / 12;
            var startAmount = loanAmount;
            for (int i = loanTerm; i > 0; i--)
            {
                var payment = LoanCalculator.Calculate(startAmount, i, loanRate);
                var loanLeft = startAmount - payment;// + startAmount * P;

                Console.WriteLine($"Month number: {i}");
                Console.WriteLine($"Payment: {payment}");
                Console.WriteLine($"LoanLeft: {loanLeft}");

                startAmount = loanLeft;
            }
        }
    }
}
