## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) - PESEL Generator

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL.Generator/) 

Biblioteka umożliwia generowanie numerów PESEL.

### Instalacja biblioteki
Biblioteka znajduje się w repozytorium ["NuGet Gallery"](https://www.nuget.org/packages/PESEL.Generator). 
Paczkę można zainstalować wykonując poniższe polecenie:
```
Install-Package PESEL.Generator
```
### Generowanie numerów PESEL

Biblioteka umożliwia wygenerowanie kombinacji wszystkich numerów PESEL dla podanej daty urodzenia.
Do generowania numerów PESEL służy metoda Generate z klasy PeselGenerator.
```csharp
var generator = new PeselGenerator();

var peselList = generator.Generate(DateTime.Now.AddYears(-1));
```