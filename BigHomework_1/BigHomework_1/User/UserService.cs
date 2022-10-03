using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;

namespace BigHomework_1.User
{
    internal class UserService
    {
        private static List<User> userList = new List<User>();

        public void CreateUser()
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            int age = -1;

            Console.WriteLine("1. Enter user Email");

            email = Console.ReadLine();

            if (IsUserExist(email))
            {
                throw new ObjectExistsException(email);
            }
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new IncorrectValueException<string>(email);
            }

            Console.WriteLine("2. Enter user first name");

            firstName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new IncorrectValueException<string>(firstName);
            }

            Console.WriteLine("3. Enter user last name");

            lastName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new IncorrectValueException<string>(lastName);

            }

            Console.WriteLine("4. Enter user age");

            if (int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                throw new IncorrectValueException<int>(age);

            }

            userList.Add(new User(firstName, lastName, email, age));
            Console.WriteLine("Added new user!");



        }

        public void DeleteUser(string email)
        {
            if (!IsUserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            foreach (var user in userList)
            {
                if (user.Email == email)
                {
                    userList.Remove(user);
                    Console.WriteLine($"Sucesfully removed {user.Email} user");
                    return;
                }
            }

        }

        public void UserInfo(string email)
        {
            if (!IsUserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            foreach (var user in userList)
            {
                if (user.Email == email)
                {
                    Console.WriteLine($"First name: {user.FirstName}, Last name: {user.LastName}, Age: {user.Age}, Email: {user.Email}");
                }
            }
        }

        public bool IsUserExist(string email)
        {
            foreach (var user in userList)
            {
                if (user.Email == email) return true;
            }
            return false;
        }
    }
}
