//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public interface IExternalPersonPetInputService
    {
        ValueTask UploadExternalPersonPetsFileAsync(IFormFile file);
    }
}
