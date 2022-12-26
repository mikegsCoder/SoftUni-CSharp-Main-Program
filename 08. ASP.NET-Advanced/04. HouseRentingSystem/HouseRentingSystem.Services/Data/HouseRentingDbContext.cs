using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data
{
    public class HouseRentingDbContext : IdentityDbContext<IdentityUser>
    {
        public HouseRentingDbContext
            (DbContextOptions<HouseRentingDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}


