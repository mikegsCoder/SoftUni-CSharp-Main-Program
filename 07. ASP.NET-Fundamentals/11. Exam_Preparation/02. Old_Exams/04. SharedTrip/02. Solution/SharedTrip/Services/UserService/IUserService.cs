using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services.UserService
{
    public interface IUserService
    {
        ICollection<string> Register(RegisterViewModel model);

        string Login(LoginViewModel model);
    }
}
