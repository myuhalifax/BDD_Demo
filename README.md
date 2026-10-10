# BDD_Demo

A minimal behavior-driven (BDD) test automation demo in **C# + SpecFlow + Gherkin** — showing how business-readable scenarios map to executable test steps.

## What's inside

- `Features/Login.feature` — login scenarios in Gherkin (Given / When / Then)
- `Steps/` — C# step definitions binding Gherkin steps to automation code
- `BDD_Demo.csproj` — .NET project wired for SpecFlow + NUnit execution

## Prerequisites

- .NET 6 SDK or later

## Run it

dotnet test

## Why this exists

Built while evaluating BDD tooling (SpecFlow / Playwright) — a compact reference for structuring Gherkin features, step bindings, and test runs in a .NET pipeline. Mirrors the BDD approach (SpecFlow / Cucumber) from my professional QA work.
