using Microsoft.EntityFrameworkCore;

namespace IRunes.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        { 
        }
        public ApplicationDbContext(DbContextOptions db)
            : base(db)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=IRunes;Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}