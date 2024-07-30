using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using SwagLabsAutomation.Data;
using SwagLabsAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Support
{
    public class CreateServices
    {
        
        public static void Start()
        {
            var services = new ServiceCollection()
                .AddTransient<IData, JSONData>()
                .BuildServiceProvider();

            Data = services.GetRequiredService<IData>();
        }

        public static IData? Data {  get; set; }
        public static IWebDriver? Driver { get; set; }
    }
}
