using NUnit.Framework;
using SwagLabsAutomation.Enums;
using SwagLabsAutomation.Pages;
using SwagLabsAutomation.Support;

namespace SwagLabsAutomation.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        LoginPage? _loginPage;
        HomePage? _homePage;

        [Given(@"The user is on Login page")]
        public void GivenTheUserIsOnLoginPage()
        {
            CreateServices.Start();

            _loginPage = new LoginPage(Browser.CHROME);
            _loginPage.GotoPage(CreateServices.Data!.GetUrl());
        }

        [When(@"User enters the username")]
        public void WhenUserEntersTheUsername()
        {
            _loginPage!.TypeUsername(CreateServices.Data!.GetCredentials().Username!);
        }

        [When(@"User enters the password")]
        public void WhenUserEntersThePassword()
        {
            _loginPage!.TypePassword(CreateServices.Data!.GetCredentials().Password!);
        }

        [When(@"User clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            _loginPage!.ClickOnLoginButton();
        }

        [Then(@"The user is redirected  to Home page")]
        public void ThenTheUserIsRedirectedToHomePage()
        {
            _homePage = new HomePage(_loginPage!.GetDriver());
            string result = _homePage.getElementTitle();

            Assert.AreEqual("Swag Labs", result);
            _homePage.Quit();
        }
    }
}
