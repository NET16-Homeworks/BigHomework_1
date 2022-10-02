using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Exceptions
{
    internal class InvalidValueException<T> : Exception
    {
        public InvalidValueException(T @object) : base($"Invalid value - \"{@object}\"")
        {

        }
    }
}
