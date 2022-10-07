using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message): base(message)
        {

        }

        //public ObjectNotFoundException(ObjectNotFoundException ex)
        //{
        //}

        public string Exception(Exception objectName)
        {
            return $"{objectName} already exists";
        }
    }
}
