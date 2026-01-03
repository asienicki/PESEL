using PESEL.Models;
using PESEL.ValidationResults;
using PESEL.Validators;

namespace PESEL.Tests.DomainTests.Validators
{
    public class BaseValidatorTests<T> where T : IValidator, new()
    {

        public static IPeselValidationResult Validate(string pesel, out PeselEntity entity)
        {
            entity = new PeselEntity(pesel);
            return new T().Validate(entity);
        }
    }
}
