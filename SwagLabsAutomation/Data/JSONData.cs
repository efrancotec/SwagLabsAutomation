using Microsoft.Extensions.Configuration;
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


        public string GetUrl()
        {
            return getData("genera_info.json");
        }

        // PRIVATE METHODS
        private string getData(string fileName)
        {
            var path = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName + "/Data";
            var info = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("general_info.json")
                .Build();

            return info.GetSection(fileName).Value!;
        }
    }
}
