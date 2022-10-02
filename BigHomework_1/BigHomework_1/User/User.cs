using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;
namespace BigHomework_1.User
{
    internal class User
    {

        private int _age;
        private string _email;

        private static UserService userService = new UserService();
        public User(string firstname, string lastName, string email, int age)
        {
            FirstName = firstname;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value) || userService.UserExist(value))
                {
                    throw new ObjectExistException(value);
                }
                else
                {
                    _email = value;
                }
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidValueException<int>(value);

                } 
                else
                {
                    _age = value;
                }
                
            }

        }
    }
}
