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
            var newUser = new User();
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            int age = 0;
            bool isNormal = false;

            Console.WriteLine("--------------Create User--------------");

            try
            {

                while (!isNormal)
                {
                    Console.Write("1. Enter user first name: ");
                    firstName = Console.ReadLine();
                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("First name is null or empty! Try again!");
                        isNormal = false;
                    }
                    else
                    {
                        newUser.FirstName = firstName;
                        isNormal = true;
                    }
                }

                isNormal = false;
                while (!isNormal)
                {
                    Console.Write("2. Enter user last name: ");
                    lastName = Console.ReadLine();
                    if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Last name is null or empty! Try again!");
                        isNormal = false;
                    }
                    else
                    {
                        newUser.LastName = lastName;
                        isNormal = true;
                    }
                }

                isNormal = false;
                while (!isNormal)
                {
                    Console.Write("3. Enter user age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age < 0)
                    {
                        Console.WriteLine("You entered wrong number! Try again!");
                    }
                    else
                    {
                        newUser.Age = age;
                        isNormal = true;
                    }
                }

                isNormal = false;
                while (!isNormal)
                {
                    Console.Write("4. Enter user email: ");
                    email = Console.ReadLine();
                    if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("First name is null or empty! Try again!");
                        isNormal = false;
                    }
                    else if (email.IndexOf("@") == -1)
                    {
                        Console.WriteLine("User email should contain \"@\"!");
                        isNormal = false;
                    }
                    else
                    {
                        newUser.Email = email;
                        isNormal = true;
                    }
                }

                if (_users.Count > 0)
                {
                    foreach (var user in _users)
                    {
                        if (user.Email == newUser.Email)
                        {
                            throw new ObjectExistsException(user.Email);
                        }
                        else
                        {
                            _users.Add(newUser);
                            Console.WriteLine($"User \"{newUser.FirstName} {newUser.LastName}\" was added!");
                            break;
                        }
                    }
                }
                else
                {
                    _users.Add(newUser);
                    Console.WriteLine($"User \"{newUser.FirstName} {newUser.LastName}\" was added!");
                }
            }
            catch (ObjectExistsException objectExistsExceptionInformation)
            {
                Console.WriteLine(objectExistsExceptionInformation.Message);
            }
            Console.WriteLine("---------------------------------------");
        }

        public static void DeleteUser(string email)
        {
            try
            {
                Console.WriteLine("--------------Delete User--------------");
                if (!UserExsist(email))
                {
                    throw new ObjectNotFoundException(email);
                }
                else
                {
                    foreach (var user in _users)
                    {
                        if (user.Email == email)
                        {
                            _users.Remove(user);
                            break;
                        }
                    }
                }
            }
            catch (ObjectNotFoundException objectnotFoundExceptionInformation)
            {
                Console.WriteLine(objectnotFoundExceptionInformation.Message);
            }
            Console.WriteLine("---------------------------------------");
        }

        public static bool UserExsist(string email)
        {
            foreach (var user in _users)
            {
                if(user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public static void WriteUserInfo(string email)
        {
            Console.WriteLine("--------------Write User Information--------------");
            try
            {
                if (!UserExsist(email))
                {
                    throw new ObjectNotFoundException(email);
                }
                else
                {
                    foreach (var user in _users)
                    {
                        if (user.Email == email)
                        {
                            Console.WriteLine($@"User info:" + Environment.NewLine +
                                                $"First name: {user.FirstName}" + Environment.NewLine +
                                                $"Last name: {user.LastName}" + Environment.NewLine +
                                                $"Age: {user.Age}" + Environment.NewLine +
                                                $"Email: {user.Email}");
                        }
                    }
                }
            }
            catch(ObjectNotFoundException objectNotFoundExceptionInfo)
            {
                Console.WriteLine(objectNotFoundExceptionInfo.Message);
            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}
