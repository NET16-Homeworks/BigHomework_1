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

        public string Email
        {
            get => _email;
            set => _email = value;
    }

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

    public static class Validator
    {
        public static bool ValidateEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@') || !value.Contains('.'))
            {
                return false;
            }

            return true;
        }
    }
}
