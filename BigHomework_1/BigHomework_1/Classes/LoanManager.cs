using BigHomework_1.Exceptions;
using BigHomework_1.Services;
using BigHomework_1.Utils;

namespace BigHomework_1.Classes
{
    internal class LoanManager
    {
        private static Dictionary<string, List<Loan>> _userLoans = new();
        private double[] _loanRates;
        private UserService _userService = new();
        private ConsoleHelper _consoleHelper = new();
        public LoanManager(double[] loanRates)
        {
            _loanRates = loanRates;
        }

        public void SuggestLoan(string email)
        {
            if (!_userService.UserExists(email))
            {
                throw new ObjectNotFoundException(email);
            }

            Loan newLoan = CreateLoan(email);
            GetDetailedLoanPayments(newLoan);

            string input = _consoleHelper.ReadString("Are you sure, you want to proceed? [y/n]");

            if (input == "y")
            {
                if (_userLoans.ContainsKey(email))
                {
                    _userLoans[email].Add(newLoan);
                    return;
                }

                _userLoans.Add(email, new List<Loan> { newLoan });
            }
        }
        private void GetDetailedLoanPayments(Loan loan)
        {
            var percents = loan.LoanAmount * (loan.LoanRate / 100);
            var summ = loan.LoanAmount;

            for (int i = loan.LoanTerm; i > 0 ; i--)
            {
                var amount = LoanCalculator.Calculate(summ, i, loan.LoanRate);
                var loanLeft = summ - amount;
                Console.WriteLine($"Month #{i}: ");
                Console.WriteLine($"Payment: {amount + percents}");
                Console.WriteLine($"Loan left: {loanLeft}");

                summ = loanLeft;
                percents = loanLeft * (loan.LoanRate / 100);
            }
        }
        private Loan CreateLoan(string email)
        {
            double loanAmount = _consoleHelper.ReadDouble("Enter loan amount: ");
            int loanTerm = _consoleHelper.ReadInt("Enter loan term: ");
            double loanRate = _consoleHelper.ReadDouble("Enter loan rate: ");

            if (!_loanRates.Contains(loanRate))
            {
                throw new ObjectNotFoundException(loanRate.ToString());
            }

            return new Loan(loanAmount, loanTerm, loanRate, email);
        }
    }
}