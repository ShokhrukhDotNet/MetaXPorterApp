//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class PetDependencyValidationException : Xeption
    {
        public PetDependencyValidationException(Xeption innerException)
            : base(message: "Pet dependency validation error occurred, fix the errors and try again",
                   innerException)
        { }
    }
}
