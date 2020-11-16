using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonReference.BL.Entities;

namespace NaturalPersonReference.DB.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.HasMany(x => x.RelatedPersons)
            //   .WithOne()
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
