//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class InvalidPetException : Xeption
    {
        public InvalidPetException()
            : base(message: "Pet is invalid")
        { }
    }
}
