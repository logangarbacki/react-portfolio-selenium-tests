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

    private IWebElement Find(By by) =>
        _wait.Until(d => d.FindElement(by));

    public IWebElement Title => Find(By.CssSelector(".hero-title"));
    public IWebElement Eyebrow => Find(By.CssSelector(".hero-eyebrow span:not(.eyebrow-line)"));
    public IWebElement Tagline => Find(By.CssSelector(".hero-tagline"));
    public IWebElement TechStack => Find(By.CssSelector(".hero-sub"));
    public IWebElement ViewWorkButton => Find(By.CssSelector(".btn-primary"));
    public IWebElement DownloadResumeButton => Find(By.CssSelector(".btn-ghost"));

    public void ClickViewWork() => ViewWorkButton.Click();
    public void ClickDownloadResume() => DownloadResumeButton.Click();
}
