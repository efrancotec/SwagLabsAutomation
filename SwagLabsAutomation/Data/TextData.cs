
using SwagLabsAutomation.Interfaces;
using SwagLabsAutomation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Data
{
    public class TextData : IData
    {
        public string GetUrl()
        {
            var filePath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName + "/Data/heneral_info.txt";
            string url = "";

            foreach (var line in FileHelper.ReadTextFile(filePath))
            {
                string[] lineSplit = line.Split(':');
                if (lineSplit[0].Equals("url")) url = lineSplit[1];
            }

            return url;
        }
    }
}
