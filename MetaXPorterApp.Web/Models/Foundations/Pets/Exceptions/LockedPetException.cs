//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class LockedPetException : Xeption
    {
        public LockedPetException(Exception innerException)
            : base(message: "Pet is locked, please try again", innerException)
        { }
    }
}
