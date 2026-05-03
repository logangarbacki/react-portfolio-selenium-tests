using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class FooterPage
    {
        private readonly IWebDriver _driver;

        public FooterPage(IWebDriver driver) => _driver = driver;

        public IWebElement Container => DriverUtils.Find(_driver, By.CssSelector("[data-testid='footer']"));
    }
}
