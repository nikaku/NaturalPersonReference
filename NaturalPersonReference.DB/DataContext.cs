using Microsoft.EntityFrameworkCore;
using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.DB.EntityConfigurations;
using System;

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
        public DbSet<Language> Languages { get; set; }
        public DbSet<LocaleResource> LocaleResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RelatedPersonConfiguration());

            modelBuilder.Entity<City>()
                .HasData(
                new City { Id = 1, CityName = "Tbilisi" },
                new City { Id = 2, CityName = "Kutaisi" },
                new City { Id = 3, CityName = "Batumi" });

            modelBuilder.Entity<Language>()
                .HasData(
                new Language { Id = 1, Name = "GEO" },
                new Language { Id = 2, Name = "ENG" });

            modelBuilder.Entity<LocaleResource>()
               .HasData(
               new LocaleResource { Id = 1, LanguageId = 1, ResourceName = "FirstName.Error", ResourceValue = "არავალლიდური სახელი" },
               new LocaleResource { Id = 2, LanguageId = 2, ResourceName = "FirstName.Error", ResourceValue = "First Name is not valid" });

            modelBuilder.Entity<Phone>()
               .HasData(
                 new Phone { Id = 1, PhoneNumber = "551551551", Type = BL.Enums.PhoneType.Home },
                 new Phone { Id = 2, PhoneNumber = "551551552", Type = BL.Enums.PhoneType.Mobile },
                 new Phone { Id = 3, PhoneNumber = "551551553", Type = BL.Enums.PhoneType.Mobile },
                 new Phone { Id = 4, PhoneNumber = "551551554", Type = BL.Enums.PhoneType.Home },
                 new Phone { Id = 5, PhoneNumber = "551551555", Type = BL.Enums.PhoneType.Mobile },
                 new Phone { Id = 6, PhoneNumber = "551551544", Type = BL.Enums.PhoneType.Office }
              );


            modelBuilder.Entity<Person>()
              .HasData(
                new Person { Id = 1, BirthDate = new DateTime(1995, 03, 03), CityId = 1, FirstName = "Nika", LastName = "Kurdadze", Gender = BL.Enums.Gender.Female, PhoneId = 1, Tin = "57001057458" },
                new Person { Id = 2, BirthDate = new DateTime(1994, 03, 03), CityId = 2, FirstName = "Vazha", LastName = "Jambazishvili", Gender = BL.Enums.Gender.Female, PhoneId = 2, Tin = "57001057451" },
                new Person { Id = 3, BirthDate = new DateTime(1994, 03, 03), CityId = 1, FirstName = "Beka", LastName = "Latsabidze", Gender = BL.Enums.Gender.Male, PhoneId = 3, Tin = "57001057458" },
                new Person { Id = 4, BirthDate = new DateTime(1994, 03, 03), CityId = 3, FirstName = "Giga", LastName = "Grigalashvili", Gender = BL.Enums.Gender.Female, PhoneId = 1, Tin = "57001057428" },
                new Person { Id = 5, BirthDate = new DateTime(1994, 03, 03), CityId = 1, FirstName = "Zura", LastName = "Adghuladze", Gender = BL.Enums.Gender.Female, PhoneId = 4, Tin = "77701052458" },
                new Person { Id = 6, BirthDate = new DateTime(1994, 03, 03), CityId = 3, FirstName = "Goderdzi", LastName = "Lominashvili", Gender = BL.Enums.Gender.Female, PhoneId = 5, Tin = "57001057451" }
             );

            modelBuilder.Entity<RelatedPersons>()
               .HasData(
                 new RelatedPersons { PersonId = 1, RelatedPersonId = 2, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 4, RelatedPersonId = 5, ConnectionType = BL.Enums.ConnectionType.Colleague },
                 new RelatedPersons { PersonId = 3, RelatedPersonId = 6, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 5, RelatedPersonId = 2, ConnectionType = BL.Enums.ConnectionType.Relative },
                 new RelatedPersons { PersonId = 1, RelatedPersonId = 3, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 1, RelatedPersonId = 4, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 1, RelatedPersonId = 5, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 1, RelatedPersonId = 6, ConnectionType = BL.Enums.ConnectionType.Other },
                 new RelatedPersons { PersonId = 2, RelatedPersonId = 4, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 3, RelatedPersonId = 2, ConnectionType = BL.Enums.ConnectionType.Acquaintance },
                 new RelatedPersons { PersonId = 3, RelatedPersonId = 4, ConnectionType = BL.Enums.ConnectionType.Relative },
                 new RelatedPersons { PersonId = 3, RelatedPersonId = 5, ConnectionType = BL.Enums.ConnectionType.Acquaintance }
              );
        }
    }
}
