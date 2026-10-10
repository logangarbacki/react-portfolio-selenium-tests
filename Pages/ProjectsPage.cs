using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ProjectsPage
    {
        private readonly IWebDriver _driver;

        public ProjectsPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='projects']"));

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

        // Selenium UI Test Framework is now card 3
        public IWebElement SeleniumGithubLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-3-github']"));
        public IWebElement SeleniumAllureLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-3-allure']"));
        // PrintScan Location Search (card 2) → live page
        public IWebElement LocationSearchLiveLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-2-live']"));
        // Little Lemon (card 5) → live app and front-end repo
        public IWebElement LittleLemonLiveLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-5-live']"));
        public IWebElement LittleLemonGithubLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='project-5-github']"));
        // Lead Generation Tool (card 4) has no public link
        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> LeadGenLinks =>
            ProjectCard(4).FindElements(By.CssSelector(".link-row a"));
    }
}
