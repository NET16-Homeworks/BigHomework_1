namespace BigHomework_1.Helpers
{
    public static class ConsoleHelper
    {
        public static (string, string, string, int) ReadUserInfo()
        {
            Console.Write("Enter FirstName: ");
            var firstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            var lastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            var email = Console.ReadLine();

            Console.Write("Enter Age: ");
            var age = int.Parse(Console.ReadLine());

            return (firstName, lastName, email, age);
        }

        public static (string, double, int, double) ReadUserLoanInfo()
        {
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();

            Console.Write("Enter LoanAmount: ");
            var loanAmount = double.Parse(Console.ReadLine());

            Console.Write("Enter LoanTerm: ");
            var loanTerm = int.Parse(Console.ReadLine());

            Console.Write("Enter LoanRate: (10, 11.5, 13.4) ");
            var loanRate = double.Parse(Console.ReadLine());

            return (email, loanAmount, loanTerm, loanRate);
        }
    }
}
