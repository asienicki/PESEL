## PESEL.FluentValidation

Integration package providing **PESEL number validation** using the
[FluentValidation](https://github.com/FluentValidation/FluentValidation) library.

[![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/)

---

## Documentation

- [PESEL core library](https://github.com/asienicki/PESEL/blob/master/PESEL/readme.md)
- [DataAnnotations integration](https://github.com/asienicki/PESEL/blob/master/PESEL.System.ComponentModel.DataAnnotations/readME.md)
- [PESEL number generation](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)

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
