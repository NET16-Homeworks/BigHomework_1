using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class UserService
    {
        private static List<User> _users = new List<User>();
        public static void CreateUser()
        {
            Console.WriteLine("==========Creating User==========");
            Console.WriteLine("Enter information about user:\nFirst Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.Age = age;
            if (_users.Count == 0)
            {
                _users.Add(user);
            }
            else
            {
                foreach (var item in _users)
                {
                    if (item.Email == email)
                    {
                        throw new ObjectExistsException(user.Email);
                    }
                }
                _users.Add(user);
            }
        }
        public static void DeleteUser(string email)
        {
            foreach (var userElement in _users)
            {
                if (userElement.Email == email)
                {
                    _users.Remove(userElement);
                }
                else
                {
                    throw new ObjectNotFoundException(email);
                }
            }
        }
        public static void WriteUserInfo(string email)
        {
            bool isContain = false;
            foreach (var userElement in _users)
            {
                if (userElement.Email == email)
                {
                    Console.WriteLine($"FirstName: {userElement.FirstName}, LastName: {userElement.LastName}, Email: {userElement.Email}, Age: {userElement.Age}");
                    isContain = true;
                }
            }
            if (!isContain)
            {
                throw new ObjectNotFoundException(email);
            }
        }
        public static bool UserExists(string email)
        {
            foreach (var userElement in _users)
            {
                if (userElement.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
