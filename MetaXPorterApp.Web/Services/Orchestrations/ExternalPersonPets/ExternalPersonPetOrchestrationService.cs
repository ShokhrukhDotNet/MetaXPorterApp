//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using MetaXPorterApp.Web.Services.Processings.ExternalPersonPets;

namespace MetaXPorterApp.Web.Services.Orchestrations.ExternalPersonPets
{
    public class ExternalPersonPetOrchestrationService : IExternalPersonPetOrchestrationService
    {
        private readonly IExternalPersonPetProcessingService externalPersonPetProcessingService;
        private readonly IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService;

        public ExternalPersonPetOrchestrationService(
            IExternalPersonPetProcessingService externalPersonPetProcessingService,
            IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService)
        {
            this.externalPersonPetProcessingService = externalPersonPetProcessingService;
            this.externalPersonPetEventProcessingService = externalPersonPetEventProcessingService;
        }

        public async ValueTask RetrieveAndAddFormattedExternalPersonPetsAsync()
        {
            List<ExternalPerson> formattedExternalPersonPets =
                await this.externalPersonPetProcessingService
                    .RetrieveFormattedExternalPersonPetsAsync();

            await this.externalPersonPetEventProcessingService
                .AddExternalPersonPets(formattedExternalPersonPets);
        }
    }
}
