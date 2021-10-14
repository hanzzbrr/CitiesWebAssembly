using CitiesBlazorProgressive.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace CitiesBlazorProgressive.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            Database.EnsureCreated();            
        }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                    new City { ID = 1, Name = "Yekaterinburg", FoundationDate = new DateTime(1723, 11, 18) },
                    new City { ID = 2, Name = "Moscow", FoundationDate = new DateTime(1147, 4, 11) },
                    new City { ID = 3, Name = "New York", FoundationDate = new DateTime(1624, 1, 1) },
                    new City { ID = 4, Name = "Saint Petersburg", FoundationDate = new DateTime(1703, 5, 27) },
                    new City { ID = 5, Name = "Berlin", FoundationDate = new DateTime(1237, 1, 1) }
                );
        }        
    }
}
