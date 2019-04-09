## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) [![Build Status](https://travis-ci.com/asienicki/PESEL.svg?branch=master)](https://travis-ci.com/asienicki/PESEL) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=alert_status)](https://sonarcloud.io/dashboard?id=asienicki_PESEL) [![Build status](https://ci.appveyor.com/api/projects/status/2fi7tdwy7wx25b9i?svg=true)](https://ci.appveyor.com/project/asienicki/pesel) [![Build Status](https://indesign.visualstudio.com/Projects/_apis/build/status/asienicki.PESEL?branchName=master)](https://indesign.visualstudio.com/Projects/_build/latest?definitionId=6&branchName=master)

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

var entity = new Entity("02070803628");

var validationResult = validator.Validate(entity);

Assert.IsTrue(validationResult.IsValid);
```
Obiekt ValidationResult przechowuje również informację o strukturze PESEL. Można z niej pobrać płeć oraz datę urodzenia.

#### Wykorzystanie atrybutu PESEL

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

### Generowanie numerów PESEL

Biblioteka umożliwia wygenerowanie kombinacji wszystkich numerów PESEL dla podanej daty urodzenia.
Do generowania numerów PESEL służy metoda Generate z klasy Generator.
```csharp
var generator = new Generator();

var peselList = generator.Generate(DateTime.Now.AddYears(-1));
```
