using SwagLabsAutomation.Enums;
using SwagLabsAutomation.Pages;
using SwagLabsAutomation.Support;
using TechTalk.SpecFlow;

namespace SwagLabsAutomation.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        public Hooks()
        {
            CreateServices.Start();
        }
        [BeforeScenario("@product")]
        public void BeforeScenarioWithTag()
        {
            LoginPage loginPage = new LoginPage(Browser.FIREFOX);
            loginPage.MaximizeWindows();
            loginPage.GotoPage(CreateServices.Data!.GetUrl());
            loginPage.Login(CreateServices.Data!.GetCredentials().Username!, CreateServices.Data.GetCredentials().Password!);

            CreateServices.Driver = loginPage.GetDriver();
        }

        [AfterScenario("@product")]
        public void AfterScenario()
        {
            CreateServices.Driver!.Quit();
        }
    }
}