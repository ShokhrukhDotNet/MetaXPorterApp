//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Persons;

namespace MetaXPorterApp.Web.Services.Foundations.Persons
{
    public interface IPersonService
    {
        ValueTask<Person> AddPersonAsync(Person person);
        IQueryable<Person> RetrieveAllPeople();
        IQueryable<Person> RetrieveAllPeopleWithPets();
        ValueTask<Person> RetrievePersonByIdAsync(Guid personId);
        ValueTask<Person> ModifyPersonAsync(Person person);
    }
}
