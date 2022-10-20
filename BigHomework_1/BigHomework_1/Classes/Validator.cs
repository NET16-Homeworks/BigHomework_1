using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Classes
{
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
