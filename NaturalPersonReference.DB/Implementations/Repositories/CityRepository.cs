using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.BL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaturalPersonReference.DB.Implementations.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {
        }

        public DataContext CityContext => Context as DataContext;
    }
}
