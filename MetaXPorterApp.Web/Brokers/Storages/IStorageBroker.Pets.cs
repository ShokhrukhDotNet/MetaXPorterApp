//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Pets;

namespace MetaXPorterApp.Web.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Pet> InsertPetAsync(Pet pet);
        IQueryable<Pet> SelectAllPets();
        ValueTask<Pet> SelectPetByIdAsync(Guid petId);
        ValueTask<Pet> UpdatePetAsync(Pet pet);
    }
}
