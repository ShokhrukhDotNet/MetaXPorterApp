//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetInputService
    {
        private delegate ValueTask ReturningFileFunction();

        private async ValueTask TryCatch(ReturningFileFunction returningFileFunction)
        {
            try
            {
                await returningFileFunction();
            }
            catch (NullExternalPersonPetInputFileException nullFileException)
            {
                this.loggingBroker.LogError(nullFileException);
                throw;
            }
            catch (EmptyExternalPersonPetInputFileException emptyFileException)
            {
                this.loggingBroker.LogError(emptyFileException);
                throw;
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError(exception);
                throw;
            }
        }
    }
}
