using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class CacheAlreadyInitalizedException : Exception
    {
        public CacheAlreadyInitalizedException()
        {

        }

        public CacheAlreadyInitalizedException(string message)
            : base(message)
        {

        }
    }
}
