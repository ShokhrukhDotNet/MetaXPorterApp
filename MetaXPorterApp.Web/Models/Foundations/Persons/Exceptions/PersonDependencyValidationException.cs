//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class PersonDependencyValidationException : Xeption
    {
        public PersonDependencyValidationException(Xeption innerException)
            : base(message: "Person dependency validation error occurred, fix the errors and try again",
                   innerException)
        { }
    }
}
