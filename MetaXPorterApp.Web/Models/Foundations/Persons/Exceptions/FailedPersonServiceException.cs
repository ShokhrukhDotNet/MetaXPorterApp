//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class FailedPersonServiceException : Xeption
    {
        public FailedPersonServiceException(Exception innerException)
            : base(message: "Failed person service error occurred, contact support",
                  innerException)
        { }
    }
}
