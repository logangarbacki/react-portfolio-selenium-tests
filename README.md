# Selenium UI Test Framework (C# / NUnit)

The test suite for my portfolio site, [logangarbacki.dev](https://logangarbacki.dev). It runs against the live site and publishes the results as a public Allure report.

- Live report: https://logangarbacki.github.io/react-portfolio-selenium-tests/
- Site source: https://github.com/logangarbacki/react-portfolio-website

## Coverage

49 test runs across every section of the site: navbar, header, CI status panel, about, skills, work, contact, and footer.

| Category | Runs | What it checks |
|---|---|---|
| Smoke | 20 | Sections and key elements render |
| Regression | 22 | Content, links, and navigation behave correctly |
| Negative | 6 | Removed sections stay removed; no placeholder links or emails |
| E2E | 1 | A full visit from the hero through to a submitted contact form |

## Problems I had to solve

- **Content that appears on scroll.** Sections fade in with IntersectionObserver, so anything below the fold isn't visible until it's scrolled to. `DriverUtils.Find` scrolls each element into view inside the wait, so the observer fires before the visibility check runs.
- **Animated hero text.** The hero name animates in with transparent text, so Selenium's `.Text` came back empty. `DriverUtils.GetInnerText` reads `innerText` through JavaScript instead.
- **The contact form.** The suite submits the real form with `?test-form=1`, which makes the site skip the actual email send, so CI can test the whole flow without spamming my inbox.

## How it runs

GitHub Actions runs the suite on a Windows runner with headless Chrome:

- on every push to `main` in this repo
- on every push to the site repo, through `repository_dispatch`
- nightly
- on demand

Fixtures run in parallel, two at a time. Failed tests attach a screenshot, and each run deploys an Allure report with history to GitHub Pages.

## Stack

C#, .NET 8, NUnit 3, Selenium WebDriver 4, Allure.NUnit, GitHub Actions.

## Layout

```
Pages/       Page objects, one per section
Tests/       Test fixtures by section
Utilities/   Driver setup, waits, and config
Enums/       Navigation sections
.github/     CI workflow
```

## Run it locally

```
dotnet test
```
