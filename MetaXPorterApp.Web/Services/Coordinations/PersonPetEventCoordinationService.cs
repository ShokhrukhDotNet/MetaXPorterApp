//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using MetaXPorterApp.Web.Models.Foundations.Pets;
using MetaXPorterApp.Web.Models.Orchestrations.PersonPets;
using MetaXPorterApp.Web.Services.Orchestrations.ExternalPersonPets;
using MetaXPorterApp.Web.Services.Orchestrations.PersonPets;

namespace MetaXPorterApp.Web.Services.Coordinations
{
    public class PersonPetEventCoordinationService : IPersonPetEventCoordinationService
    {
        private readonly IExternalPersonPetOrchestrationService externalPersonPetOrchestrationService;
        private readonly IExternalPersonPetEventOrchestrationService externalPersonPetEventOrchestrationService;
        private readonly IPersonPetOrchestrationService personPetOrchestrationService;

        public PersonPetEventCoordinationService(
            IExternalPersonPetOrchestrationService externalPersonPetOrchestrationService,
            IExternalPersonPetEventOrchestrationService externalPersonPetEventOrchestrationService,
            IPersonPetOrchestrationService personPetOrchestrationService)
        {
            this.externalPersonPetOrchestrationService = externalPersonPetOrchestrationService;
            this.externalPersonPetEventOrchestrationService = externalPersonPetEventOrchestrationService;
            this.personPetOrchestrationService = personPetOrchestrationService;
        }

        public async ValueTask<List<PersonPet>> CoordinateExternalPersonPetsAsync()
        {
            await this.externalPersonPetOrchestrationService.RetrieveAndAddFormattedExternalPersonPetsAsync();

            List<ExternalPerson> externalPersons =
                await this.externalPersonPetEventOrchestrationService.RetrieveExternalPersonPets();

            var personsWithPets = new List<PersonPet>();

            foreach (var externalPerson in externalPersons)
            {
                var personId = Guid.NewGuid();

                var person = new Person
                {
                    Id = personId,
                    Name = externalPerson.PersonName,
                    Age = externalPerson.Age
                };

                var pets = MapPets(externalPerson, personId);

                var personPet = new PersonPet
                {
                    Person = person,
                    Pets = pets
                };

                PersonPet processedPersonPet =
                    await this.personPetOrchestrationService.ProcessPersonWithPetsAsync(personPet);

                personsWithPets.Add(processedPersonPet);
            }

            return personsWithPets;
        }

        private List<Pet> MapPets(ExternalPerson externalPerson, Guid personId)
        {
            var pets = new List<Pet>();

            if (!string.IsNullOrWhiteSpace(externalPerson.PetOne))
            {
                pets.Add(new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetOne,
                    Type = MapToPetType(externalPerson.PetOneType),
                    PersonId = personId
                });
            }

            if (!string.IsNullOrWhiteSpace(externalPerson.PetTwo))
            {
                pets.Add(new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetTwo,
                    Type = MapToPetType(externalPerson.PetTwoType),
                    PersonId = personId
                });
            }

            if (!string.IsNullOrWhiteSpace(externalPerson.PetThree))
            {
                pets.Add(new Pet
                {
                    Id = Guid.NewGuid(),
                    Name = externalPerson.PetThree,
                    Type = MapToPetType(externalPerson.PetThreeType),
                    PersonId = personId
                });
            }

            return pets;
        }

        private PetType MapToPetType(string petType)
        {
            return Enum.TryParse(petType, ignoreCase: true, out PetType mappedPetType)
                ? mappedPetType
                : PetType.Other;
        }
    }
}
