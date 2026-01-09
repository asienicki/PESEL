## PESEL.Generator

A .NET library for **generating valid PESEL numbers**.

[![NuGet](https://img.shields.io/nuget/v/PESEL.Generator.svg)](https://www.nuget.org/packages/PESEL.Generator/)

---

## Documentation
- [PESEL core library](../PESEL/README.md)
- [DataAnnotations integration](../PESEL.System.ComponentModel.DataAnnotations/README.md)
- [FluentValidation integration](../PESEL.FluentValidation/README.md)

---

## Installation

The package is available on the [NuGet Gallery](https://www.nuget.org/packages/PESEL.Generator).

```powershell
Install-Package PESEL.Generator
```

---

## Generating PESEL Numbers

The library allows generating **all valid PESEL number combinations** for a given date of birth.

PESEL numbers are generated using the `Generate` method from the `PeselGenerator` class.

```csharp
var generator = new PeselGenerator();

var peselList = generator.Generate(DateTime.Now.AddYears(-1));
```
