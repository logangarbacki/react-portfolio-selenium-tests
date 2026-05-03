using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ProjectsPage
    {
        private readonly IWebDriver _driver;

        public ProjectsPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='projects']"));
        public IWebElement SectionLog => DriverUtils.Find(_driver, By.CssSelector("[data-testid='log-projects']"));

        public IWebElement ProjectCard(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($"[data-testid='project-card-{index}']"));

        public IWebElement ProjectTitle(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($"[data-testid='project-{index}-title']"));

        public IWebElement ProjectStatus(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($"[data-testid='project-{index}-status']"));

        public IWebElement ProjectStack(int index) =>
            ProjectCard(index).FindElement(By.CssSelector(".project-stack"));

        public IWebElement ProjectDescription(int index) =>
            ProjectCard(index).FindElement(By.CssSelector(".project-desc"));

        public IWebElement Project1GithubLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-1-github']"));
        public IWebElement Project1AllureLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-1-allure']"));
        public IWebElement Project3LiveLink   => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-3-live']"));
    }
}
