using BigHomework_1.Classes;
using BigHomework_1.Loans;
using BigHomework_1.UserService;
using BigHomework_1.LoanService;


UserServ newUser = new UserServ();
//не находит юзера:

LoanManager loanManager = new LoanManager();

int menu = 0;
string email = String.Empty;
while (menu != 5)
{
    Console.WriteLine("------------Menu------------");
    Console.WriteLine("\t1. Adding a user." + Environment.NewLine +
                "\t2.Removal of user." + Environment.NewLine +
                "\t3.Information about the user." + Environment.NewLine +
                "\t4. Loans order" + Environment.NewLine +
                "\t5. Press 5 to quit the application.");

    Console.WriteLine("Please select the item.");
    menu = int.Parse(Console.ReadLine());
    try
    {
        switch (menu)
        {
            case 1:
                {
                    newUser.CreateUser();
                    break;
                }

            case 2:
                {
                    Console.WriteLine($"Please type e-mail of the user you want to remove:");
                    email = Console.ReadLine();
                    newUser.DeleteUser(email);
                    break;
                }

            case 3:
                {
                    Console.WriteLine($"Please type e-mail of the user you want to get info of:");
                    email = Console.ReadLine();
                    newUser.GetUserInfo(email);
                    break;
                }

            case 4:
                {
                    loanManager.SuggestLoan();
                    break;
                }

            case 5:
                {
                    Console.WriteLine("You quited the application");
                    break;
                }
            default:
                {
                    Console.WriteLine("Wrong items chosen. Please try again");
                    break;
                }
        }
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}

