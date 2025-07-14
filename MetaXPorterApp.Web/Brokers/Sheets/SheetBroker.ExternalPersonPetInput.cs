//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MetaXPorterApp.Web.Brokers.Sheets
{
    public partial class SheetBroker
    {
        public async ValueTask UploadExternalPersonPetsFileAsync(IFormFile file)
        {
            string filePath = GetSheetLocationWithName();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
