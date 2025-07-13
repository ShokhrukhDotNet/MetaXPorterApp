//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class PersonDependencyException : Xeption
    {
        public PersonDependencyException(Xeption innerException)
            : base(message: "Person dependency error occurred, contact support",
                  innerException)
        { }
    }
}
