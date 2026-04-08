selenium-tests (logangarbacki.dev)

UI test suite for https://logangarbacki.dev

This project uses Selenium with NUnit in C# to run a small set of end-to-end checks against the live site. It’s wired into GitHub Actions so tests run automatically whenever the main site repo gets updated.

what this is

This isn’t meant to be a huge testing framework. It’s just a simple safety net to make sure the site still loads, navigation works, and nothing obvious is broken after changes.

stack

C# / .NET
NUnit
Selenium WebDriver
GitHub Actions

running locally
dotnet restore
dotnet test

CI / CD

Tests run automatically through GitHub Actions whenever the main site repository receives a commit.

The workflow just restores dependencies, builds the project, runs the tests, and reports the result. Everything runs headless in CI.

structure
/Tests
/Drivers
/Utilities
/.github/workflows

example
[Test]
public void HomePage_Should_Load()
{
    driver.Navigate().GoToUrl("https://logangarbacki.dev");
    Assert.That(driver.Title, Does.Contain("Logan"));
}

notes

Tests run against the live site. There’s no staging environment right now. Keeping everything intentionally simple so it’s easy to maintain and doesn’t become overkill.

why this exists

So I can push changes without wondering if I broke something obvious.
