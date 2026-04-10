using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver) => _driver = driver;

        public IWebElement Heading => DriverUtils.Find(_driver, By.CssSelector(".about-heading"));
        public IWebElement LocationBadge  => DriverUtils.Find(_driver, By.CssSelector(".about-badge"));
        public IWebElement IntroParagraph => DriverUtils.Find(_driver, By.CssSelector(".about-text"));
        public IWebElement StatsGrid => DriverUtils.Find(_driver, By.CssSelector(".about-stats"));

        public IWebElement StatValue(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".about-stats .stat-item:nth-child({index}) .stat-value"));

        public IWebElement StatLabel(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".about-stats .stat-item:nth-child({index}) .stat-label"));

        public IWebElement CertificationsStat => StatValue(2);
    }
}
