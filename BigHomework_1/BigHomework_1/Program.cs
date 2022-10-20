using BigHomework_1.Entities;
using BigHomework_1.Exceptions;
using BigHomework_1.Services;
using System.ComponentModel.Design;
using System.Diagnostics;

var userService = new UserService();
var loanManager = new LoanManager();
bool isContinued = true;

while (isContinued)
{
    Console.WriteLine("Выберите операцию:\n1.Добавить пользователя\n2.Удалить пользователя\n3.Вывести информацию о пользователе\n4.Предложить кредит");
    bool flag = int.TryParse(Console.ReadLine(), out var choice);
    if (!flag)
    {
        throw new InvalidInputException();
    }

    switch (choice)
    {
        case 1:
            userService.CreateUser();
            break;
        case 2:
            userService.DeleteUser();
            break;
        case 3:
            userService.WriteUserInfo();
            break;
        case 4:
            loanManager.SuggestedLoan();
            break;
        default:
            Console.WriteLine("Данная операция не существует!");
            break;
    }

    Console.WriteLine("Желаете продолжить работу? (да/нет)");
    string input = InputCheckMethods.StringReadAndCheck();
    input.Trim()
         .ToLower();

    if (input == "нет")
    {
        isContinued = false;
    }
}