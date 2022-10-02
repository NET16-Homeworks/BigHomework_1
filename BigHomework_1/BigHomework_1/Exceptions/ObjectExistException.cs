using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Exceptions
{
    internal class ObjectExistException : Exception
    {
        public ObjectExistException(string objectName) : base($"{objectName} is Already Exist!")
        {

        }
    }
}
