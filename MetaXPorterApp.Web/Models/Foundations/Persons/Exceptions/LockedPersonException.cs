//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class LockedPersonException : Xeption
    {
        public LockedPersonException(Exception innerException)
            : base(message: "Person is locked, please try again", innerException)
        { }
    }
}
