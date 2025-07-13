//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Services.Processings.ExternalPersonPets
{
    public interface IExternalPersonPetInputProcessingService
    {
        ValueTask UploadExternalPersonPetsFileAsync(IFormFile file);
    }
}
