using BigHomework_1.Exceptions;
using BigHomework_1.Loan;
using BigHomework_1.User;
using BigHomework_1.Loan;

UserService userService = new UserService();
LoanManager loanManager = new LoanManager();



while (true)
{
    string email = String.Empty;
    string option = String.Empty;
    Console.WriteLine("Welcome to MikrokredytyBezObmana!");
    Console.WriteLine("Select your option!");
    Console.WriteLine(@"
1. Add user
2. Delete user
3. Register user
4. Apply for a loan
5. Show user loan
6. Exit
");
    option = Console.ReadLine();
    try
    {
        switch (option)
        {
            case "1":
                userService.CreateUser();
                break;
            case "2":
                Console.WriteLine("Enter user Email");
                email = Console.ReadLine();
                userService.DeleteUser(email);
                break;
            case "3":
                Console.WriteLine("Enter user Email");
                email = Console.ReadLine();
                userService.RegisterUser(email);
                break;
            case "4":
                loanManager.SuggestLoan();
                break;
            case "5":
                Console.WriteLine("Enter user Email");
                email = Console.ReadLine();
                loanManager.ShowLoan(email);
                break;
            case "6":
                Console.WriteLine("Thanks for choosing us!");
                return;
                
            default:
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
   
}

