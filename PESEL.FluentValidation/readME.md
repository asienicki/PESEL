## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 
Biblioteka umożliwia użycie gotowej metody do zwalidowania numeru PESEL, rozrzeszając bibliotekę do walidacji FluentValidation.

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) 

### Dokumentacja
- [Dokumentacja biblioteki PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL/readme.md)
- [Walidacja z użyciem atrybutów System.ComponentModel.DataAnnotation](https://github.com/asienicki/PESEL/blob/master/PESEL.System.ComponentModel.DataAnnotations/readME.md)
- [Walidacja numeru PESEL z wykorzystaniem biblioteki PESEL.FluentValidation](https://github.com/asienicki/PESEL/blob/master/PESEL.FluentValidation/readME.md)
- [Generowanie numerów PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)

### Instalacja biblioteki
Biblioteka znajduje się w repozytorium ["NuGet Gallery"](https://www.nuget.org/packages/FluentValidation.PESEL). 
Paczkę można zainstalować wykonując poniższe polecenie:
```
Install-Package PESEL.FluentValidation
```
### Przykładowe użycie biblioteki FluentValidation.PESEL

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

