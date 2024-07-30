using NUnit.Framework;
using SwagLabsAutomation.Enums;
using SwagLabsAutomation.Pages;
using SwagLabsAutomation.Support;
using System;
using TechTalk.SpecFlow;

namespace SwagLabsAutomation.StepDefinitions
{
    [Binding]
    public class LoginOutlineStepDefinitions
    {
        private LoginPage? _loginPage;
        private HomePage? _homePage;
        [Given(@"The user is on Login page with url ""([^""]*)""")]
        public void GivenTheUserIsOnLoginPageWithUrl(string url)
        {
            _loginPage = new LoginPage(Browser.FIREFOX);
            _loginPage.GotoPage(url);
        }

        [When(@"User enters the username ""([^""]*)""")]
        public void WhenUserEntersTheUsername(string username)
        {
            _loginPage!.TypeUsername(username);
        }

        [When(@"User enters the password ""([^""]*)""")]
        public void WhenUserEntersThePassword(string password)
        {
            _loginPage?.TypePassword(password);
        }

        [When(@"User clicks on Login button so")]
        public void WhenUserClicksOnLoginButtonSo()
        {
            _loginPage!.ClickOnLoginButton();
        }

        [Then(@"The user is redirected  to Home page so")]
        public void ThenTheUserIsRedirectedToHomePageSo()
        {
            _homePage = new HomePage(_loginPage!.GetDriver());
            string result = _homePage.GetElementTitle();
            CreateServices.Driver = _homePage!.GetDriver();
            _homePage.Quit();

            Assert.AreEqual("Swag Labs", result);
            
        }
    }
}
