using NUnit.Framework;
using SeleniumTestFramework.Pages;
using OpenQA.Selenium;

namespace SeleniumTestFramework
{
[TestFixture]
public class AboutTests : BaseTest
{
    private AboutPage _about;
    private HeroPage _hero;

    [SetUp]
    public void SetUp()
    {
        _about = new AboutPage(Driver);
        _hero = new HeroPage(Driver);
        ((IJavaScriptExecutor)Driver).ExecuteScript(
            "arguments[0].scrollIntoView({behavior:'instant'});", 
            _about.Heading
        );
    }

    [Test, Category("Smoke")]
    public void User_CanNavigate_To_About_Section()
    {
        Assert.That(_about.Heading.Displayed, Is.True);
    }

    [Test, Category("Smoke")]
    public void AboutPage_LoadsCorrectly()
    {
        Assert.That(_about.Heading.Displayed, Is.True);
        Assert.That(_about.Heading.Text, Is.Not.Empty);
    }

    [Test, Category("Regression")]
    public void AboutPage_Content_IsCorrect()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_about.Heading.Text, Does.Contain("Quality first"));
            Assert.That(_about.IntroParagraph.Text, Does.Contain("self-taught QA Engineer"));
            Assert.That(_about.LocationBadge.Text, Does.Contain("Hicksville, NY"));
            Assert.That(_about.LocationBadge.Text, Does.Contain("Open to Remote"));
            Assert.That(_about.CertificationsStat.Text, Is.EqualTo("5"));
        });
    }
}
}