using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
