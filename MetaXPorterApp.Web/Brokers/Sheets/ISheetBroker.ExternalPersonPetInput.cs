//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Brokers.Sheets
{
    public partial interface ISheetBroker
    {
        ValueTask UploadExternalPersonPetsFileAsync(IFormFile file);
    }
}
