# Selenium UI Test Automation Framework (C# / NUnit)

This is a UI automation framework I built to test my live portfolio site:
👉 https://logangarbacki.dev

The goal was to simulate a real-world QA setup by validating that core pages load correctly, key elements are present, and the UI remains stable across deployments.

---

## 🚀 What this tests

* Page load validation across core routes
* Visibility and presence of key UI elements
* Basic navigation flow between sections
* DOM-level checks to catch UI regressions early

These tests act as a **smoke/regression suite** to ensure the site doesn’t break after changes.

---

## 🧱 How it’s built

* **C# + NUnit** for test structure
* **Selenium WebDriver 4** for browser automation
* **Page Object Model (POM)** for maintainability
* **Explicit waits** to handle async UI rendering

---

## ⚙️ CI/CD Integration

Tests run automatically using GitHub Actions:

* On push to `main`
* When the portfolio site triggers a deployment event

This helps catch UI issues immediately after changes.

---

## 🧪 Focus of this project

This project focuses on:

* Building a **clean, maintainable automation structure**
* Creating **reliable UI checks (non-flaky tests)**
* Simulating a **basic CI-driven regression suite**

---

## 🔧 Next steps

* Add deeper user flow testing
* Integrate API validation
* Add test reporting (ExtentReports / Allure)
* Expand coverage beyond UI presence checks

---
