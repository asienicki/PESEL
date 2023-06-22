## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) 

Biblioteka umożliwia użycie gotowej metody do zwalidowania numeru PESEL, rozrzeszając bibliotekę do walidacji FluentValidation.

### Instalacja biblioteki
Biblioteka znajduje się w repozytorium ["NuGet Gallery"](https://www.nuget.org/packages/FluentValidation.PESEL). 
Paczkę można zainstalować wykonując poniższe polecenie:
```
Install-Package FluentValidation.PESEL
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

