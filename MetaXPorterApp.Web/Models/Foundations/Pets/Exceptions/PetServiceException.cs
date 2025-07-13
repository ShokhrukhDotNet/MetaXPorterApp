//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class PetServiceException : Xeption
    {
        public PetServiceException(Xeption innerException)
            : base(message: "Pet service error occurred, contact support",
                  innerException)
        { }
    }
}
