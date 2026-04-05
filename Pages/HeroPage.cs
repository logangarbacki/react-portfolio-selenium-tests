using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework;

public class HeroPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public HeroPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestConfig.DefaultTimeoutSeconds));
    }


    public IWebElement Title => DriverUtils.Find(_driver, By.CssSelector(".hero-title"));
    public IWebElement Eyebrow => DriverUtils.Find(_driver, By.CssSelector(".hero-eyebrow span:not(.eyebrow-line)"));
    public IWebElement Tagline => DriverUtils.Find(_driver, By.CssSelector(".hero-tagline"));
    public IWebElement TechStack => DriverUtils.Find(_driver, By.CssSelector(".hero-sub"));
    public IWebElement ViewWorkButton => DriverUtils.Find(_driver, By.CssSelector(".btn-primary"));
    public IWebElement DownloadResumeButton => DriverUtils.Find(_driver, By.CssSelector(".btn-ghost"));

    public void ClickViewWork() => ViewWorkButton.Click();
    public void ClickDownloadResume() => DownloadResumeButton.Click();
}
