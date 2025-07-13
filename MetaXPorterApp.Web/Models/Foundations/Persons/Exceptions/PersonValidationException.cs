//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class PersonValidationException : Xeption
    {
        public PersonValidationException(Xeption innerException)
            : base(message: "Person validation error occured, fix the errors and try again",
                  innerException)
        { }
    }
}
