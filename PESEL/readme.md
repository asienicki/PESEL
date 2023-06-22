## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/) 

Biblioteka umożliwia walidację oraz generowanie numerów PESEL.

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

### Referencje do algorytmu wyliczającego poprawność numeru PESEL - źródła
https://obywatel.gov.pl/dokumenty-i-dane-osobowe/czym-jest-numer-pesel
https://4programmers.net/Algorytmy/PESEL_-_wszystko,_co_o_nim_mo%C5%BCesz_wiedzie%C4%87
http://www.szewo.com/php/pesel.phtml
http://zylla.wipos.p.lodz.pl/ut/pesel.html
https://pl.wikipedia.org/wiki/PESEL

### Data urodzenia
Numeryczny zapis daty urodzenia przedstawiony jest w następującym porządku: dwie ostatnie cyfry roku, miesiąc i dzień. Dla odróżnienia poszczególnych stuleci przyjęto następującą metodę kodowania:

dla osób urodzonych w latach 1900 do 1999 – miesiąc zapisywany jest w sposób naturalny, tzn. dwucyfrowo od 01 do 12
dla osób urodzonych w innych latach niż 1900–1999 dodawane są do numeru miesiąca następujące wielkości:
dla lat 1800–1899 – 80
dla lat 2000–2099 – 20
dla lat 2100–2199 – 40
dla lat 2200–2299 – 60


### Płeć
Informacja o płci osoby, której zestaw informacji jest identyfikowany, zawarta jest na 10 - (przedostatniej) pozycji numeru PESEL.

cyfry 0, 2, 4, 6, 8 – oznaczają płeć żeńską
cyfry 1, 3, 5, 7, 9 – oznaczają płeć męską
Po zmianie płci przydzielany jest nowy numer PESEL.

### Cyfra kontrolna i sprawdzanie poprawności numeru
Jedenasta cyfra jest cyfrą kontrolną, służącą do wychwytywania przekłamań numeru. 
Jest ona generowana na podstawie pierwszych dziesięciu cyfr. 
Aby sprawdzić czy dany numer PESEL jest prawidłowy, należy, zakładając, że litery a-j to kolejne cyfry numeru od lewej, obliczyć wyrażenie:

```
9×a + 7×b + 3×c + 1×d + 9×e + 7×f + 3×g + 1×h + 9×i + 7×j
```
Jeżeli ostatnia cyfra otrzymanego wyniku nie jest równa cyfrze kontrolnej, to znaczy, że numer zawiera błąd.

Przykład dla numeru PESEL 44051401358:
```
9×4 + 7×4 + 3×0 + 1×5 + 9×1 + 7×4 + 3×0 + 1×1 + 9×3 + 7×5 = 169
```
Wyznaczamy resztę z dzielenia sumy przez 10:
```
169:10 = 16 reszta = 9
```
Wynik 9 nie jest równy ostatniej cyfrze numeru PESEL, czyli 8, więc numer jest błędny.

Metoda równoważna

Powyższa metoda sprowadza się do obliczenia sumy:
```
1×a + 3×b + 7×c + 9×d + 1×e + 3×f + 7×g + 9×h + 1×i + 3×j + 1×k
```
(gdzie litery oznaczają kolejne cyfry numeru), a następnie sprawdzenia czy reszta z dzielenia przez 10 jest zerem. 
Innymi słowy, jeśli ostatnia cyfra otrzymanej sumy jest zerem, to numer PESEL jest poprawny, w przeciwnym razie numer jest błędny.

Cechy specyficzne algorytmu sprawdzania

Algorytm ma pewną wadę w przydziale wag do poszczególnych elementów,
która powoduje, że gdy zamienimy rok z dniem (zamieniając zapis z rr-mm-dd na dd-mm-rr) 
otrzymamy identyczną sumę kontrolną jak w numerze z poprawnym zapisem. 
Ten Algorytm nie sprawdza sensowności danych.

Z zasady działania cyfry kontrolnej wynika, że w przypadku zamazania którejkolwiek cyfry w numerze PESEL można tę cyfrę odtworzyć.

### Błędy w nadawaniu numeru PESEL
W praktyce zdarzają się (a przynajmniej zdarzały i wciąż istnieją) numery PESEL z błędami. 
Błędy w dacie zwykle były zauważane i poprawiane od razu, lecz zdarzały się też powtórzenia numeru porządkowego, 
błędy w określeniu płci i błędne cyfry kontrolne, 
które zostały wychwycone po latach przy okazji wprowadzania numeru PESEL do komputerowych baz danych. 
W związku z tym nie można zakładać, że wynik sprawdzania jednoznacznie określa istnienie bądź nieistnienie podanego numeru PESEL.

Numer PESEL można zmienić. 
Powodem do zmiany są przypadki, gdy nastąpiła zmiana płci, osoba ma nowy akt urodzenia lub decyzja urzędu okazała się błędna.
W wyniku błędów urzędników w 2012 roku ten sam numer nadano różnym osobom w 2 tys. przypadków.