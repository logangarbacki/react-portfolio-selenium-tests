# Selenium UI Test Automation Framework (C# / NUnit)

I run my portfolio like a production app — this framework is the test suite that keeps it honest.

👉 https://logangarbacki.dev
📊 [Live Allure Report](https://logangarbacki.github.io/react-portfolio-selenium-tests/)

---

## ⚙️ Real problems solved

### Scroll-reveal (IntersectionObserver)
Elements below the fold animate in via IntersectionObserver. Default visibility checks would pass even when elements were off-screen — a naive `FindElement` immediately times out.

Fix: `DriverUtils.Find` scrolls the element into view inside the wait loop so the observer fires before the visibility check runs.

### JS `innerText` fallback
The hero title uses a CSS `color: transparent` animation — Selenium's `.Text` returns empty.

Fix: `DriverUtils.GetInnerText` bypasses this via JavaScript `innerText`.

### Parallel execution
Fixtures run in parallel (`ParallelScope.Fixtures`) with `LevelOfParallelism(2)` — balances speed against CI resource constraints.

---

## 🧪 Test coverage

**46 tests** across 4 categories — covering 7 SPA sections: Navbar, Hero, About, Projects, Skills, Resume, Contact

| Category | What it covers |
|----------|----------------|
| **Negative** *(often skipped)* | Ensures bad states don't exist — broken links, placeholders, duplicate data |
| **Smoke** | Element visibility, page load, critical path checks |
| **Regression** | Content accuracy, navigation behavior, link validation |
| **E2E** | Full visitor flow: Hero → Projects → About → Contact |

---

## 🧱 Stack

- **C# + NUnit 3** — test structure and assertions
- **Selenium WebDriver 4** — headless Chrome
- **Page Object Model** — one class per section, selectors separated from logic
- **DriverUtils** — custom scroll-in-view retry logic, JS text fallback
- **Allure.NUnit** — structured reporting with suite/category breakdowns
- **Screenshot on failure** — auto-captured and attached to the report

---

## 🚀 CI/CD

Runs automatically via **GitHub Actions** on:

- Every push to `main`
- Daily scheduled run (midnight UTC)
- Portfolio deployment trigger (`repository_dispatch`)

Allure report is generated and deployed to GitHub Pages after each run.

---

## 📁 Project structure

```
SeleniumTestFramework/
├── Pages/          # Page Object classes (one per section)
├── Tests/          # Test fixtures (Smoke, Regression, Negative, E2E)
├── Utilities/      # DriverUtils, TestConfig
├── Enums/          # NavSection enum
└── .github/
    └── workflows/  # GitHub Actions CI pipeline
```
