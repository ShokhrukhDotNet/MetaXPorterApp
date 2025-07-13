//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Brokers.Loggings;
using MetaXPorterApp.Web.Brokers.Sheets;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;

namespace MetaXPorterApp.Web.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetService : IExternalPersonPetService
    {
        private readonly ISheetBroker sheetBroker;
        private readonly ILoggingBroker loggingBroker;

        public ExternalPersonPetService(
            ISheetBroker sheetBroker,
            ILoggingBroker loggingBroker)
        {
            this.sheetBroker = sheetBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<ExternalPerson>> RetrieveAllExternalPersonPetsAsync() =>
        TryCatch(async () =>
            await this.sheetBroker.ReadAllExternalPersonPetsAsync());
    }
}