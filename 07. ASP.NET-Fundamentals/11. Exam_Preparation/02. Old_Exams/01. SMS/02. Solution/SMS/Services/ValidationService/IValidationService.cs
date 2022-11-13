using System.Collections.Generic;

namespace SMS.Services.ValidationService
{
    public interface IValidationService
    {
        ICollection<string> ValidateModel(object model);
    }
}
