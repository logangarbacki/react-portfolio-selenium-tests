using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class StatusBarPage
    {
        private readonly IWebDriver _driver;

        public StatusBarPage(IWebDriver driver) => _driver = driver;

        public IWebElement Container => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-bar']"));
        public IWebElement Host => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-host']"));
        public IWebElement Branch => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-branch']"));
        public IWebElement Build => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-build']"));
        public IWebElement Age => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-age']"));
        public IWebElement LiveTag => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-live-tag']"));
    }
}
