using BigHomework_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;
using BigHomework_1.User;
namespace BigHomework_1.User
{
    internal class UserService
    {
        private static List<User> usersList = new List<User>();

     
        public void CreateUser()
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string email = string.Empty;
            int age = -10;

            bool IsOkay = false;



            while (!IsOkay)
            {
                Console.WriteLine("1. Введите пользовательский Email");
                while (!IsOkay)
                {
                    email = Console.ReadLine();

                    if (UserExist(email))
                    {
                        throw new ObjectExistException(email);
                    }
                    if (String.IsNullOrEmpty(email) || String.IsNullOrWhiteSpace(email))
                    {
                        throw new Exception("Неверно введен email, попробуйте еще раз.");
                    }
                    else
                    {
                        IsOkay = true;
                    }
                }
                IsOkay = false;

                Console.WriteLine("2.Введите Имя пользователя");
                while (!IsOkay)
                {
                    firstName = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrEmpty(firstName))
                    {
                        throw new Exception("Неверное значение Имени. Попробуйте еще раз.");
                    }
                    else
                    {
                        IsOkay = true;
                    }
                }
                IsOkay = false;

                Console.WriteLine("3. Введите фамилию пользователя");
                while (!IsOkay)
                {
                    lastName = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(lastName) || String.IsNullOrEmpty(lastName))
                    {
                        throw new Exception("Неверное значение фамилии. Попробуйте еще раз.");
                    }
                    else
                    {
                        IsOkay = true;
                    }
                }
                IsOkay = false;

                Console.WriteLine("4. Введите возраст пользователя");
                while (!IsOkay)
                {
                    age = int.Parse(Console.ReadLine());
                    if (age <=0)
                    {
                        throw new Exception("Неверное значение Возраста!");
                    }
                    else
                    {
                        IsOkay = true;
                    }
                }
                IsOkay = false;

                try
                {
                    usersList.Add(new User(firstName, lastName, email, age));
                    Console.WriteLine("Добавлен новый пользователь согласно введенным данным");
                    IsOkay = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка - {ex.Message}");
                    Console.WriteLine("Обнаружена ошибка. Пересоздайте пользователя, введя корректные данные.");
                }
            }
        }

        public bool UserExist(string email)
        {
            foreach (var user in usersList)
            {
                if (user.Email == email) 
                    return true;
            }
            return false;
        }

        public void DeleteUser(string email)
        {
            if (!UserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            foreach (var user in usersList)
            {
                if (user.Email == email)
                {
                    usersList.Remove(user);
                    Console.WriteLine($"Успешно удален пользователь с почтой: {user.Email}");
                    return;
                }
            }

        }

        public void WriteUserInfo(string email)
        {
            if (!UserExist(email))
            {
                throw new ObjectNotFoundException(email);
            }

            foreach (var user in usersList)
            {
                if (user.Email == email)
                {
                    Console.WriteLine($"Имя: {user.FirstName}" + Environment.NewLine + $"Фамилия: {user.LastName}" + Environment.NewLine +
                        $"Возраст: {user.Age}" + Environment.NewLine + $"Почта: {user.Email}");
                }
            }
        }
    }
}
