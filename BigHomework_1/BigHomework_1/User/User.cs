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
        private static UserService userService = new UserService();

        private int _age;
        private string _email;

        public User(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email 
        {
            get { return _email;  }
            set 
            {
                if (userService.IsUserExist(value)) throw new ObjectExistsException(value);
                else _email = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set 
            {
                if (value <= 0) throw new IncorrectValueException<int>(value);
                else _age = value;
            }
        }
    }
}
