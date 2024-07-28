using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Support
{
    public class DataService
    {
        private readonly string projectDataPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName + "/Data";
        public DataService()
        {
            this.Login = new ConfigurationBuilder()
                .SetBasePath(projectDataPath)
                .AddJsonFile("info.json")
                .Build();

            this.Flight = new ConfigurationBuilder()
                .SetBasePath(projectDataPath)
                .AddJsonFile("flight.json")
                .Build();
        }

        public IConfiguration Login { get; set; }
        public IConfiguration Flight { get; set; }
    }
}
