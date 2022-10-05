using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BigHomework_1
{
    internal class UserService
    {
        static public List<User> Users = new List<User>()
        {
           new User("Иван","Иванов","ivanov@com",21),
           new User("Петр","Петров","petrov@com",27),
           new User("Лена", "Ленина","lena@com", 32)
        };

        public bool CreateUser()
        {
            bool f = true;
            try
            {
                string sName = "";
                do
                {
                    Console.WriteLine("Введите имя");
                    sName = (Console.ReadLine()).Trim();
                    if (sName.Length == 0) { Console.WriteLine("Имя не может быть пустым"); }
                } while (sName.Length == 0);

                string sLastName = "";
                do
                {
                    Console.WriteLine("Введите фамилию");
                    sLastName = (Console.ReadLine()).Trim();
                    if (sLastName.Length == 0) { Console.WriteLine("Имя не может быть пустым"); }
                } while (sLastName.Length == 0);

                string sEmail = EnterEmail(" добавляемого пользователя");
                if (UserExists(sEmail))
                {
                bool fInt = false;
                int Age = 18;
                do
                {   Console.WriteLine("Введите возраст (целое число лет между 18 и 70 годами");
                    string? sAge = Console.ReadLine();
                    fInt = Int32.TryParse(sAge, out var iAge);
                    if (!fInt) { Console.WriteLine("Возраст должен быть целым числом от 18 и 70"); }
                    else { Age = iAge; }
                } while (!fInt || Age < 18 || Age > 70);
                
                    User user = new User(sName, sLastName, sEmail, Age);
                    Users.Add(user);
                }
                else { ObjectExistsException objectExistsException = new ObjectExistsException(sEmail); }

            }
            catch (Exception E)
            {
                f = false;
                throw;
            }
            return f;

        }

        public bool DeleteUser()
        {
            bool f = true;
            string sEmail = String.Empty;
            try
            {
                if (Users.Count > 0)
                {
                    sEmail = EnterEmail(" удаляемого пользователя");

                    if (UserExists(sEmail)) 
                    {
                        int i = Users.FindIndex(p => p.Email == sEmail);
                        Users.RemoveAt(i);
                    }
                    else
                    {
                        ObjectNotFoundException objectNotFoundException = new ObjectNotFoundException(sEmail);
                    }
                }
                else
                {
                    Console.WriteLine("Список доступных пользователей пуст.");
                }
            }
            catch (Exception E)
            {
                f = false;
                throw;
            }
            return f;
        }

        public bool WriteUserInfo()
        {
            bool f = true;
            string sEmail = String.Empty;
            try
            {
                if (Users.Count > 0)
                {
                    sEmail = EnterEmail(", информацию о котором вы хотите получить");
                    if (UserExists(sEmail))
                    {
                        var item = Users.Find(p => p.Email == sEmail);
                        Console.WriteLine($"Имя: {item.FirstName}; Фамилия: {item.LastName}; Email: {item.Email}; Возраст: {item.Age}");
                    }
                    else
                    {
                        ObjectNotFoundException objectNotFoundException = new ObjectNotFoundException(sEmail);
                    }
                }
                else
                {
                    Console.WriteLine("Список доступных пользователей пуст.");
                }
            }
            catch (Exception E)
            {
                f = false;
                throw;
            }
            return f;
        }

        static public bool UserExists(string sEmail)
        {
            bool f = false;
            if (!String.IsNullOrEmpty(sEmail))
            {
                if (Users.Exists(p => p.Email == sEmail.Trim()))
                {
                    f = true;
                }

            }

            return f;
        }

        static public string EnterEmail(string sQuery)
        {
            string s = String.Empty;
            do
            {
                Console.WriteLine("Введите Email пользоватля"+ sQuery);
                s = (Console.ReadLine()).Trim();
                if (s.Length == 0) { Console.WriteLine("Email не может быть пустым"); }
                else if (s.IndexOf("@") == 0) { Console.WriteLine("Email должен содержать символ '@'"); }
            } while (s.Length == 0 || s.IndexOf("@") == 0);
            return s;
        }
    }
}

    