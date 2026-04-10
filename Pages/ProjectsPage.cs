using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ProjectsPage
    {
        private readonly IWebDriver _driver;

        public ProjectsPage(IWebDriver driver) => _driver = driver;

        public IWebElement Heading => DriverUtils.Find(_driver, By.CssSelector(".projects-heading"));

        public IWebElement ProjectTitle(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-title"));

        public IWebElement ProjectYear(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-year"));

        public IWebElement ProjectType(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-type"));

        public IWebElement ProjectDescription(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-desc"));

        public IWebElement ProjectMetric(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".project-item:nth-of-type({index}) .project-metric"));
    }
}
