using OpenQA.Selenium;
using SeleniumTestFramework;
using SeleniumTestFramework.Enums;

namespace SeleniumTestFramework.Pages
{
    public class NavbarPage
    {
        private readonly IWebDriver _driver;

        public NavbarPage(IWebDriver driver) => _driver = driver;

        public IWebElement Nav => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav']"));
        public IWebElement NavName => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-name']"));
        public IWebElement Links => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-links']"));

        public IWebElement AboutLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-link-about']"));
        public IWebElement ProjectsLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-link-projects']"));
        public IWebElement ContactLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-link-contact']"));
        public IWebElement ResumeLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='nav-link-resume']"));

        public void ClickNavLink(NavSection section)
        {
            switch (section)
            {
                case NavSection.About:    AboutLink.Click(); break;
                case NavSection.Projects: ProjectsLink.Click(); break;
                case NavSection.Contact:  ContactLink.Click(); break;
            }
        }

        public bool IsSectionVisible(NavSection section)
        {
            try
            {
                var sectionTestId = section.ToString().ToLower();
                var element = DriverUtils.Find(_driver, By.CssSelector($"[data-testid='{sectionTestId}']"));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
