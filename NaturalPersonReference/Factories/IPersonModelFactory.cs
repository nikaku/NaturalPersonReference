using NaturalPersonReference.BL.Entities;
using NaturalPersonReference.Models.Person;

namespace NaturalPersonReference.Factories
{
    public interface IPersonModelFactory
    {
        PersonModel PreparePersonModel(Person person = null);
        PersonListModel PreparePersonListModel(int pageNumber, string searchString);
    }
}
