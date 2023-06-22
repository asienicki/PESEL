## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) 

Projekt umożliwia walidację oraz generowanie numerów PESEL.

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