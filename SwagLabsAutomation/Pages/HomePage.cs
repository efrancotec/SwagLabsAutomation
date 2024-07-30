using OpenQA.Selenium;
using SwagLabsAutomation.Drivers;

namespace SwagLabsAutomation.Pages
{
    public class HomePage : BaseDriver
    {
        private By? _pageTitleElementLocator;
        private By? _productsElementLocator;
        private By? _addToCartButtonLocator;
        private By? _removeButtonLocator;

        public HomePage(IWebDriver driver) : base(driver)
        {
            LoadLocators();
        }

        public string GetElementTitle()
        {
            ExplicitWait(_pageTitleElementLocator!, 10);
            return GetText(_pageTitleElementLocator!);
        }
        public void SelectProduct(string productName)
        {
            ExplicitWait(_productsElementLocator!, 10);
            ClickOnButton(_productsElementLocator!);
        }

        public void ClickOnAddToCartButton()
        {
            ExplicitWait(_addToCartButtonLocator!, 10);
            ClickOnButton(_addToCartButtonLocator!);
        }

        public string GetTextFromRemoveButton()
        {
            ExplicitWait(_removeButtonLocator!);
            return GetText(_removeButtonLocator!);
        }

        // ======================== PRIVATE METHODS ==============================
        private void LoadLocators()
        {
            _pageTitleElementLocator = By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div");
            _productsElementLocator = By.XPath("/html/body/div/div/div/div[2]/div/div/div/div[1]/div[2]/div[1]/a/div");
            _addToCartButtonLocator = By.Id("add-to-cart");
            _removeButtonLocator = By.Id("remove");
        }
    }
}
