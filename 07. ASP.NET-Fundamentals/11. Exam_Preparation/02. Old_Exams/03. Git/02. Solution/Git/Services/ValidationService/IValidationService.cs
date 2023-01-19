using System.Collections.Generic;

namespace Git.Services.ValidationService
{
    public interface IValidationService
    {
        ICollection<string> ValidateModel(object model);
    }
}
