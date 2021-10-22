using RavenDB.Models;
using System.Collections.Generic;

namespace RavenDB
{
    public class Cacher
    {
        // Declaring Variables
        public readonly Dictionary<object, object> Cache;

        // Creating Dict
        public Cacher()
        {
            Cache = new Dictionary<object, object>();
        }

        public object Find(object Id)
        {
            if (Cache.ContainsKey(Id.ToString()))
            {
                return Cache[Id];
            }
            throw new ObjectNotFoundException();
        }

        public void Update(IEntity Object)
        {
            Cache[Object.Id] = Object;
        }

        public void Delete(object Id)
        {
            if (Cache.ContainsKey(Id.ToString()))
            {
                Cache.Remove(Id.ToString());
            }
            throw new ObjectNotFoundException();
        }
    }
}
