![License](https://img.shields.io/github/license/asienicki/PESEL)
![Last Commit](https://img.shields.io/github/last-commit/asienicki/PESEL)
![PRs](https://img.shields.io/github/issues-pr/asienicki/PESEL)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=coverage)](https://sonarcloud.io/summary/overall?id=asienicki_PESEL&branch=master)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=bugs)](https://sonarcloud.io/summary/overall?id=asienicki_PESEL&branch=master)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=asienicki_PESEL&metric=code_smells)](https://sonarcloud.io/project/issues?issueStatuses=OPEN%2CCONFIRMED&id=asienicki_PESEL)


## Powszechny Elektroniczny System Ewidencji Ludności (PESEL)
Biblioteka .NET do **walidacji** oraz **generowania** numerów PESEL, z modularnymi integracjami dla popularnych mechanizmów walidacji.

## 📦 Dostępne pakiety NuGet
| Pakiet | Opis |
|------|------|
| [![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) **PESEL** | Rdzeń biblioteki – walidacja numeru PESEL |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.FluentValidation.svg)](https://www.nuget.org/packages/PESEL.FluentValidation/) **PESEL.FluentValidation** | Integracja z FluentValidation |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.System.ComponentModel.DataAnnotations.svg)](https://www.nuget.org/packages/PESEL.System.ComponentModel.DataAnnotations/) **PESEL.System.ComponentModel.DataAnnotations** | Walidacja oparta o DataAnnotations |
| [![NuGet](https://img.shields.io/nuget/v/PESEL.Generator.svg)](https://www.nuget.org/packages/PESEL.Generator/) **PESEL.Generator** | Generowanie poprawnych numerów PESEL |

## 🎯 Obsługiwane frameworki

![.NET Standard 2.0](https://img.shields.io/badge/.NET%20Standard-2.0-512BD4) ![.NET Standard 2.1](https://img.shields.io/badge/.NET%20Standard-2.1-512BD4)

## 📖 Dokumentacja

- [Biblioteka PESEL (core)](https://github.com/asienicki/PESEL/blob/master/PESEL/readme.md)
- [Walidacja z użyciem DataAnnotations](https://github.com/asienicki/PESEL/blob/master/PESEL.System.ComponentModel.DataAnnotations/readME.md)
- [Walidacja z użyciem FluentValidation](https://github.com/asienicki/PESEL/blob/master/PESEL.FluentValidation/readME.md)
- [Generowanie numerów PESEL](https://github.com/asienicki/PESEL/blob/master/PESEL.Generator/readME.md)

## Decyzje projektowe
### Minimalny rdzeń
Rdzeń biblioteki jest niezależny od frameworków walidacyjnych; integracje są wydzielone do osobnych pakietów.
### Jawne API
Brak ukrytych efektów ubocznych i automatycznych wyjątków — wynik walidacji jest jednoznaczny i przewidywalny.
### Kompatybilność i utrzymanie
Targetowanie .NET Standard 2.0 / 2.1 w celu zapewnienia szerokiej kompatybilności i stabilności w długoterminowych projektach.

## Założenia wykluczające
Biblioteka celowo nie:
- „naprawia” niepoprawnych danych wejściowych ani nie maskuje błędów,
- udostępnia warstwy UI, API ani narzędzi CLI,
- narzuca sposobu obsługi błędów lub konkretnego frameworka aplikacyjnego.
Zakres biblioteki jest świadomie wąski i skupiony wyłącznie na poprawności numeru PESEL.
