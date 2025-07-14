//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetInputService
    {
        private static void ValidateFile(IFormFile file)
        {
            if (file == null)
            {
                throw new NullExternalPersonPetInputFileException();
            }

            if (file.Length == 0)
            {
                throw new EmptyExternalPersonPetInputFileException();
            }
        }
    }
}
