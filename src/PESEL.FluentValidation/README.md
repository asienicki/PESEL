## PESEL.FluentValidation

Integration package providing **PESEL number validation** using the
[FluentValidation](https://github.com/FluentValidation/FluentValidation) library.

[![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/)

---

## Documentation
- [PESEL core library](../PESEL/README.md)
- [DataAnnotations integration](../PESEL.System.ComponentModel.DataAnnotations/README.md)
- [PESEL number generation](../PESEL.Generator/README.md)

---

## Installation

The package is available on the [NuGet Gallery](https://www.nuget.org/packages/PESEL.FluentValidation).

```powershell
Install-Package PESEL.FluentValidation
```

---

## FluentValidation Usage Example

```csharp
using FluentValidation;
using FluentValidation.PESEL;

public class Customer
{
    public string Pesel { get; set; }
}

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Pesel).PeselMustBeValid();
    }
}
```
