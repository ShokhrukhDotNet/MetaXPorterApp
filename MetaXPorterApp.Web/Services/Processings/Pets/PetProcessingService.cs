//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using MetaXPorterApp.Web.Services.Foundations.Pets;

namespace MetaXPorterApp.Web.Services.Processings.Pets
{
    public class PetProcessingService : IPetProcessingService
    {
        private readonly IPetService petService;

        public PetProcessingService(IPetService petService) =>
            this.petService = petService;

        public async ValueTask<Pet> UpsertPetAsync(Pet pet)
        {
            Pet maybePet = RetrievePet(pet);

            return maybePet switch
            {
                null => await this.petService.AddPetAsync(pet),
                _ => await this.petService.ModifyPetAsync(pet)
            };
        }

        private Pet RetrievePet(Pet pet)
        {
            IQueryable<Pet> retrievedPets =
                this.petService.RetrieveAllPets();

            return retrievedPets.FirstOrDefault(storagePet =>
                storagePet.Id == pet.Id);
        }

        public IQueryable<Pet> RetrieveAllPets() =>
            this.petService.RetrieveAllPets();
    }
}
