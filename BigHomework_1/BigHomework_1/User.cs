using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    public sealed class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"FullName: {FirstName} {LastName}, Email: {Email}, Age: {Age}";
        }
    }
}
