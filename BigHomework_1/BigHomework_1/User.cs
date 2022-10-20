using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class User
    {
        public int _age;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public User(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 18)
                {
                    _age = 18;

                }
                else
                {
                    _age = value;
                }
            }


        }
    }
}
