using OpenQA.Selenium;
using SwagLabsAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Pages
{
    public class HomePage : BaseDriver
    {
        private By? _pageTitleElementLocator;

        public HomePage(IWebDriver driver) : base(driver) 
        {
            LoadLocators();
        }

        public string getElementTitle()
        {
            ExplicitWait(_pageTitleElementLocator!, 10);
            return GetText(_pageTitleElementLocator!);
        }

        // ======================== PRIVATE METHODS ==============================
        private void LoadLocators()
        {
            _pageTitleElementLocator = By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div");
        }
    }
}
