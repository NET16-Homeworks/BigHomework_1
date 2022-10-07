using BigHomework_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Classes;
using BigHomework_1.Exceptions;

namespace BigHomework_1.UserService
{
    internal class UserServ
    {

        private static List<User> _users = new List<User>();

        public void CreateUser()
        {
            //нкжно ли это переносить в програм и создавать там объект юзера?
            Console.WriteLine($"Please type your firstname:");
            string FirstName = Console.ReadLine();
            Console.WriteLine($"Please type your lastname:");
            string LastName = Console.ReadLine();
            Console.WriteLine($"Please type your e-mail:");
            string Email = Console.ReadLine();

            Console.WriteLine($"Please type your age:");
            int Age = int.Parse(Console.ReadLine());

                if (FirstName is not null && LastName is not null && Email is not null && Age != 0)
                {
                    _users.Add(new User(FirstName, LastName, Email, Age));
                    Console.WriteLine("The user has been added");
                }

                else
                {
                    Console.WriteLine("Please fill in all the fields to add the user");
                    //как вернуться к методу чтобы дать возм-ть вести информацию юзеру еще раз?
                }
            }


        public void DeleteUser(string email)
        {
            User user = null;
            if (!DoesUserExist(email))
            {
                throw new ObjectNotFoundException("There is no such user in the system");
            }
            else

            {
                foreach (var userr in _users)
                {
                    if (userr.Email == email)
                    {
                        user = userr;
                        break;
                    }
                }
                _users.Remove(user);
                Console.WriteLine($"{user.FirstName}, {user.LastName}, {user.Email} has been deleted from the system");
            }
        }
 
        public void GetUserInfo(string email)
        {
            if (!DoesUserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            else
            {

            foreach (var user in _users)
                {
                    if (user.Email == email)
                    {
                        Console.WriteLine($"FirstName: {user.FirstName}, lastname: {user.LastName}, " +
    $"Email: {user.Email}, Age: {user.Age}");
                    }
                }
            } 
        }

        public bool DoesUserExist(string email)
        {
            foreach (var user in _users)
            {
                if (user.Email == email)
                    return true;
            }
            return false;
        }
    }
}