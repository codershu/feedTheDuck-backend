using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;

namespace feedTheDuck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
//.ConfigureAppConfiguration((context, config) =>
//{
//    var keyVaultEndpoint = new Uri("https://feedtheduck-keyvault.vault.azure.net/secrets/ConnectionStrings--MyDbConnection/4851e700eee74c268af26e7962751769");//new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//config.AddAzureKeyVault(
//keyVaultEndpoint,
//new DefaultAzureCredential());
//})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
