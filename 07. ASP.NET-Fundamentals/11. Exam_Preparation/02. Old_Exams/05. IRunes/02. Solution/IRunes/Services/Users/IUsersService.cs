using IRunes.ViewModels.Users;

namespace IRunes.Services.Users
{
    public interface IUsersService
    {
        void Create(RegisterInputModel register);

        bool IsUsernameAvailable(RegisterInputModel register);

        bool IsEmailAvailable(RegisterInputModel registerl);
    }
}
