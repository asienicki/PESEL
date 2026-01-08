[![CI](https://github.com/asienicki/PESEL/actions/workflows/ci.yml/badge.svg)](https://github.com/asienicki/PESEL/actions/workflows/ci.yml)
![License](https://img.shields.io/github/license/asienicki/PESEL)
![Last Commit](https://img.shields.io/github/last-commit/asienicki/PESEL)
![PRs](https://img.shields.io/github/issues-pr/asienicki/PESEL)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=coverage)](https://sonarcloud.io/summary/overall?id=asienicki_PESEL&branch=master)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=bugs)](https://sonarcloud.io/summary/overall?id=asienicki_PESEL&branch=master)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=code_smells)](https://sonarcloud.io/project/issues?issueStatuses=OPEN%2CCONFIRMED&id=asienicki_PESEL)

## PESEL (Universal Electronic System for Population Registration in Poland)

A .NET library for **validation** and **generation** of PESEL numbers, with modular integrations for popular validation mechanisms.

---

## 📦 Available NuGet Packages

| Package | Description |
|------|------|
| [![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) **PESEL** | Core library – PESEL number validation |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/) **PESEL.FluentValidation** | Integration with FluentValidation |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.System.ComponentModel.DataAnnotations.svg)](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations/) **PESEL.System.ComponentModel.DataAnnotations** | Validation based on DataAnnotations |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.Generator.svg)](https://www.nuget.org/packages/PESEL.Generator/) **PESEL.Generator** | Generation of valid PESEL numbers |

---

## 🎯 Supported Frameworks

![.NET Standard 2.0](https://img.shields.io/badge/.NET%20Standard-2.0-512BD4)
![.NET Standard 2.1](https://img.shields.io/badge/.NET%20Standard-2.1-512BD4)

---

## 📖 Documentation

### Library usage
- [PESEL core](PESEL/readme.md)
- [DataAnnotations integration](PESEL.System.ComponentModel.DataAnnotations/readME.md)
- [FluentValidation integration](PESEL.FluentValidation/readME.md)
- [PESEL generator](PESEL.Generator/readME.md)

### Project & process
- [Branching & Release Flow](docs/release-process.md)
- [Contributing guidelines](CONTRIBUTING.md)

---

## Design Decisions

### Minimal core
The core library is independent of validation frameworks; integrations are provided as separate packages.

### Explicit API
No hidden side effects or implicit exceptions — validation results are explicit and predictable.

### Compatibility and maintenance
Targets .NET Standard 2.0 / 2.1 to ensure broad compatibility and long-term stability.

---

## Explicitly Out of Scope

This library intentionally does not:
- “fix” invalid input data or mask validation errors,
- provide UI layers, APIs, or CLI tools,
- enforce a specific error-handling approach or application framework.

The scope of the library is deliberately narrow and focused solely on the correctness of PESEL numbers.
