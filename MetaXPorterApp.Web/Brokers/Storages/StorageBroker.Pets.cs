//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using Microsoft.EntityFrameworkCore;

namespace MetaXPorterApp.Web.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Pet> Pets { get; set; }

        public async ValueTask<Pet> InsertPetAsync(Pet pet) =>
            await InsertAsync(pet);

        public IQueryable<Pet> SelectAllPets() => SelectAll<Pet>();

        public async ValueTask<Pet> SelectPetByIdAsync(Guid petId) =>
            await SelectAsync<Pet>(petId);

        public async ValueTask<Pet> UpdatePetAsync(Pet pet) =>
            await UpdateAsync(pet);
    }
}
