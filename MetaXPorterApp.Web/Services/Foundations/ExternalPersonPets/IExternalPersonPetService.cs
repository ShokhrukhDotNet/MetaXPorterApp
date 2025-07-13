//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public interface IExternalPersonPetService
    {
        ValueTask<List<ExternalPerson>> RetrieveAllExternalPersonPetsAsync();
    }
}