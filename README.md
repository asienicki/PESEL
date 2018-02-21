## Powszechny Elektroniczny System Ewidencji Ludności (PESEL) 

Projekt umożliwia walidację oraz generowanie numerów PESEL.

### Walidacja pesel
PESEL można zwalidować przy użyciu klasy PeselValidator lub atrybutu: PeselAttribute, którym to można dekorować właściwości modelu.

#### Wykorzystanie klasy PeselValidator
```csharp
var validator = new PeselValidator();

var entity = new Entity("02070803628");

var validationResult = validator.Validate(entity);

Assert.IsTrue(validationResult.IsValid);
```
Obiekt ValidationResult przechowuje również informację o strukturze PESEL. Można z niej pobrać płeć oraz datę urodzenia.

#### Wykorzystanie atrybutu Pesel

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



