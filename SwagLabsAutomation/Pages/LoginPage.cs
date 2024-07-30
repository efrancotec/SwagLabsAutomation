using OpenQA.Selenium;
using SwagLabsAutomation.Drivers;
using SwagLabsAutomation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomation.Pages
{
    public class LoginPage : BaseDriver
    {
        #region Properties
        private By? _userNameTextFileLocator;
        private By? _passwordTextFileLocator;
        private By? _loginButtonLocator; 
        #endregion

        #region Constructors
        public LoginPage() : base()
        {
            LoadLocators();
        }
        public LoginPage(Browser browser) : base(browser)
        {
            LoadLocators();
        }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            LoadLocators();
        }
        #endregion

        #region Public Methods
        // ======================== PUBLIC METHODS =============================
        public void GotoPage(string url)
        {
            GoToUrl(url);
        }
        public void TypeUsername(string username)
        {
            ExplicitWait(_userNameTextFileLocator!, 10);
            TypeText(_userNameTextFileLocator!, username);
        }
        public void TypePassword(string password)
        {
            TypeText(_passwordTextFileLocator!, password);
        }
        public void ClickOnLoginButton()
        {
            ClickOnButton(_loginButtonLocator!);
        } 
        public void Login(string username, string password)
        {
            ExplicitWait(_userNameTextFileLocator!, 5);
            TypeText(_userNameTextFileLocator!, username);
            TypeText(_passwordTextFileLocator!, password);
            ClickOnButton(_loginButtonLocator!);
        }
        #endregion

        #region Private Methods
        // ============== PRIVATE METHODS ========================
        private void LoadLocators()
        {
            _userNameTextFileLocator = By.Id("user-name");
            _passwordTextFileLocator = By.Id("password");
            _loginButtonLocator = By.Id("login-button");
        } 
        #endregion

    }
}
