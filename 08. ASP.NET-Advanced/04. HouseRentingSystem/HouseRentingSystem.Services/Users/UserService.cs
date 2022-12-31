using HouseRentingSystem.Services.Data;

namespace HouseRentingSystem.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext data;

        public UserService(HouseRentingDbContext data)
            => this.data = data;

        public string UserFullName(string userId)
        {
            var user = this.data.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) 
                || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}


