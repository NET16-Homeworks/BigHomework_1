using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigHomework_1
{
    internal class ObjectExistsException
    {
        public ObjectExistsException(string objectName)
        {
          try
            {
                throw new Exception($"{objectName} already exists");    
            }
            catch
            {
                throw;
            }
        }
    }
}
