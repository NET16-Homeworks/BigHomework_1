using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class UserService
    {
        private static List<User> userList = new List<User>();

        private static UserService userService = new UserService();

        public static void CreateUser()
        {
            Console.WriteLine("Добавление нового пользователя. Введите фамилию:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Имя:");
            string firsName = Console.ReadLine();
            Console.WriteLine("Количество полных лет:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            if (UserExists(email))
            {
                throw new ObjectExistsException(email);
            }
            else
            {
                userList.Add(new User(firsName, lastName, email, age));
                Console.WriteLine($"Пользователь '{email}' добавлен");
            }
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Введите email пользователя для удаления:");
            string email = Console.ReadLine();
            if (!UserExists(email))
            {
                throw new ObjectNotFoundException(email);
            }
            foreach (var user in userList)
            {

                if (user.Email == email)
                {
                    userList.Remove(user);
                    Console.WriteLine($"Позователь {email} удален");
                    return;
                }

            }
        }

        public static void WriteUserInfo()
        {
            Console.WriteLine("Введите email пользователя для получения информации:");
            string email = Console.ReadLine();
            foreach (var user in userList)
            {
                if (user.Email == email)
                {
                    Console.WriteLine($"Пользователь: {user.LastName} {user.FirstName}, возраст: {user.Age}, email: {user.Email} ");
                    return;
                }
                else
                {
                    throw new ObjectNotFoundException(email);
                }

            }
        }

        public static bool UserExists(string email)
        {
            foreach (var user in userList)
            {
                if (user.Email == email) return true;
            }
            return false;
        }



    }
}
