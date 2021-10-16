using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Database
    {
        public readonly IDocumentStore DocStore;
        public readonly IAsyncDocumentSession DocSession;


        public Database(IConfiguration config)
        {
            // Say how to close the Application -- Setting the functions for it
            Console.WriteLine("[WARNING] :: Only close the Program by pressing CTRL+C otherwise the Database changes wont  be saved!");
            Console.CancelKeyPress += this.Exit;
            AppDomain.CurrentDomain.ProcessExit += this.Exit;

            // Initalizing the DocumentStore
            DocStore = new DocumentStore
            {
                Certificate = new X509Certificate2((string)Path.GetFullPath(config["RavenDB:Certificate"])),
                Urls = config.GetSection("RavenDB:URLs").Get<string[]>(),
                Database = config["RavenDB:Database"]
            }.Initialize();

            DocSession = DocStore.OpenAsyncSession();
        }

        public async Task<object> Get<T>(string Id)
        {
            return await DocSession.LoadAsync<T>(Id);
        }

        public async Task Delete(string Id)
        {
            DocSession.Delete(Id);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await DocSession.SaveChangesAsync();
        }

        public async Task Store(object O)
        {
            await DocSession.StoreAsync(O);
        }

        public async Task StoreAndSave(object O)
        {
            await DocSession.StoreAsync(O);
            await DocSession.SaveChangesAsync();
        }
        private void Exit(object sender, EventArgs e)
        {
            SaveChanges().GetAwaiter().GetResult();
        }
    }
}