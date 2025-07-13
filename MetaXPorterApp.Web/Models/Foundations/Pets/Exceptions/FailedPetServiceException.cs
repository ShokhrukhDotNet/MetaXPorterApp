//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class FailedPetServiceException : Xeption
    {
        public FailedPetServiceException(Exception innerException)
            : base(message: "Failed pet service error occurred, contact support",
                  innerException)
        { }
    }
}
