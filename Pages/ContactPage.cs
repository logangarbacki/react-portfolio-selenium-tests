using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

        public ContactPage(IWebDriver driver) => _driver = driver;

        public IWebElement Heading    => DriverUtils.Find(_driver, By.CssSelector(".contact-heading"));
        public IWebElement SubText    => DriverUtils.Find(_driver, By.CssSelector(".contact-sub"));
        public IWebElement EmailLink  => DriverUtils.Find(_driver, By.CssSelector("a.contact-email"));
        public IWebElement GitHubLink => DriverUtils.Find(_driver, By.CssSelector("a[href*='github']"));
        public IWebElement LinkedInLink => DriverUtils.Find(_driver, By.CssSelector("a[href*='linkedin']"));
        public IWebElement Footer     => DriverUtils.Find(_driver, By.CssSelector(".contact-footer"));
    }
}
