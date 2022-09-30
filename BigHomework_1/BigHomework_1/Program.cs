using BigHomework_1.Enums;
using BigHomework_1.Utils;
using BigHomework_1.Services;
using BigHomework_1.Classes;

Menu();

void Menu()
{
    ConsoleHelper _consoleHelper = new();
    UserService _userService = new();
    LoanManager _loanManager = new(new[] { 10, 11.5, 13.4 });
    MenuItem? selectedMeunItem = null;

    while (selectedMeunItem != MenuItem.Close)
    {
        GetMenuDescription();
        selectedMeunItem = (MenuItem)_consoleHelper.ReadInt("Select menu item: ");

        switch (selectedMeunItem)
        {
            case MenuItem.AddUser: _userService.CreateUser();
                break;
            case MenuItem.DeleteUser: DeleteUser();
                break;
            case MenuItem.UserInfo: GetUserInfo();
                break;
            case MenuItem.SuggestLoan: SuggestLoan();
                break;
            case MenuItem.Close: return;
            default:
                Console.WriteLine("Invalid menu select!");
                break;
        }
    }

    void GetMenuDescription()
    {
        Console.WriteLine("1. Add new user");
        Console.WriteLine("2. Delete user");
        Console.WriteLine("3. User info");
        Console.WriteLine("4. Suggest loan");
        Console.WriteLine("5. Close programm");
    }
    void DeleteUser()
    {
        string email = _consoleHelper.ReadString("Enter users e-mail: ");
        _userService.DeleteUser(email);
    }
    void GetUserInfo()
    {
        string email = _consoleHelper.ReadString("Enter users e-mail: ");
        _userService.WriteUserInfo(email);
    }
    void SuggestLoan()
    {
        string email = _consoleHelper.ReadString("Enter users e-mail: ");
        _loanManager.SuggestLoan(email);
    }
}