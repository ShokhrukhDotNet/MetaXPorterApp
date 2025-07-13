//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class PetDependencyException : Xeption
    {
        public PetDependencyException(Xeption innerException)
            : base(message: "Pet dependency error occurred, contact support",
                  innerException)
        { }
    }
}
