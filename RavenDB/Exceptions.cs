using System;

namespace RavenDB
{
    public class CacheAlreadyInitalizedException : Exception
    {
        public CacheAlreadyInitalizedException() { }
    }

    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() { }
    }
}
