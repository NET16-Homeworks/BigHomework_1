using BigHomework_1;
const string actUser = "1,2,3,4";
const string actApp = "1,2";

UserService user = new UserService();
LoanManager manager = new LoanManager();

while (true)
{
    string ch = "0";
    Console.WriteLine("выберете действие:");
    Console.WriteLine("1 - добавить пользователя; 2 - удалить пользователя; 3 - вывод информации о пользовтаеле; 4 - предложить кредит");
    do
    {
        ch = Console.ReadKey(true).KeyChar.ToString();
    } while (!actUser.Contains(ch));
    try
    {
        switch (ch)
        {
            case "1":
                user.CreateUser();
                break;
            case "2":
                user.DeleteUser();
                break;
            case "3":
                user.WriteUserInfo();
                break;
            case "4":
                manager.SuggestLoan();
                break;
        }
    }
    catch (Exception E)
    {
        Console.WriteLine($"Ошибка: {E.Message}");
    }

    Console.WriteLine("Для продолжения работы нажмите 1, для завершения работы нажмите 2");
    ch ="0";
    do
    {
        ch = Console.ReadKey(true).KeyChar.ToString();
    } while (!actApp.Contains(ch));
    if (ch == "2") { Environment.Exit(0); }
}