using Microsoft.EntityFrameworkCore;
using NaturalPersonReference.BL.Entities;

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
            modelBuilder.Entity<RelatedPersons>()
             .HasKey(p => new { p.PersonId, p.RelatedPersonId });

            modelBuilder.Entity<RelatedPersons>()
               .HasOne(x => x.Person)
               .WithMany(x => x.RelatedFrom)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<RelatedPersons>()
               .HasOne(x => x.RelatedPerson)
               .WithMany(x => x.RelatedTo)
               .HasForeignKey(x => x.RelatedPersonId);

            modelBuilder.Entity<RelatedPersons>()
               .HasOne(x => x.Person)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
