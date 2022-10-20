using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Entities;
using BigHomework_1.Exceptions;

namespace BigHomework_1.Services
{
    internal class UserService
    {
        private static List<User> _users = new List<User>();
        public void CreateUser()
        {
            var user = new User();

            Console.Write("Введите имя: ");
            user.FirstName = InputCheckMethods.StringReadAndCheck();

            Console.Write("Введите фамилию: ");
            user.LastName = InputCheckMethods.StringReadAndCheck();

            Console.Write("Введите e-mail: ");
            user.Email = InputCheckMethods.StringReadAndCheck();

            Console.Write("Введите возраст: ");
            user.Age = InputCheckMethods.IntReadAndCheck();

            var ifUserExists = _users.Exists(q => q.Email == user.Email);
            if (ifUserExists)
            {
                throw new ObjectExistsException(user.Email);
            }

            _users.Add(user);

            //Console.WriteLine($"{user.FirstName} {user.LastName} {user.Email} {user.Age}");
        }

        public void DeleteUser()
        {
            string? input = EmailInputCheck();

            _users.RemoveAll(q => q.Email == input);
        }

        public void WriteUserInfo()
        {
            string? input = EmailInputCheck();

            User? user = new User();
            user = _users.Find(q => q.Email == input);

            Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Email: {user.Email}, Age: {user.Age}");
        }

        public bool UserExists(string email)
        {
            var ifUserFound = _users.Exists(q => q.Email == email);
            return ifUserFound;
        }
        public string EmailInputCheck()
        {
            Console.WriteLine("Введите e-mail пользователя");
            string? input = InputCheckMethods.StringReadAndCheck();

            if (!UserExists(input))
            {
                throw new ObjectNotFoundException(input);
            }

            return input;
        }
    }
}
