using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='about']"));
        public IWebElement FirstParagraph => DriverUtils.Find(_driver, By.CssSelector("[data-testid='about-paragraph-1']"));
        public IWebElement SecondParagraph => DriverUtils.Find(_driver, By.CssSelector("[data-testid='about-paragraph-2']"));
        public IWebElement SectionLog => DriverUtils.Find(_driver, By.CssSelector("[data-testid='log-about']"));
    }
}
