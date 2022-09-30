namespace BigHomework_1.Classes
{
    internal class Loan
    {
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public double LoanRate { get; set; }
        public string Email { get; set; }

        public Loan(double loanAmount, int loanTerm, double loanRate, string email)
        {
            LoanAmount = loanAmount;
            LoanTerm = loanTerm;
            LoanRate = loanRate;
            Email = email;
        }
    }
}
