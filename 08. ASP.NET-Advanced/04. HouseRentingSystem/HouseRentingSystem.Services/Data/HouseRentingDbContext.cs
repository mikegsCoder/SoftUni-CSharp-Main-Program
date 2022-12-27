﻿using HouseRentingSystem.Services.Data.Entities;
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
        }
    }
}


