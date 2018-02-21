using System.Collections.Generic;
using System.Linq;

namespace PESEL
{
    public class PeselValidator : IValidator
    {
        public IValidator[] Validators { get; set; }

        public byte Order => 0;

        public IEntity Entity { get; set; }

        public PeselValidator()
        {
            Validators = new IValidator[4];
        }

        public ValidationState IsValid(IEntity entity)
        {
            Validators = Validators.OrderBy(x => x.Order).ToArray();

            foreach (var validator in Validators)
            {
                validator.IsValid(entity);
            }

            return new ValidationState
            {
                IsValid = true
            };
        }
    }

    public class DigitValidator : IValidator
    {
        public byte Order => 1;
        public IEntity Entity { get; set; }
        
        public ValidationState IsValid(IEntity entity)
        {
            

            return new ValidationState
            {
                IsValid = true
            };
        }
    }
}
