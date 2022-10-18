using System;

namespace BigHomework_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool showMenu = true;
                while (showMenu)
                {
                    Menu();
                    Console.Write("Choose a menu item: ");
                    int menuKeyNumber = int.Parse(Console.ReadLine());
                    switch (menuKeyNumber)
                    {
                        case 1:
                            UserService.CreateUser();
                            break;
                        case 2:
                            Console.Write("Enter the email of the user you want to delete: ");
                            string userDeleteEmail = Console.ReadLine();
                            UserService.DeleteUser(userDeleteEmail);
                            break;
                        case 3:
                            Console.Write("Enter the email of the user you want to write info about: ");
                            string userInfoEmail = Console.ReadLine();
                            UserService.WriteUserInfo(userInfoEmail);
                            break;
                        case 4:
                            LoanManager.SuggestLoan();
                            Console.WriteLine("Continue the program (\"Yes\" or \"No\")?");
                            string answer = Console.ReadLine();
                            if (answer == "No")
                            {
                                showMenu = false;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void Menu()
        {
            Console.WriteLine(@"--------------------Menu--------------------" + Environment.NewLine +
                               "1. Add new user" + Environment.NewLine +
                               "2. Delete user" + Environment.NewLine +
                               "3. Write user information" + Environment.NewLine +
                               "4. Suggest new loan" + Environment.NewLine +
                               "--------------------------------------------");
        }
    }
}