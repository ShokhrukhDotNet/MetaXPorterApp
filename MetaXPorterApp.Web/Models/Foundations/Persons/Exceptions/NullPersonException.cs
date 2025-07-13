//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class NullPersonException : Xeption
    {
        public NullPersonException()
            : base(message: "Person is null")
        { }
    }
}
