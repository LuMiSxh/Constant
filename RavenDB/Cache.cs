using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Cacher
    {
        public Dictionary<object, object> Cache { get; private set; }
        private bool CacheCreated = false;

        public void CreateCatche(Database db)
        {
            if(CacheCreated is true)
            {
                throw new CacheAlreadyInitalizedException();
            }
            CacheCreated = true;

            throw new NotImplementedException("This function is not yet implemented");
        }
    }
}
