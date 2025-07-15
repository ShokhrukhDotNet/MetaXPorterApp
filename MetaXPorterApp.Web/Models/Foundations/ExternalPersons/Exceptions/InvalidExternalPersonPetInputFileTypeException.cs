//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class InvalidExternalPersonPetInputFileTypeException : Xeption
    {
        public InvalidExternalPersonPetInputFileTypeException(string fileName)
            : base(message: $"The uploaded file type is invalid: '{fileName}'. Please upload a valid Excel (.xlsx) or (.xls) file.")
        { }
    }
}
