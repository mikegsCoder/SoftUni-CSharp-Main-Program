using System.Collections.Generic;

namespace SharedTrip.Services.ValidationService
{
    public interface IValidationService
    {
        ICollection<string> ValidateModel(object model);
    }
}
