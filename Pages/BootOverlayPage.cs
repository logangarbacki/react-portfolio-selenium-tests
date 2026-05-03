using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework;
using System;

namespace SeleniumTestFramework.Pages
{
    public class BootOverlayPage
    {
        private readonly IWebDriver _driver;

        public BootOverlayPage(IWebDriver driver) => _driver = driver;

        public bool IsVisible
        {
            get
            {
                try
                {
                    var els = _driver.FindElements(By.CssSelector("[data-testid='boot-overlay']"));
                    if (els.Count == 0) return false;
                    var el = els[0];
                    if (!el.Displayed) return false;
                    // The overlay applies .done with opacity:0 + clip-path before unmounting
                    var classAttr = el.GetAttribute("class") ?? string.Empty;
                    return !classAttr.Contains("done");
                }
                catch (StaleElementReferenceException)
                {
                    // overlay was removed from the DOM mid-poll
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement SkipButton =>
            DriverUtils.Find(_driver, By.CssSelector("[data-testid='boot-skip']"));

        public void ClickSkip() => SkipButton.Click();

        // Wait for the boot overlay to disappear (auto-completion takes ~3.5s).
        public void WaitForCompletion(int timeoutSeconds = 8)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d =>
            {
                var els = d.FindElements(By.CssSelector("[data-testid='boot-overlay']"));
                if (els.Count == 0) return true;
                var classAttr = els[0].GetAttribute("class") ?? string.Empty;
                return classAttr.Contains("done");
            });
        }
    }
}
