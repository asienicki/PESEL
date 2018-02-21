namespace PESEL.Validators.Impl
{
    using System;
    using Models;
    using ValidationResults;
    using ValidationResults.Impl;
    
    public class BirthDateValidator : IValidator
    {
        public IValidationResult Validate(Entity entity)
        {
            var birthDate = GetDateFromPesel(entity.Pesel);

            if (!birthDate.HasValue)
            {
                return new InvalidDateValidator();
            }

            entity.PeselStruct.BirthDate = birthDate.Value;

            return new OkValidationResult();

        }

        public DateTime? GetDateFromPesel(string pesel)
        {
            var rok = int.Parse(pesel.Substring(0, 2));
            var miesiac = int.Parse(pesel.Substring(2, 2));
            var dzien = int.Parse(pesel.Substring(4, 2));

            if (miesiac < 1 || miesiac > 92)
            {
                return null;
            }

            if (miesiac >= 1 && miesiac <= 12) //zwykły miesiąc
            {
                rok += 1900;
            }
            else if (miesiac >= 21 & miesiac <= 32) //m + 20 dla 2000-2099
            {
                rok += 2000;
                miesiac -= 20;
            }
            else if (miesiac >= 41 && miesiac <= 52) // m+40 dla 2100 - 2199
            {
                rok += 2100;
                miesiac -= 40;
            }
            else if (miesiac >= 61 && miesiac <= 72) //m+60 dla 2200 - 2299
            {
                rok += 2200;
                miesiac -= 60;
            }
            else if (miesiac >= 81 && miesiac <= 92) //m+80 dla 1800 - 1899
            {
                rok += 1800;
                miesiac -= 80;
            }

            return new DateTime(rok, miesiac, dzien);
        }
    }
}