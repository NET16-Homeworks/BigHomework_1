using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1.Exceptions
{
        internal class ObjectNotFoundException : Exception
        {
            public ObjectNotFoundException(string objectName) : base($"The object wasn’t found")
            {

            }
        }
    }

