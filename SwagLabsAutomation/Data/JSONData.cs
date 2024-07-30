using Microsoft.Extensions.Configuration;
using SwagLabsAutomation.Entities;
using SwagLabsAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Data
{
    public class JSONData : IData
    {

        private string DATA_PATH = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName + "/Data";

        public string GetUrl()
        {
            return GetData("general_info.json", "url");
        }

        public Login GetCredentials()
        {
            string fileName = "login_credentials.json";
            return new Login
            {
                Username = GetData(fileName, "username"),
                Password = GetData(fileName, "password")
            };
        }

        // PRIVATE METHODS
        private string GetData(string fileName, string key)
        {
            var info = new ConfigurationBuilder()
                .SetBasePath(DATA_PATH)
                .AddJsonFile(fileName)
                .Build();

            return info.GetSection(key).Value!;
        }


    }
}
