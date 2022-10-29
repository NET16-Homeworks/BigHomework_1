using BigHomework_1.Enums;
using BigHomework_1.Services;

namespace BigHomework_1
{
    static class Programm
    {
        public static void Main(string[] args)
        {
            MenuItem? menuItem = null;
           
            while (menuItem != MenuItem.Exit)
            {
                MenuDescription();
                menuItem = Enum.Parse<MenuItem>(Console.ReadLine());

                Menu(menuItem);
            }
        }

        public static void MenuDescription()
        {
            Console.WriteLine("========MENU========");
            Console.Write("0. AddUser" + Environment.NewLine +
                          "1. DeletUser" + Environment.NewLine +
                          "2. UserInfo" + Environment.NewLine +
                          "3. SuggestLoan" + Environment.NewLine +
                          "4. Exit" + Environment.NewLine);
        }

        public static void Menu(MenuItem? menuItem)
        {
            var userService = new UserService();
            var loanManager = new LoanManager();

            switch (menuItem)
            {
                case MenuItem.CreateUser:
                    {
                        userService.CreateUser();
                        break;
                    }
                case MenuItem.DeleteUser:
                    {
                        Console.Write("Enter email: ");
                        var email = Console.ReadLine();
                        userService.DeleteUser(email);
                        break;
                    }
                case MenuItem.WriteUserInfo:
                    {
                        Console.Write("Enter email: ");
                        var email = Console.ReadLine();
                        userService.WriteUserInfo(email);
                        break;
                    }
                case MenuItem.SuggestLoan:
                    {
                        loanManager.SuggestLoan();
                        break;
                    }
                case MenuItem.Exit:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You entered strong menuItem!");
                        break;
                    }
            }
        }
    }
}