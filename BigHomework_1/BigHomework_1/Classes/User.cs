using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigHomework_1.Exceptions;
using BigHomework_1.UserService;

namespace BigHomework_1.Classes
{
    internal class User
    {
        private static UserServ userService = new UserServ();
        private int _age;
        private string _email;
        public User(string firstName, string lastName, string email, int age)
        {
            LastName = lastName;
            Email = email;
            Age = age;
            FirstName = firstName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //add unique e-mail
        public string Email
        {
            get => _email;
            set
            {
                if (value == " " && !value.Contains('@') && !value.Contains('.'))
                {
                    throw new Exception("The e-mail is incorrect or already exists.");
                }

                if (userService.DoesUserExist(value))
                {
                    throw new ObjectExistsException(value);                    
                }

                else
                {
                    _email = value;
                }
            }
    }


        //unique e-mail?? how

        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 17)
                {
                    throw new ArgumentException ("Could not be completed. You should turn 18.");
                }
                else
                {
                    _age = value;
                }
            }
        }
    }
}
