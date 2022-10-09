using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class ObjectNotFoundException
    {
        public ObjectNotFoundException(string objectName)
        {
            try
            {
                throw new Exception($"{objectName} wasn’t found");
            }
            catch
            {
                throw;
            }
        }
    }
}
