using Microsoft.EntityFrameworkCore;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.DB.EntityConfigurations;

namespace NaturalPersonReference.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RelatedPersonConfiguration());
        }
    }
}
