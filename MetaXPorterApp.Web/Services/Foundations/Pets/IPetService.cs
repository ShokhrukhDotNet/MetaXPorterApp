//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Pets;

namespace MetaXPorterApp.Web.Services.Foundations.Pets
{
    public interface IPetService
    {
        ValueTask<Pet> AddPetAsync(Pet pet);
        IQueryable<Pet> RetrieveAllPets();
        ValueTask<Pet> RetrievePetByIdAsync(Guid petId);
        ValueTask<Pet> ModifyPetAsync(Pet pet);
    }
}
