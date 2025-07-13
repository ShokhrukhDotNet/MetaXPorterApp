//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class FailedExternalPersonPetDependencyException : Xeption
    {
        public FailedExternalPersonPetDependencyException(Exception innerException)
            : base(message: "Failed externalpersonpet dependency error occurred, contact support",
                  innerException)
        { }
    }
}
