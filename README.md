# selenium-tests (logangarbacki.dev)

UI test suite for https://logangarbacki.dev

Small Selenium + NUnit project written in C# that runs basic end-to-end checks against the live site.  
It’s connected to GitHub Actions so tests run automatically whenever the main site repo is updated.


## what this is

This isn’t a full-blown test framework. It’s just a lightweight safety net to make sure the site still works after changes.

The goal is simple:
pages should load, navigation shouldn’t break, and nothing obvious should be missing.


## stack

C# / .NET  
NUnit  
Selenium WebDriver  
GitHub Actions  


## running locally

```bash
dotnet restore
dotnet test
