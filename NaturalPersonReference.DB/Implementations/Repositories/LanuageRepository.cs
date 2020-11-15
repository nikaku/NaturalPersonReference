using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class LanuageRepository : Repository<Language>, ILanguageRepository
    {
        public LanuageRepository(DataContext context) : base(context)
        {
        }
        private DataContext LanguageContext => Context as DataContext;

    }
}
