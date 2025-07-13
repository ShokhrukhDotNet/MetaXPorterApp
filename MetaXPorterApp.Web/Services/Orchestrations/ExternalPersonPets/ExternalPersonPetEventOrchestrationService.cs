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
    public class ExternalPersonPetEventOrchestrationService : IExternalPersonPetEventOrchestrationService
    {
        private readonly IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService;

        public ExternalPersonPetEventOrchestrationService(
            IExternalPersonPetEventProcessingService externalPersonPetEventProcessingService) =>
                this.externalPersonPetEventProcessingService = externalPersonPetEventProcessingService;

        public ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets() =>
            this.externalPersonPetEventProcessingService.RetrieveExternalPersonPets();
    }
}
