using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class RelatedPersonsRepository : Repository<RelatedPersons>, IRelatedPersonsRepository
    {
        public RelatedPersonsRepository(DataContext context) : base(context)
        {

        }

        public DataContext RelatedPersonContext => Context as DataContext;

    }
}
