using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Exceptions
{
    internal class IncorrectValueException<T> : Exception
    {
        public IncorrectValueException(T value) : base($"Incorrect value - \"{value}\"")
        {

        }
    }
}
