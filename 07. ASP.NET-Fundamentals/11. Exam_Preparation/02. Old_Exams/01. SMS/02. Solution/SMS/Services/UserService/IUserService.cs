using SMS.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace SMS.Services.UserService
{
    public interface IUserService
    {
        ICollection<string> Register(RegisterViewModel model);

        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
