using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework;
using SeleniumTestFramework.Enums;

namespace SeleniumTestFramework.Pages
{
    public class NavbarPage
    {
        private readonly IWebDriver _driver;

        public NavbarPage(IWebDriver driver) => _driver = driver;

        public IWebElement NavMenu      => DriverUtils.Find(_driver, By.CssSelector("nav.navbar"));
        public IWebElement Logo         => DriverUtils.Find(_driver, By.CssSelector("a.nav-logo"));
        public IWebElement StatusButton => DriverUtils.Find(_driver, By.CssSelector("button.nav-status"));

        public void ClickNavLink(NavSection section)
        {
            var link = NavMenu.FindElement(By.CssSelector($"a[href='#{section.ToString().ToLower()}']"));
            link.Click();
        }

        public bool IsSectionVisible(NavSection section)
        {
            try
            {
                var element = DriverUtils.Find(_driver, By.CssSelector($"section#{section.ToString().ToLower()}"));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
