using OpenQA.Selenium;

public class NavbarPage
{
    private IWebDriver _driver;

    public NavbarPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement AboutLink => _driver.FindElement(By.CssSelector("a[href*='#about']"));
    public IWebElement ContactLink => _driver.FindElement(By.CssSelector("a[href*='#contact']"));
    
    public void ClickAbout() => AboutLink.Click();
    public void ClickContact() => ContactLink.Click();
    
}

