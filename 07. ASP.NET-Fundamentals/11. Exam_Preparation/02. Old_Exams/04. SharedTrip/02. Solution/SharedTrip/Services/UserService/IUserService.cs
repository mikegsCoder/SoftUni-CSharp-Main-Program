using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services.UserService
{
    public interface IUserService
    {
        ICollection<string> Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}
