using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static HouseRentingSystem.Services.Data.Constants;

namespace HouseRentingSystem.Services.Data
{
    public class HouseRentingDbContext : IdentityDbContext<User>
    {
        private User AdminUser { get; set; }
        private Agent AdminAgent { get; set; }

        private User AgentUser { get; set; }
        private User GuestUser { get; set; }
        private Agent Agent { get; set; }
        private Category CottageCategory { get; set; }
        private Category SingleCategory { get; set; }
        private Category DuplexCategory { get; set; }
        private House FirstHouse { get; set; }
        private House SecondHouse { get; set; }
        private House ThirdHouse { get; set; }

        public HouseRentingDbContext
            (DbContextOptions<HouseRentingDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<House> Houses { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Agent> Agents { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<House>()
               .HasOne(h => h.Category)
               .WithMany(c => c.Houses)
               .HasForeignKey(h => h.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<House>()
               .HasOne(h => h.Agent)
               .WithMany()
               .HasForeignKey(h => h.AgentId)
               .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<User>()
                    .HasData(this.AgentUser,
                    this.GuestUser,
                    this.AdminUser);

            SeedAgent();
            builder.Entity<Agent>()
                    .HasData(this.Agent,
                    this.AdminAgent);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<User>();

            this.AgentUser = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Linda",
                LastName = "Michaels"
            };

            this.AgentUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "agent123");

            this.GuestUser = new User()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Teodor",
                LastName = "Lesly"
            };

            this.GuestUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "guest123");

            this.AdminUser = new User()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                FirstName = "Great",
                LastName = "Admin"
            };

            this.AdminUser.PasswordHash =
                hasher.HashPassword(this.AgentUser, "admin123");
        }

        private void SeedAgent()
        {
            this.Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = this.AgentUser.Id
            };

            this.AdminAgent = new Agent()
            {
                Id = 6,
                PhoneNumber = "+359123456789",
                UserId = this.AdminUser.Id
            };
        }
    }
}


