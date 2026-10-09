using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class StatusCardPage
    {
        private readonly IWebDriver _driver;

        public StatusCardPage(IWebDriver driver) => _driver = driver;

        public IWebElement Container => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-card']"));
        public IWebElement Badge => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-card-badge']"));
        public IWebElement LastRun => DriverUtils.Find(_driver, By.CssSelector("[data-testid='metric-last-run']"));
        public IWebElement Tests => DriverUtils.Find(_driver, By.CssSelector("[data-testid='metric-tests']"));
        public IWebElement Duration => DriverUtils.Find(_driver, By.CssSelector("[data-testid='metric-duration']"));
        public IWebElement Commit => DriverUtils.Find(_driver, By.CssSelector("[data-testid='metric-commit']"));
        public IWebElement Strip => DriverUtils.Find(_driver, By.CssSelector("[data-testid='status-strip']"));
        public ReadOnlyCollection<IWebElement> StripCells => Container.FindElements(By.CssSelector(".ci-cell"));
    }
}
