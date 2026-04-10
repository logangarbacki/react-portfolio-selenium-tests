using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class SkillsPage
    {
        private readonly IWebDriver _driver;

        public SkillsPage(IWebDriver driver) => _driver = driver;

        public IWebElement Heading          => DriverUtils.Find(_driver, By.CssSelector(".skills-heading"));
        public IWebElement CertsSection     => DriverUtils.Find(_driver, By.CssSelector(".certs"));
        public IWebElement CertsHeader      => DriverUtils.Find(_driver, By.CssSelector(".certs-header"));


        public IWebElement SkillGroupHeader(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".skill-group:nth-of-type({index}) .skill-group-header"));

        public int GetCertCount()
        {
            CertsSection.GetAttribute("class"); 
            return _driver.FindElements(By.CssSelector(".cert-row")).Count;
        }
    }
}
