using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RestChallenge.Context
{
    public class DapperContext
    {
        //create a conn string get a con string
        private readonly IConfiguration config;
        public DapperContext(IConfiguration config)
        {
            this.config = config;

        }


        public string GetConnString()
        {
        var settings = config.GetSection("SqlServerConfig");  
          return $"Server={settings["Server"]};Database={settings["Database"]};Trusted_Connection={settings["Trusted_Connection"]};";
   
        }
    }
}