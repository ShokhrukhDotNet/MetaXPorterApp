//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class PersonServiceException : Xeption
    {
        public PersonServiceException(Xeption innerException)
            : base(message: "Person service error occurred, contact support",
                  innerException)
        { }
    }
}
