using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SharedTrip.Services.ValidationService
{
    public class ValidationService : IValidationService
    {
        public ICollection<string> ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, errors, true);

            return errors
                .Select(e => e.ToString())
                .ToList();
        }
    }
}
