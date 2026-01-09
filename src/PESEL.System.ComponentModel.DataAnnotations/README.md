## PESEL.System.ComponentModel.DataAnnotations

Integration package providing **PESEL number validation** using
`System.ComponentModel.DataAnnotations`.

[![NuGet](https://img.shields.io/nuget/v/PESEL.System.ComponentModel.DataAnnotations.svg)](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations/)

---

## Documentation
- [PESEL core library](../PESEL/README.md)
- [PESEL validation with FluentValidation](../PESEL.FluentValidation/README.md)
- [PESEL number generation](../PESEL.Generator/README.md)

---

## Installation

The package is available on the [NuGet Gallery](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations).

```powershell
Install-Package PESEL.System.ComponentModel.DataAnnotations
```

---

## Using the PESEL Attribute

Add the `Pesel` attribute to a model property.
`ModelState` will be valid only if the PESEL number is valid.

```csharp
using PESEL.Attributes;

public class Model
{
    [Pesel]
    public string Pesel { get; set; }
}
```

### Model Validation Example

```csharp
var model = new Model
{
    Pesel = "02070803628"
};

var context = new ValidationContext(model, null, null);
var validationResults = new List<ValidationResult>();

Assert.IsTrue(
    Validator.TryValidateObject(model, context, validationResults, true)
);
```
