using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaturalPersonReference.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.EntityConfigurations
{
    public class RelatedPersonConfiguration : IEntityTypeConfiguration<RelatedPersons>
    {
        public void Configure(EntityTypeBuilder<RelatedPersons> builder)
        {
            builder.HasKey(p => new { p.PersonId, p.RelatedPersonId });

            builder.HasOne(x => x.Person)
               .WithMany(x => x.RelatedPersons)
               .HasForeignKey(x => x.PersonId);

            builder.HasOne(x => x.Person)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
