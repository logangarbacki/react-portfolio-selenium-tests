using NUnit.Framework;
using SeleniumTestFramework.Pages;

namespace SeleniumTestFramework
{
    [TestFixture]
    [Allure.NUnit.Attributes.AllureSuite("Contact")]
    public class ContactTests : BaseTest
    {
        private ContactPage _contact;

        [SetUp]
        public void SetUp() => _contact = new ContactPage(Driver);

        [Test, Category("Smoke")]
        public void ContactHeading_IsVisible() =>
            Assert.That(_contact.Heading.Displayed, Is.True);

        [Test, Category("Smoke")]
        public void Contact_LoadsCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contact.Heading.Displayed, Is.True);
                Assert.That(_contact.Heading.Text, Is.Not.Empty);
                Assert.That(_contact.SubText.Displayed, Is.True);
                Assert.That(_contact.EmailLink.Displayed, Is.True);
                Assert.That(_contact.Footer.Displayed, Is.True);
            });
        }

        [Test, Category("Regression")]
        public void Contact_Content_IsCorrect()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contact.Heading.Text, Does.Contain("Let's build").IgnoreCase);
                Assert.That(_contact.SubText.Text, Does.Contain("QA engineering").IgnoreCase);
            });
        }

        [Test, Category("Regression")]
        public void ContactLinks_HaveCorrectHrefs()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_contact.EmailLink.GetAttribute("href"), Does.Contain("mailto:").IgnoreCase);
                Assert.That(_contact.GitHubLink.GetAttribute("href"), Does.Contain("github.com").IgnoreCase);
                Assert.That(_contact.LinkedInLink.GetAttribute("href"), Does.Contain("linkedin.com").IgnoreCase);
            });
        }
    }
}
