# Selenium UI Test Automation Framework (C# / NUnit)

A UI automation framework built to test my live portfolio site:
👉 https://logangarbacki.dev

Built to simulate a real-world SDET/QA setup — validating that core pages load correctly, navigation works, content is accurate, and the UI stays stable across deployments.

📊 **[View Live Allure Report](https://logangarbacki.github.io/react-portfolio-selenium-tests/)**

---

## 🧪 Test Coverage

**46 tests** across 4 categories:

| Category | Description |
|----------|-------------|
| Smoke | Element visibility, page load, critical path checks |
| Regression | Content accuracy, navigation behavior, link validation |
| Negative | Ensures bad states don't exist (broken links, placeholders, duplicate data) |
| E2E | Full visitor flow from Hero → Projects → About → Contact |

Tests cover 7 sections of the SPA: **Navbar, Hero, About, Projects, Skills, Resume, Contact**

---

## 🧱 How it's built

- **C# + NUnit 3** — test structure and assertions
- **Selenium WebDriver 4** — headless Chrome browser automation
- **Page Object Model (POM)** — one class per page section, clean separation of selectors and logic
- **DriverUtils** — custom scroll-in-view retry logic to handle IntersectionObserver scroll-reveal animations
- **Allure.NUnit** — structured test reporting with suite/category breakdowns
- **Screenshot on failure** — automatically captured and attached to the Allure report

---

## ⚙️ CI/CD Pipeline

Tests run automatically via **GitHub Actions** on:
- Every push to `main`
- Daily scheduled run (midnight UTC)
- Portfolio site deployment trigger (`repository_dispatch`)

After each run, an **Allure report is generated and deployed to GitHub Pages** automatically.

---

## 📁 Project Structure

```
SeleniumTestFramework/
├── Pages/          # Page Object classes (one per section)
├── Tests/          # Test fixtures (Smoke, Regression, Negative, E2E)
├── Utilities/      # DriverUtils, TestConfig
├── Enums/          # NavSection enum
└── .github/
    └── workflows/  # GitHub Actions CI pipeline
```

---

## 🔧 Key Engineering Decisions

**Scroll-reveal handling** — The portfolio uses IntersectionObserver to animate elements into view. A naive `FindElement` would immediately timeout on below-the-fold elements. `DriverUtils.Find` scrolls the element into view inside the wait loop so the observer triggers before the visibility check.

**JS `innerText` fallback** — The hero title uses a CSS `color: transparent` animation, causing Selenium's `.Text` to return empty. `DriverUtils.GetInnerText` uses JavaScript to bypass this.

**Parallel execution** — Fixtures run in parallel (`ParallelScope.Fixtures`) with `LevelOfParallelism(2)` to balance speed and CI resource usage.
