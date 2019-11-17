using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campaign.Models;

namespace Campaign.Data
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
        {
        }

        public DbSet<Campaign1> Campaigns { get; set; }
        public DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Campaign.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>().HasData(
                new Town { Id = 1, Name = "Rzeszów" },
                new Town { Id = 2, Name = "Kraków" },
                new Town { Id = 3, Name = "Warszawa" },
                new Town { Id = 4, Name = "Katowice" },
                new Town { Id = 5, Name = "Gdańsk" },
                new Town { Id = 6, Name = "Lublin" }
                );
        }



    }
}
