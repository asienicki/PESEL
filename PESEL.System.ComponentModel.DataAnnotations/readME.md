## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 
Projekt umożliwia walidację oraz generowanie numerów PESEL.
[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) 

### Dokumentacja
- [Dokumentacja biblioteki PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL/readme.md)
- [Walidacja numeru PESEL z wykorzystaniem biblioteki PESEL.FluentValidation](https://github.com/asienicki/PESEL/blob/master/PESEL.FluentValidation/readME.md)
- [Generowanie numerów PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)

### Instalacja biblioteki
Biblioteka znajduje się w repozytorium ["NuGet Gallery"](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations). Paczkę można zainstalować wykonując poniższe polecenie:
```
Install-Package PESEL.System.ComponentModel.DataAnnotations
```
#### Wykorzystanie atrybutu PESEL
Dodajemy atrybut do właściwości w modelu. 
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
