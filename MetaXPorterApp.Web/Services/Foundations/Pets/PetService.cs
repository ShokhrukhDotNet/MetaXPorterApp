//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Brokers.Loggings;
using MetaXPorterApp.Web.Brokers.Storages;
using MetaXPorterApp.Web.Models.Foundations.Pets;

namespace MetaXPorterApp.Web.Services.Foundations.Pets
{
    public partial class PetService : IPetService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public PetService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Pet> AddPetAsync(Pet pet) =>
        TryCatch(async () =>
        {
            ValidatePetOnAdd(pet);

            return await storageBroker.InsertPetAsync(pet);
        });

        public ValueTask<Pet> RetrievePetByIdAsync(Guid petId) =>
        TryCatch(async () =>
        {
            ValidatePetId(petId);

            Pet maybePet = await this.storageBroker.SelectPetByIdAsync(petId);

            ValidateStoragePet(maybePet, petId);

            return maybePet;
        });

        public IQueryable<Pet> RetrieveAllPets() =>
            TryCatch(() => this.storageBroker.SelectAllPets());

        public ValueTask<Pet> ModifyPetAsync(Pet pet) =>
        TryCatch(async () =>
        {
            ValidatePetOnModify(pet);

            Pet maybePet =
                await this.storageBroker.SelectPetByIdAsync(pet.Id);

            ValidateAgainstStoragePetOnModify(pet, maybePet);

            return await storageBroker.UpdatePetAsync(pet);
        });
    }
}
