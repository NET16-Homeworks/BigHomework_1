using BigHomework_1.Classes;
using BigHomework_1.Utils;
using BigHomework_1.Exceptions;

namespace BigHomework_1.Services
{
    internal class UserService
    {
        private static List<User> _users = new();
        private ConsoleHelper _consoleHelper = new();

        public void CreateUser()
        {
            string firstName = _consoleHelper.ReadString("Enter first name: ");
            string lastName = _consoleHelper.ReadString("Enter last name: ");
            int age = _consoleHelper.ReadInt("Enter age: ");
            string email = _consoleHelper.ReadString("Enter e-mail: ");

            if (UserExists(email))
            {
                throw new ObjectExistsException(email);
            }

            _users.Add(new User(firstName, lastName, email, age));
        }

        public void DeleteUser(string email)
        {
            User? user = GetUserByEmail(email);

            if (user == null)
            {
                throw new ObjectNotFoundException(email);
            }

            _users.Remove(user);
        }

        public void WriteUserInfo(string email)
        {
            User? user = GetUserByEmail(email);

            if (user == null)
            {
                throw new ObjectNotFoundException(email);
            }

            Console.WriteLine(
                @$"User info: 
                Name: {user.FirstName} {user.LastName}
                Age: {user.Age}
                E-mail: {user.Email}
                ");
        }

        public bool UserExists(string email)
        {
            return _users.Exists(user => user.Email == email);
        }

        private User? GetUserByEmail(string email)
        {
            return _users.Find(x => x.Email == email);
        }
    }
}
