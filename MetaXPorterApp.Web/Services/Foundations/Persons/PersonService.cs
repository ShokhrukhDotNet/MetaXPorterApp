//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Brokers.Loggings;
using MetaXPorterApp.Web.Brokers.Storages;
using MetaXPorterApp.Web.Models.Foundations.Persons;

namespace MetaXPorterApp.Web.Services.Foundations.Persons
{
    public partial class PersonService : IPersonService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public PersonService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Person> AddPersonAsync(Person person) =>
        TryCatch(async () =>
        {
            ValidatePersonOnAdd(person);

            return await storageBroker.InsertPersonAsync(person);
        });

        public ValueTask<Person> RetrievePersonByIdAsync(Guid personId) =>
        TryCatch(async () =>
        {
            ValidatePersonId(personId);

            Person maybePerson = await this.storageBroker.SelectPersonByIdAsync(personId);

            ValidateStoragePerson(maybePerson, personId);

            return maybePerson;
        });


        public IQueryable<Person> RetrieveAllPeople() =>
            TryCatch(() => this.storageBroker.SelectAllPeople());

        public IQueryable<Person> RetrieveAllPeopleWithPets() =>
            TryCatch(() => this.storageBroker.SelectAllPeopleWithPets());

        public ValueTask<Person> ModifyPersonAsync(Person person) =>
        TryCatch(async () =>
        {
            ValidatePersonOnModify(person);

            Person maybePerson =
                await this.storageBroker.SelectPersonByIdAsync(person.Id);

            ValidateAgainstStoragePersonOnModify(person, maybePerson);

            return await storageBroker.UpdatePersonAsync(person);
        });
    }
}
