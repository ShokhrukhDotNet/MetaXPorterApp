//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class FailedExternalPersonPetServiceException : Xeption
    {
        public FailedExternalPersonPetServiceException(Exception innerException)
            : base(message: "Failed externalpersonpet service error occurred, contact support",
                  innerException)
        { }
    }
}
