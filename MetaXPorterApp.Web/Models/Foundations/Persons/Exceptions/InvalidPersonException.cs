//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class InvalidPersonException : Xeption
    {
        public InvalidPersonException()
            : base(message: "Person is invalid")
        { }
    }
}
