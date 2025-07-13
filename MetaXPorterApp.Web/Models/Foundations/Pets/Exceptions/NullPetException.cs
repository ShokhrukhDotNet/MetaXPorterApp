//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Pets.Exceptions
{
    public class NullPetException : Xeption
    {
        public NullPetException()
            : base(message: "Pet is null")
        { }
    }
}
