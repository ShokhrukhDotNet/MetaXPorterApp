//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using Microsoft.EntityFrameworkCore;

namespace MetaXPorterApp.Web.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Person> People { get; set; }

        public async ValueTask<Person> InsertPersonAsync(Person person) =>
            await InsertAsync(person);

        public IQueryable<Person> SelectAllPeople() => SelectAll<Person>();

        public IQueryable<Person> SelectAllPeopleWithPets() =>
            this.People.Include(person => person.Pets);

        public async ValueTask<Person> SelectPersonByIdAsync(Guid personId) =>
            await SelectAsync<Person>(personId);

        public async ValueTask<Person> UpdatePersonAsync(Person person) =>
            await UpdateAsync(person);
    }
}
