using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework;

public class AboutPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public AboutPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SeleniumTestFramework.TestConfig.DefaultTimeoutSeconds));
    }

    public IWebElement Heading => DriverUtils.Find(_driver, By.CssSelector(".about-heading"));
    public IWebElement Badge => DriverUtils.Find(_driver, By.CssSelector(".about-badge"));
    public IWebElement IntroParagraph => DriverUtils.Find(_driver, By.CssSelector(".about-text"));
    public IWebElement StatsGrid => DriverUtils.Find(_driver, By.CssSelector(".about-stats"));
    
    public IWebElement LocationBadge => DriverUtils.Find(_driver, By.CssSelector(".about-badge"));

    public IWebElement CertificationsStat => DriverUtils.Find(_driver, By.CssSelector(".about-stats .stat-item:nth-child(2) .stat-value"));
}