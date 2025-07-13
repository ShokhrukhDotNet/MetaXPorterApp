//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class FailedPetStorageException : Xeption
    {
        public FailedPetStorageException(Exception innerException)
            : base(message: "Failed pet storage error occurred, contact support",
                  innerException)
        { }
    }
}
