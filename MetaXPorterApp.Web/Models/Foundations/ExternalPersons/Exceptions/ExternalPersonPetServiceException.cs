//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class ExternalPersonPetServiceException : Xeption
    {
        public ExternalPersonPetServiceException(Xeption innerException)
            : base(message: "Externalpersonpet service error occurred, contact support",
                  innerException)
        { }
    }
}
