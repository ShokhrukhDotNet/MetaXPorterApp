//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Brokers.Queues;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public class ExternalPersonPetEventService : IExternalPersonPetEventService
    {
        private readonly IQueueBroker queueBroker;

        public ExternalPersonPetEventService(IQueueBroker queueBroker) =>
            this.queueBroker = queueBroker;

        public ValueTask AddExternalPersonPets(List<ExternalPerson> externalPersonPets) =>
            this.queueBroker.AddExternalPersonPets(externalPersonPets);

        public ValueTask<List<ExternalPerson>> RetrieveExternalPersonPets() =>
            this.queueBroker.ReadExternalPersonPets();
    }
}
