using AssaTest.Domain; 
using Microsoft.EntityFrameworkCore; 

namespace AssaTest.Infrastruture.Contexts
{
    public class AppAssaContext : DbContext // Define the database context class
    {
        #region Public Constructors

        public AppAssaContext(DbContextOptions<AppAssaContext> options) : base(options)
        {
            // Constructor that receives DbContextOptions and passes them to the base DbContext
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<CarBrand> CarBrands { get; set; } // DbSet for the CarBrand entity/table

        #endregion Public Properties

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data into the CarBrand entity/table
            modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand { Id = 1, Name = "Toyota", Description = "Toyota car brand", Year = 2022 },
                new CarBrand { Id = 2, Name = "Ford", Description = "Ford car brand", Year = 2021 },
                new CarBrand { Id = 3, Name = "BMW", Description = "BMW car brand", Year = 2020 }
            );
        }

        #endregion Protected Methods
    }
}
