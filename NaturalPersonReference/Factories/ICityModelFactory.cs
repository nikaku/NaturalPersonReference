using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;

namespace NaturalPersonReference.Factories
{
    public interface ICityModelFactory
    {
        void PrepareCityModel(CityModel model, City city);
    }
}
