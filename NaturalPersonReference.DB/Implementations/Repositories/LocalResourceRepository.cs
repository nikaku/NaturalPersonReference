using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class LocaleResourceRepository : Repository<LocaleResource>, ILocaleResourceRepository
    {
        public LocaleResourceRepository(DataContext context) : base(context)
        {
        }
        private DataContext LocaleResourceContext => Context as DataContext;
    }
}
