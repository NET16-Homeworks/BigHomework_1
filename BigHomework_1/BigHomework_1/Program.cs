using BigHomework_1.Exceptions;
using BigHomework_1.Loan;
using BigHomework_1.User;
using BigHomework_1.Loan;

class Program
{
    static void Main(string[] args)
    {
        UserService userService = new UserService();

        LoanManager loanManager = new LoanManager();

        while (true)
        {
            string email = String.Empty;
            string chosenKey = String.Empty;
            Console.WriteLine("------------------CREDIT PROGRAM.V7Q.Edition------------------");
            Console.WriteLine("------------------ВЫБЕРИТЕ ОПЦИЮ------------------");
            Console.WriteLine($"1. Добавить Юзера"+Environment.NewLine+"2. Показать информацию о Юзере" + Environment.NewLine + "3. Удалить Юзера" + Environment.NewLine + 
                "4. Кредиты(виды)" + Environment.NewLine + "5. Показать информацию о кредите" + Environment.NewLine + "6. Выйти из приложения");
            chosenKey = Console.ReadLine();
            try
            {
                switch (chosenKey)
                {
                    case "1":
                        userService.CreateUser();
                        break;
                    
                    case "2":
                        Console.WriteLine("Enter user Email");
                        email = Console.ReadLine();
                        userService.WriteUserInfo(email);
                        break;
                    case "3":
                        Console.WriteLine("Enter user Email");
                        email = Console.ReadLine();
                        userService.DeleteUser(email);
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
                        Console.WriteLine("ВЫХОД выполнен успешно");
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
    }
}