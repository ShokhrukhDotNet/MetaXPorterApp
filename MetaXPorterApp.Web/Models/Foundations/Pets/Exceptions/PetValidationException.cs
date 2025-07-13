//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class PetValidationException : Xeption
    {
        public PetValidationException(Xeption innerException)
            : base(message: "Pet validation error occured, fix the errors and try again",
                  innerException)
        { }
    }
}
