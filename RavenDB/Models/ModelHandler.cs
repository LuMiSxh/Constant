using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB.Models
{
    public class ModelHandler
    {
        private readonly IConfiguration configuration;

        public ModelHandler(IConfiguration config)
        {
            configuration = config;
        }

        public string Emoji(string NamePath)
        {
            return configuration[$"Emojis:Hitman:{ NamePath }"];
        }
    }
}
