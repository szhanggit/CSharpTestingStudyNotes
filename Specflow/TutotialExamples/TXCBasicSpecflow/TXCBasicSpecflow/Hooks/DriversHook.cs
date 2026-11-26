using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TXCBasicSpecflow.Data;

namespace TXCBasicSpecflow.Hooks
{
    [Binding]
    public class DriversHook
    {
        private static IConfiguration _configuration;
        private static Repository _repo;

        public DriversHook()
        {

        }

        [BeforeTestRun]
        public static void InitializeConfig()
        {
            LaunchSettingsFixture();

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environmentName}.json", true);

            _configuration = config.Build();
        }

        //Instantiate Data class
        [Before]
        public void SetUpMethod()
        {
            TXCBasicSpecflow.Factory.Data data = new TXCBasicSpecflow.Factory.Data();
            TXCBasicSpecflow.Factory.DataManager.SetData(data);
        }

        [AfterFeature("cleanUpPrograms")]
        public static void CleanUpPrograms()
        {
            string connString = _configuration.GetConnectionString("TxProgram");
            _repo = new Repository(connString);

            _repo.Execute(new Model
            {
                ScriptFile = Path.Combine("TxProgram", "CleanUpPrograms.sql")
            });
        }

        //[AfterFeature("cleanUpClients")]
        //public static void CleanUpClients()
        //{
        //    string connString = _configuration.GetConnectionString("TxClient");
        //    _repo = new Repository(connString);

        //    _repo.Execute(new Model
        //    {
        //        ScriptFile = Path.Combine("TxClient", "CleanUpClients.sql")
        //    });
        //}

        private static void LaunchSettingsFixture()
        {
            using (var file = File.OpenText("envSettings.json"))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    //select a proper profile here
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    if (variable.Name.Equals("ASPNETCORE_ENVIRONMENT") && variable.Value.ToString().Equals("$(specflowEnv)"))
                        variable.Value = "Dev";

                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }
    }
}
