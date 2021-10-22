using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;
using RavenDB.Models;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Database : BaseHandler
    {
        public Database(IConfiguration config)
        {
            // Say how to close the Application -- Setting the functions for it (Functions derive from base class)
            Console.WriteLine("[WARNING] :: Befor closing the application, press ctrl+c to save Cached data!");
            Console.CancelKeyPress += Exit;
            AppDomain.CurrentDomain.ProcessExit += Exit;

            // Initalizing the DocumentStore
            base.DocStore = new DocumentStore
            {
                Certificate = new X509Certificate2((string)Path.GetFullPath(config["RavenDB:Certificate"])),
                Urls = config.GetSection("RavenDB:URLs").Get<string[]>(),
                Database = config["RavenDB:Database"]
            }.Initialize();

            // Setting the DocumentSession
            base.DocSession = DocStore.OpenAsyncSession();
        }

        public async Task<object> GetItem<T>(object Id)
        {
            object Data;
            try
            {
                Data = Cache.Find(Id);
            }
            catch (ObjectNotFoundException)
            {
                Data = await base.Get<T>(Id.ToString());
            }
            return Data;
        }

        public void UpdateItem(IEntity Object)
        {
            Cache.Update(Object);
        }

        public void DeleteItem(IEntity Object)
        {
            try
            {
                Cache.Delete(Object.Id);
            }
            catch (ObjectNotFoundException) { }

            try
            {
                base.DocSession.Delete(Object.Id);
            }
            catch { }
        }

        // Functions that get executed on application Exit
        private async Task ExitAsync()
        {
            foreach (var item in Cache.Cache.Values)
            {
                await DocSession.StoreAsync(item);
            }
            await DocSession.SaveChangesAsync();
        }
        private void Exit(object sender, EventArgs e)
        {
            try
            {
                ExitAsync().GetAwaiter().GetResult();
                Console.WriteLine("Data has been saved");
            }
            catch { }
        }
    }
}