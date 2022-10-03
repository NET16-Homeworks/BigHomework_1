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

        public User(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
        
    }
}
