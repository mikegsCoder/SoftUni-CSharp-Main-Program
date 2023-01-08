using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public interface IUsersService
    {
        string GetUserId(LoginInputModel login);

        bool IsUsernameAvailable(RegisterInputModel register);

    }
}
