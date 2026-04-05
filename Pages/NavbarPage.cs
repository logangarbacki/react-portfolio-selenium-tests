using OpenQA.Selenium;
using SeleniumTestFramework;

public class NavbarPage
{
    private IWebDriver _driver;

    public NavbarPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement AboutLink => DriverUtils.Find(_driver, By.CssSelector("a[href*='#about']"));
    public IWebElement ContactLink => DriverUtils.Find(_driver, By.CssSelector("a[href*='#contact']"));
    
    public void ClickAbout() => AboutLink.Click();
    public void ClickContact() => ContactLink.Click();
    
}

