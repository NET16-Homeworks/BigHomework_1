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

            bool isTaskCompletedSucess = false;
            while (!isTaskCompletedSucess)
            {


                Console.WriteLine("1. Enter user Email");
                while (!isTaskCompletedSucess)
                {
                    email = Console.ReadLine();

                    if (IsUserExist(email))
                    {
                        throw new ObjectExistsException(email);
                    }
                    if (!String.IsNullOrWhiteSpace(email))
                    {
                        isTaskCompletedSucess = true;
                    }
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("2. Enter user first name");
                while (!isTaskCompletedSucess)
                {
                    firstName = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(firstName))  isTaskCompletedSucess = true; 
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("3. Enter user last name");
                while (!isTaskCompletedSucess)
                {
                    lastName = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(lastName))  isTaskCompletedSucess = true; 
                }
                isTaskCompletedSucess = false;

                Console.WriteLine("4. Enter user age");
                while (!isTaskCompletedSucess)
                {
                    if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    {
                        isTaskCompletedSucess = true;
                    }              
                }
                isTaskCompletedSucess = false;
                try
                {
                    userList.Add(new User(firstName, lastName, email, age));
                    Console.WriteLine("Added new user!");
                    isTaskCompletedSucess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong, please, try to register new user again");
                    Console.WriteLine($"Exception - {ex.Message}");
                }

            }
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
