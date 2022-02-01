using System;
using System.IO;
using System.Linq;
using LivePager.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LivePager.Setup.Data.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static IServiceProvider ServiceProvider;
        public static IServiceCollection Services;
        public static string ConnectionString;
        public static IConfigurationRoot Configuration;

        [OneTimeSetUp]
        public void Init()
        {
            RemoveTestsFilesDbs();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var dir = $"{TestContext.CurrentContext.TestDirectory.HasToEndWith(@"/")}";

            var config = Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("LiveConnection")
                .Replace("#dir#", dir);
            ConnectionString = connectionString.ToOsStyle();
            var connection = new SqliteConnection(connectionString.Replace(".db", $"{DateTime.Now.Ticks}.db"));
            connection.Open();

            var services = new ServiceCollection();

            services.AddInfrastructure( false);
            services.AddApplication(null, false);

            Services = services;
            ServiceProvider = Services.BuildServiceProvider();
        }


        private void RemoveTestsFilesDbs()
        {
            string[] keyFiles = { "livepager.db" };
            string[] keyDirs =
                {@"os/destination".ToOsStyle(), @"os/source".ToOsStyle(), @"TestArtifacts/Database".ToOsStyle()};

            foreach (var keyDir in keyDirs)
            {
                if (Directory.Exists(keyDir))
                {
                    DirectoryInfo di = new DirectoryInfo(keyDir);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (!keyFiles.Contains(file.Name))
                            file.Delete();
                    }
                }
            }
        }
    }
}
