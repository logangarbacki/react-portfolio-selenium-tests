using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class SkillsPage
    {
        private readonly IWebDriver _driver;

        public SkillsPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='skills']"));
        public IWebElement Testing => DriverUtils.Find(_driver, By.CssSelector("[data-testid='skills-testing']"));
        public IWebElement Development => DriverUtils.Find(_driver, By.CssSelector("[data-testid='skills-development']"));
        public IWebElement Workflow => DriverUtils.Find(_driver, By.CssSelector("[data-testid='skills-workflow']"));
    }
}
