using NUnit.Framework;
using SwagLabsAutomation.Pages;
using SwagLabsAutomation.Support;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SwagLabsAutomation.StepDefinitions
{
    [Binding]
    public class ProductStepDefinitions
    {
        private HomePage? _homePage;

        [Given(@"User is in home product pege")]
        public void GivenUserIsInHomeProductPege()
        {
            _homePage = new HomePage(CreateServices.Driver!);
        }

        [When(@"The user clicks on product title ""([^""]*)""")]
        public void WhenTheUserClicksOnProductTitle(string productName)
        {
            _homePage!.SelectProduct(productName);
            
        }

        [When(@"The user clicks on Add to cart button")]
        public void WhenTheUserClicksOnAddToCartButton()
        {
            _homePage!.ClickOnAddToCartButton();
        }

        [Then(@"The product is shown on cart")]
        public void ThenTheProductIsShownOnCart()
        {
            string result = _homePage!.GetTextFromRemoveButton();

            CreateServices.Driver = _homePage.GetDriver();
            Assert.AreEqual("Remove", result);
        }
    }
}
