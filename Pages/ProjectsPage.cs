using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestFramework
{
    public class ProjectsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ProjectsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SectionTitle => DriverUtils.Find(_driver, By.CssSelector(".projects-heading"));

        public IWebElement ProjectTitle(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-title"));

        public IWebElement ProjectMetric(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-metric"));
    }
}