using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SwagLabsAutomation.Enums;

namespace SwagLabsAutomation.Drivers
{

    public class BaseDriver
    {
        private IWebDriver? _driver;

        public BaseDriver()
        {
            _driver = new ChromeDriver();
        }
        public BaseDriver(Browser browser)
        {
            DefineDriver(browser);
        }
        public BaseDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Manage Driver
        // ==================== MANAGE DRIVER METHODS ============================
        public void GoToUrl(string url)
        {
            _driver!.Navigate().GoToUrl(url);
        }
        public void MaximizeWindows()
        {
            _driver!.Manage().Window.Maximize();
        }
        public void Close()
        {
            _driver?.Close();
        }
        public void Quit()
        {
            _driver?.Quit();
        }
        public IWebDriver GetDriver()
        {
            return _driver!;
        }
        public string GetTitle()
        {
            return _driver!.Title;
        }
        #endregion

        #region Fields and Elements
        // ==================== FIELDS ON WEB PAGE ===============================
        public void TypeText(By locator, string text)
        {
            _driver!.FindElement(locator).SendKeys(text);
        }
        public void ClearField(By locator)
        {
            _driver!.FindElement(locator).Clear();
        }
        public void PressEnterKey(By locator)
        {
            _driver!.FindElement(locator).SendKeys(Keys.Enter);
        }
        public string GetText(By locator)
        {
            return _driver!.FindElement(locator).Text;
        }
        public void ClickOnButton(By locator)
        {
            _driver!.FindElement(locator).Click();
        }
        public IWebElement GetElement(By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(seconds));
            return wait.Until(e => e.FindElement(locator));
        }
        public void ClickElementByText(By locator, string text)
        {
            var elements = _driver!.FindElements(locator);

            foreach (var element in elements)
            {
                if (element.Text.Equals(text)) element.Click();
            }
        }
        #endregion

        #region Selects
        // ==================== SELECTS =====================================
        public void DropDownSelectByText(By locator, string text)
        {
            SelectElement select = new SelectElement(_driver!.FindElement(locator));
            select.SelectByText(text);

        }
        public void DropDownSelectByValue(By locator, string value)
        {
            SelectElement select = new SelectElement(_driver!.FindElement(locator));
            select.SelectByValue(value);

        }
        public void DropDownSelectByIndex(By locator, int index)
        {
            SelectElement select = new SelectElement(_driver!.FindElement(locator));
            select.SelectByIndex(index);

        }
        #endregion

        #region Wait
        // ==================== WAIT
        public void ImplicitWait()
        {
            _driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void ImplicitWait(int seconds)
        {
            _driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public void ExplicitWait(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(5));
            wait.Until(e => _driver!.FindElement(locator).Displayed);
        }
        public void ExplicitWait(By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(seconds));
            wait.Until(e => _driver!.FindElement(locator).Displayed);
        }
        #endregion


        #region Private Methods
        // ==================== PRIVATE METHODS ==================================
        private void DefineDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.CHROME:
                    {
                        _driver = new ChromeDriver();
                        break;
                    }
                case Browser.FIREFOX:
                    {
                        _driver = new FirefoxDriver();
                        break;
                    }
                case Browser.EDGE:
                    {
                        _driver = new EdgeDriver();
                        break;
                    }
            }
        } 
        #endregion
    }
}
