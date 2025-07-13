//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;

namespace MetaXPorterApp.Web.Brokers.Queues
{
    public partial interface IQueueBroker
    {
        ValueTask AddExternalPersonPets(List<ExternalPerson> externalPersonPets);
        ValueTask<List<ExternalPerson>> ReadExternalPersonPets();
    }
}
