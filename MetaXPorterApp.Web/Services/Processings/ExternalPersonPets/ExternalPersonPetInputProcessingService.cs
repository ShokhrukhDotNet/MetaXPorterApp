//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Services.Processings.ExternalPersonPets
{
    public class ExternalPersonPetInputProcessingService : IExternalPersonPetInputProcessingService
    {
        private readonly IExternalPersonPetInputService externalPersonPetInputService;

        public ExternalPersonPetInputProcessingService(
            IExternalPersonPetInputService externalPersonPetInputService) =>
                this.externalPersonPetInputService = externalPersonPetInputService;

        public ValueTask UploadExternalPersonPetsFileAsync(IFormFile file) =>
            this.externalPersonPetInputService.UploadExternalPersonPetsFileAsync(file);
    }
}
