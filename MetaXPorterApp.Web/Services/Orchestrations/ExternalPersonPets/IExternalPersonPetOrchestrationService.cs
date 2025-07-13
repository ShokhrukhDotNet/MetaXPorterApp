//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;

namespace MetaXPorterApp.Web.Services.Orchestrations.ExternalPersonPets
{
    public interface IExternalPersonPetOrchestrationService
    {
        ValueTask RetrieveAndAddFormattedExternalPersonPetsAsync();
    }
}
