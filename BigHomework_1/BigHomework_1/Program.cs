using BigHomework_1;

//LoanCalculator.Calculate(1000.00, 10, 0.00001);


int response = 0;
while (response != 6)
{
    Console.WriteLine("Выберите действие (от 1 до 6):" + Environment.NewLine +
    "1. Добавить пользователя" + Environment.NewLine +
    "2. Удалить пользователя" + Environment.NewLine +
    "3. Получить информацию о пользователе" + Environment.NewLine +
    "4. Предложить кредит" + Environment.NewLine +
    "5. Получить информацию о кредитах пользователя" + Environment.NewLine +
    "6. Выход");
    try
    {
        response = int.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Menu number_operation = (Menu)response;
    

    switch (number_operation)
    {
        case Menu.Add:
            {
                UserService.CreateUser();
                break;
            }

        case Menu.Remove:
            {
                UserService.DeleteUser();
                break;
            }

        case Menu.PrintUser:
            {
                UserService.WriteUserInfo();
                break;
            }

        case Menu.Credit:
            {
                LoanManager.SuggestLoan();
                break;
            }

        case Menu.PrintLoan:
            {
                LoanManager.PrintLoan();
                break;
            }

        case Menu.Exit:
            {
                Console.WriteLine("Выход из программы");
                break;
            }
        default:
            {
                Console.WriteLine("Не верно. Введите цифру от 1 до 6");
                break;
            }
    }

    Console.ReadKey();
}
