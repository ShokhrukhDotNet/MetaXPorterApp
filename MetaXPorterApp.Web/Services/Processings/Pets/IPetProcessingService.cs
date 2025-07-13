//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Pets;

namespace MetaXPorterApp.Web.Services.Processings.Pets
{
    public interface IPetProcessingService
    {
        ValueTask<Pet> UpsertPetAsync(Pet pet);
        IQueryable<Pet> RetrieveAllPets();
    }
}
