using IRunes.Data;
using IRunes.Data.Models;
using IRunes.ViewModels.Users;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IRunes.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(RegisterInputModel register)
        {
            var user = new User
            {
                Username = register.Username,
                Email = register.Email,
                Password = ComputeHash(register.Password)
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool IsUsernameAvailable(RegisterInputModel register)
        {
            return !db.Users.Any(x => x.Username == register.Username);
        }

        public bool IsEmailAvailable(RegisterInputModel register)
        {
            return !db.Users.Any(x => x.Email == register.Email);
        }

        private string ComputeHash(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);

                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));

                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
