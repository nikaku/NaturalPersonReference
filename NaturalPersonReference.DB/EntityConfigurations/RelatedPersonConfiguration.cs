using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonReference.BL.Entities;

namespace NaturalPersonReference.DB.EntityConfigurations
{
    public class RelatedPersonConfiguration : IEntityTypeConfiguration<RelatedPersons>
    {
        public void Configure(EntityTypeBuilder<RelatedPersons> builder)
        {
            builder.HasKey(p => new { p.PersonId, p.RelatedPersonId });

            builder.HasOne(x => x.Person)
               .WithMany(x => x.RelatedPersons)
               .HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RelatedPerson)
               .WithMany(x => x.RelatedPersonsFrom)
               .HasForeignKey(x => x.RelatedPersonId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
