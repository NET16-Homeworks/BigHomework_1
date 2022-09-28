using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Exceptions
{
    internal class ObjectExistsException : Exception
    {
        public ObjectExistsException(string objectName) : base($"{objectName} already exist")
        {

        }
    }
}
