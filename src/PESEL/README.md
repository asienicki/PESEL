## PESEL (Universal Electronic System for Population Registration in Poland)

A .NET library for **PESEL number validation**.

[![NuGet](https://img.shields.io/nuget/v/PESEL.svg)](https://www.nuget.org/packages/PESEL/)

---

## Documentation
- [Validation using System.ComponentModel.DataAnnotations](../PESEL.System.ComponentModel.DataAnnotations/README.md)
- [PESEL validation with FluentValidation](../PESEL.FluentValidation/README.md)
- [PESEL number generation](../PESEL.Generator/README.md)

---

## Installation

The library is available on the [NuGet Gallery](https://www.nuget.org/packages/PESEL).

```powershell
Install-Package PESEL
```

---

## PESEL Validation

A PESEL number can be validated using the **PeselValidator** class or the **PeselAttribute**, which can be applied to model properties.

### Using `PeselValidator`

```csharp
var validator = new PeselValidator();

var entity = new PeselEntity("02070803628");

var validationResult = validator.Validate(entity);

Assert.IsTrue(validationResult.IsValid);
```

The `ValidationResult` object also contains parsed information extracted from the PESEL number, such as **gender** and **date of birth**.

---

## Algorithm References

- https://obywatel.gov.pl/dokumenty-i-dane-osobowe/czym-jest-numer-pesel
- https://4programmers.net/Algorytmy/PESEL_-_everything_you_need_to_know
- http://www.szewo.com/php/pesel.phtml
- http://zylla.wipos.p.lodz.pl/ut/pesel.html
- https://en.wikipedia.org/wiki/PESEL

---

## Date of Birth Encoding

The date of birth is encoded numerically as:

```
YYMMDD
```

To distinguish between centuries, the following encoding rules are used:

- **1900–1999** → month encoded normally (`01–12`)
- **1800–1899** → month + 80
- **2000–2099** → month + 20
- **2100–2199** → month + 40
- **2200–2299** → month + 60

---

## Gender

Gender information is encoded in the **10th digit** (the second-to-last digit) of the PESEL number:

- `0, 2, 4, 6, 8` → female  
- `1, 3, 5, 7, 9` → male  

After a legal gender change, a **new PESEL number is issued**.

---

## Checksum Digit and Validation

The **11th digit** is a checksum digit used to detect errors.
It is calculated based on the first ten digits.

Let `a–j` represent consecutive digits of the PESEL number.
The checksum is calculated as:

```
9×a + 7×b + 3×c + 1×d + 9×e + 7×f + 3×g + 1×h + 9×i + 7×j
```

If the last digit of the result does not match the checksum digit, the PESEL number is invalid.

### Example

For the PESEL number `44051401358`:

```
9×4 + 7×4 + 3×0 + 1×5 + 9×1 + 7×4 + 3×0 + 1×1 + 9×3 + 7×5 = 169
```

```
169 % 10 = 9
```

Since `9 ≠ 8`, the PESEL number is invalid.

---

## Equivalent Validation Method

An equivalent method uses the following weighted sum:

```
1×a + 3×b + 7×c + 9×d + 1×e + 3×f + 7×g + 9×h + 1×i + 3×j + 1×k
```

If the last digit of the result is `0`, the PESEL number is valid.
Otherwise, it is invalid.

---

## Algorithm Limitations

The checksum algorithm has known limitations:

- swapping year and day (`yy-mm-dd` ↔ `dd-mm-yy`) may produce the same checksum
- the algorithm does **not validate semantic correctness** of the data

Due to the checksum properties, a missing digit can sometimes be reconstructed.

---

## Errors in PESEL Assignment

In practice, PESEL numbers with errors have existed, including:

- incorrect birth dates
- duplicated serial numbers
- incorrect gender encoding
- invalid checksum digits

Some of these issues were discovered years later during data migration.
Therefore, a successful checksum validation **does not guarantee** that a PESEL number was officially assigned.

A PESEL number can be changed in cases such as:

- legal gender change
- issuance of a new birth certificate
- administrative errors

In 2012, administrative mistakes resulted in the same PESEL number being assigned to different individuals in approximately 2,000 cases.
