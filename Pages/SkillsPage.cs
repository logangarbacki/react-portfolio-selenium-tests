using OpenQA.Selenium;

namespace SeleniumTestFramework.Pages
{
    public class SkillsPage
    {
        private readonly IWebDriver _driver;

        public SkillsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SkillsHeading =>
            DriverUtils.Find(_driver, By.CssSelector(".skills-heading"));

        public IWebElement AutomationToolsHeader =>
            DriverUtils.Find(_driver, By.CssSelector(".skill-group:nth-of-type(2) .skill-group-header"));

        public IWebElement CertificationsHeading =>
            DriverUtils.Find(_driver, By.CssSelector(".certs-header"));
    }
}