//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Orchestrations.PersonPets;

namespace MetaXPorterApp.Web.Services.Coordinations
{
    public interface IPersonPetEventCoordinationService
    {
        ValueTask<List<PersonPet>> CoordinateExternalPersonPetsAsync();
    }
}
