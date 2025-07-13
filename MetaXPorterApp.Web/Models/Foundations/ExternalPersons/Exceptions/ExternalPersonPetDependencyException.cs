//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class ExternalPersonPetDependencyException : Xeption
    {
        public ExternalPersonPetDependencyException(Exception innerException)
            : base(message: "Externalpersonpet dependency error occurred, contact support",
                  innerException)
        { }
    }
}
