using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Threading.Tasks;

namespace RavenDB
{
    public class BaseHandler
    {
        // Declaring Variables
        public IDocumentStore DocStore { get; set; }
        public IAsyncDocumentSession DocSession { get; set; }

        public Cacher Cache = new(); // Creates the Cache -- Minimises the Database Usage

        // Defining private functions
        public async Task<object> Get<T>(string Id)
        {
            return await DocSession.LoadAsync<T>(Id);
        }

        public void Delete(string Id)
        {
            DocSession.Delete(Id);
        }

        public async Task SaveChanges()
        {
            await DocSession.SaveChangesAsync();
        }

        public async Task Store(object O)
        {
            await DocSession.StoreAsync(O);
        }
    }
}
