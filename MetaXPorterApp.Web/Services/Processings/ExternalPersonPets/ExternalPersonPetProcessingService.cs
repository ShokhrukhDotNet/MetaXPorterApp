//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets;

namespace MetaXPorterApp.Web.Services.Processings.ExternalPersonPets
{
    public class ExternalPersonPetProcessingService : IExternalPersonPetProcessingService
    {
        private readonly IExternalPersonPetService externalPersonPetService;

        public ExternalPersonPetProcessingService(
            IExternalPersonPetService externalPersonPetService) =>
                this.externalPersonPetService = externalPersonPetService;

        public async ValueTask<List<ExternalPerson>> RetrieveFormattedExternalPersonPetsAsync()
        {
            var retrievedExternalPersonPets =
                await this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync();

            List<ExternalPerson> formattedExternalPersonPets =
                FormatProperties(retrievedExternalPersonPets);

            return formattedExternalPersonPets;
        }

        private List<ExternalPerson> FormatProperties(List<ExternalPerson> retrievedExternalPersonPets)
        {
            var formattedExternalPersonPets = retrievedExternalPersonPets.Select(retrievedPersonPet =>
                new ExternalPerson()
                {
                    PersonName = retrievedPersonPet.PersonName,
                    Age = retrievedPersonPet.Age,
                    PetOne = retrievedPersonPet.PetOne.Trim().Replace("-", string.Empty),
                    PetOneType = retrievedPersonPet.PetOneType.Trim().Replace("-", string.Empty),
                    PetTwo = retrievedPersonPet.PetTwo.Trim().Replace("-", string.Empty),
                    PetTwoType = retrievedPersonPet.PetTwoType.Trim().Replace("-", string.Empty),
                    PetThree = retrievedPersonPet.PetThree.Trim().Replace("-", string.Empty),
                    PetThreeType = retrievedPersonPet.PetThreeType.Trim().Replace("-", string.Empty),
                });

            return formattedExternalPersonPets.ToList();
        }
    }
}
