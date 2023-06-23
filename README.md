## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 
Projekt umożliwia walidację oraz generowanie numerów PESEL.

- [![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/)  PESEL
- [![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/) PESEL.FluentValidation
- [![NuGet](https://img.shields.io/nuget/v/PESEL.System.ComponentModel.DataAnnotations.svg)](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations/) PESEL.System.ComponentModel.DataAnnotations
- [![NuGet](https://img.shields.io/nuget/v/PESEL.Generator.svg)](https://www.nuget.org/packages/PESEL.Generator/) PESEL.Generator

## Biblioteki usprawniające użycie biblioteki PESEL
- [Walidacja z użyciem atrybutów System.ComponentModel.DataAnnotation](https://github.com/asienicki/PESEL/blob/master/PESEL.System.ComponentModel.DataAnnotations/readME.md)
- [Walidacja numeru PESEL z wykorzystaniem biblioteki PESEL.FluentValidation](https://github.com/asienicki/PESEL/blob/master/PESEL.FluentValidation/readME.md)
- [Generowanie numerów PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)

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
