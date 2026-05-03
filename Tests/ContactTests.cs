using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumTestFramework.Pages;
using System;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.AllureNUnit]
    [Allure.NUnit.Attributes.AllureSuite("Contact")]
    public class ContactTests : BaseTest
    {
        private ContactPage _contact;

        [SetUp]
        public void SetUp() => _contact = new ContactPage(Driver);

        [Test, Category("Smoke")]
        public void ContactSection_IsVisible() =>
            Assert.That(_contact.Section.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void ContactForm_LoadsAllInputs()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contact.Form.Displayed, Is.True);
                Assert.That(_contact.NameInput.Displayed, Is.True);
                Assert.That(_contact.EmailInput.Displayed, Is.True);
                Assert.That(_contact.MessageInput.Displayed, Is.True);
                Assert.That(_contact.SubmitButton.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void ContactLinks_HaveCorrectHrefs()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contact.EmailLink.GetAttribute("href"), Does.Contain("mailto:contact@logangarbacki.dev").IgnoreCase);
                Assert.That(_contact.GitHubLink.GetAttribute("href"), Does.Contain("github.com/logangarbacki"));
                Assert.That(_contact.LinkedInLink.GetAttribute("href"), Does.Contain("linkedin.com/in/logangarbacki"));
            });
        }

        [Test, Category("Regression")]
        public void Form_AcceptsInput()
        {
            _contact.Fill("Test User", "test@example.com", "Test message");
            Assert.Multiple(() =>
            {
                Assert.That(_contact.NameInput.GetAttribute("value"), Is.EqualTo("Test User"));
                Assert.That(_contact.EmailInput.GetAttribute("value"), Is.EqualTo("test@example.com"));
                Assert.That(_contact.MessageInput.GetAttribute("value"), Is.EqualTo("Test message"));
            });
        }

        [Test, Category("Regression")]
        public void Form_Submission_ShowsSuccessState()
        {
            _contact.Fill("Test User", "test@example.com", "Hello from Selenium");
            _contact.Submit();

            // The mock submit waits ~700ms, renders the success block, then
            // types out "POST /contact → ok" character-by-character (~540ms).
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => _contact.SuccessVisible);
            // Wait for the typewriter to finish — "ok" is the last fragment.
            wait.Until(d => _contact.SuccessBlock.Text.IndexOf("ok", StringComparison.OrdinalIgnoreCase) >= 0);

            var successText = _contact.SuccessBlock.Text;
            Assert.Multiple(() =>
            {
                Assert.That(successText, Does.Contain("200").IgnoreCase);
                Assert.That(successText, Does.Contain("ok").IgnoreCase);
                Assert.That(successText, Does.Contain("message received").IgnoreCase);
            });
        }
    }
}
