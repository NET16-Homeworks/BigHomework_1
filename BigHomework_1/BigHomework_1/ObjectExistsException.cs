using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class ObjectExistsException : Exception
    {
        public ObjectExistsException(string ObjectName) : base($"{ObjectName} уже существует")
        { }
    }
}
