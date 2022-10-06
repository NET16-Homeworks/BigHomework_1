using BigHomework_1;
int enteredNumber = 0;
while (enteredNumber != -1)
{
    Menu();
    Console.WriteLine("Enter number of operation");
    enteredNumber = int.Parse(Console.ReadLine());
    switch (enteredNumber)
    {
        case 1:
            {
                UserService.CreateUser();
                break;
            }
        case 2:
            {
                Console.WriteLine("Enter email of deleted user");
                string email = Console.ReadLine();
                UserService.DeleteUser(email);
                break;
            }
        case 3:
            {
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                UserService.WriteUserInfo(email);
                break;
            }
        case 4:
            {
                LoanManager.SuggestLoan();
                break;
            }
        case 5:
            {
                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();
                LoanManager.PrintInformationAboutUserLoans(email);
                break;
            }
        case -1:
            {
                break;
            }
    }
}
void Menu()
{
    Console.WriteLine(@"1. Add User" + Environment.NewLine +
                       "2. Delete User" + Environment.NewLine +
                       "3. Print Information about User" + Environment.NewLine +
                       "4. Suggest credit" + Environment.NewLine +
                       "5. Print Information About user credits" + Environment.NewLine + 
                       "-1. Enter to exit program");
}