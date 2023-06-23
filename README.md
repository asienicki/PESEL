## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

- [![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/)  PESEL
- [![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/) PESEL.FluentValidation
- [![NuGet](https://img.shields.io/nuget/v/PESEL.System.ComponentModel.DataAnnotations.svg)](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations/) PESEL.System.ComponentModel.DataAnnotations
- [![NuGet](https://img.shields.io/nuget/v/PESEL.Generator.svg)](https://www.nuget.org/packages/PESEL.Generator/) PESEL.Generator


Projekt umożliwia walidację oraz generowanie numerów PESEL.

### Instalacja biblioteki
Biblioteka znajduje się w repozytorium ["NuGet Gallery"](https://www.nuget.org/packages/PESEL). Paczkę można zainstalować wykonując poniższe polecenie:
```
Install-Package PESEL
```
### Walidacja pesel
PESEL można zwalidować przy użyciu klasy **PeselValidator** lub atrybutu **PeselAttribute** w którym można dekorować właściwości modelu.

#### Wykorzystanie klasy PeselValidator
```csharp
var validator = new PeselValidator();

var entity = new PeselEntity("02070803628");

var validationResult = validator.Validate(entity);

Assert.IsTrue(validationResult.IsValid);
```
Obiekt ValidationResult przechowuje również informację o strukturze PESEL. Można z niej pobrać płeć oraz datę urodzenia.

#### Wykorzystanie atrybutu PESEL - biblioteka PESEL.System.ComponentModel.DataAnnotation

Dodajemy atrybut do właściwości w modelu i koniec. 
ModelState będzie poprawny tylko wtedy jeśli PESEL zostanie poprawnie zwalidowany.
```csharp
using PESEL.Attributes;

public class Model
{
    [Pesel]
    public string Pesel { get; set; }
}
```
Adekwatny test do wykonania ModelState.IsValid:
```csharp
var model = new Model
{
    Pesel = "02070803628"
};

var context = new ValidationContext(model, null, null);
var validationResults = new List<ValidationResult>();

Assert.IsTrue(Validator.TryValidateObject(model, context, validationResults, true));
```

#### Walidacja numeru PESEL z wykorzystaniem biblioteki PESEL.FluentValidation
```
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

### [Generowanie numerów PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)
