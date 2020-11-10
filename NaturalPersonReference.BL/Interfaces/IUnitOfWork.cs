﻿using NaturalPersonReference.BL.Interfaces.Repositories;

namespace NaturalPersonReference.BL.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
        ICityRepository CityRepository { get; }
        IPhoneRepository PhoneRepository { get; }

        void SaveChanges();
        void Dispose();
    }
}