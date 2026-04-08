using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework;

public class ResumePage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    public ResumePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SeleniumTestFramework.TestConfig.DefaultTimeoutSeconds));
    }

    public IWebElement Heading => DriverUtils.Find(_driver, By.CssSelector(".resume-heading"));
    public IWebElement Blurb => DriverUtils.Find(_driver, By.CssSelector(".resume-blurb"));
    public IWebElement DownloadButton => DriverUtils.Find(_driver, By.CssSelector(".btn-download"));


}