//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions
{
    public class EmptyExternalPersonPetInputFileException : Xeption
    {
        public EmptyExternalPersonPetInputFileException()
            : base(message: "Input file is empty. Please upload a non-empty file.")
        { }
    }
}
