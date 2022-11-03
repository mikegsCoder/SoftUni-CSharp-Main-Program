using Library.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUserBook> ApplicationUsersBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // UserName resrictions for ApplicationUser from description:
            builder.Entity<ApplicationUser>()
                .Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();

            // Email resrictions for ApplicationUser from description:
            builder.Entity<ApplicationUser>()
                .Property(x => x.Email)
                .HasMaxLength(60)
                .IsRequired();

            // composite key for ApplicationUserBook:
            builder.Entity<ApplicationUserBook>()
                .HasKey(x => new { x.ApplicationUserId, x.BookId });

            // selecting decimal props:
            var decimalProps = builder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            // setting decimal props scale and precision:
            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            // data seeding:
            builder
               .Entity<Book>()
               .HasData(new Book()
               {
                   Id = 5,
                   Title = "Lorem Ipsum",
                   Author = "Dolor Sit",
                   ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                   CategoryId = 1,
                   Rating = 9.5m
               });

            builder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Biography"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Children"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Crime"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fantasy"
                });

            base.OnModelCreating(builder);
        }
    }
}