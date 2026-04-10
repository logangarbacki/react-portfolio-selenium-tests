using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ResumePage
    {
        private readonly IWebDriver _driver;

        public ResumePage(IWebDriver driver) => _driver = driver;

        public IWebElement Heading        => DriverUtils.Find(_driver, By.CssSelector(".resume-heading"));
        public IWebElement Blurb          => DriverUtils.Find(_driver, By.CssSelector(".resume-blurb"));
        public IWebElement DownloadButton => DriverUtils.Find(_driver, By.CssSelector(".btn-download"));

        public IWebElement EducationName   => DriverUtils.Find(_driver, By.CssSelector(".edu-name"));
        public IWebElement EducationDegree => DriverUtils.Find(_driver, By.CssSelector(".edu-deg"));

        public IWebElement ExperienceRole(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".exp-item:nth-of-type({index}) .exp-role"));

        public IWebElement ExperienceCompany(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".exp-item:nth-of-type({index}) .exp-company"));

        public IWebElement ExperiencePeriod(int index) =>
            DriverUtils.Find(_driver, By.CssSelector($".exp-item:nth-of-type({index}) .exp-period"));
    }
}
