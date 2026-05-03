using OpenQA.Selenium;
using SeleniumTestFramework;

namespace SeleniumTestFramework.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;

        public ContactPage(IWebDriver driver) => _driver = driver;

        public IWebElement Section => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact']"));
        public IWebElement Form => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-form']"));
        public IWebElement NameInput => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-name']"));
        public IWebElement EmailInput => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-email']"));
        public IWebElement MessageInput => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-message']"));
        public IWebElement SubmitButton => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-submit']"));

        public IWebElement EmailLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-email-link']"));
        public IWebElement GitHubLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-github']"));
        public IWebElement LinkedInLink => DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-linkedin']"));

        public bool SuccessVisible
        {
            get
            {
                var els = _driver.FindElements(By.CssSelector("[data-testid='contact-success']"));
                return els.Count > 0 && els[0].Displayed;
            }
        }

        public IWebElement SuccessBlock =>
            DriverUtils.Find(_driver, By.CssSelector("[data-testid='contact-success']"));

        public void Fill(string name, string email, string message)
        {
            NameInput.Clear();
            NameInput.SendKeys(name);
            EmailInput.Clear();
            EmailInput.SendKeys(email);
            MessageInput.Clear();
            MessageInput.SendKeys(message);
        }

        public void Submit() => SubmitButton.Click();
    }
}
