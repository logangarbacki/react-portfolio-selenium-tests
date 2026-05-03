using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class HeroPage
    {
        private readonly IWebDriver _driver;

        public HeroPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero']"));
        public IWebElement Name => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero-name']"));
        public IWebElement Label => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero-label']"));
        public IWebElement Summary => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero-summary']"));
        public IWebElement ViewProjectsButton => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero-cta-projects']"));
        public IWebElement ResumeButton => DriverUtils.Find(_driver, By.CssSelector("[data-testid='hero-cta-resume']"));

        public void ClickViewProjects() => ViewProjectsButton.Click();
        public void ClickResume() => ResumeButton.Click();
    }
}
