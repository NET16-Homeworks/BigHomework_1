using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class User
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}

        public string Email{get;set;}

        public int Age{get;set;}
        public User(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;  
            LastName = lastName;    
            Email = email;  
            Age = age;  
        }
    }
}
