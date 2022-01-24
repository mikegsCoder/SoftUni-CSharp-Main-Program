using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
	public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Station> Stations { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<TrainSeat> TrainSeats { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CustomerCard> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<SeatingClass>(seatingClass =>
            {
                seatingClass.HasAlternateKey(x => new { x.Name, x.Abbreviation });

                seatingClass.Property(s => s.Abbreviation)
                .HasColumnType("nchar(2)");
            });

            modelBuilder.Entity<Station>(station =>
            {
                station.HasIndex(s => s.Name)
                .IsUnique();

                station.HasMany(s => s.TripsTo)
                .WithOne(t => t.DestinationStation)
                .HasForeignKey(t => t.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

                station.HasMany(s => s.TripsFrom)
                .WithOne(t => t.OriginStation)
                .HasForeignKey(t => t.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Train>(train =>
            {
                train.HasIndex(s => s.TrainNumber)
                .IsUnique();
            });
        }
	}
}