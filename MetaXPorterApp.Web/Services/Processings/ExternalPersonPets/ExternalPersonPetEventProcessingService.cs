//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets;

namespace MetaXPorterApp.Web.Services.Processings.ExternalPersonPets
{
    public class ExternalPersonPetEventProcessingService : IExternalPersonPetEventProcessingService
    {
        private readonly IExternalPersonPetEventService externalPersonPetEventService;

        public ExternalPersonPetEventProcessingService(
            IExternalPersonPetEventService externalPersonPetEventService) =>
                this.externalPersonPetEventService = externalPersonPetEventService;

        public ValueTask AddExternalPersonPets(List<ExternalPerson> externalPersonPets) =>
            this.externalPersonPetEventService.AddExternalPersonPets(externalPersonPets);

        public ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets() =>
            this.externalPersonPetEventService.RetrieveExternalPersonPets();
    }
}
