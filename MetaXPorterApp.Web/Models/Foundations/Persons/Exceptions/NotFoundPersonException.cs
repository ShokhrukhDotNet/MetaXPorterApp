//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class NotFoundPersonException : Xeption
    {
        public NotFoundPersonException(Guid personId)
            : base(message: $"Couldn't find person with id {personId}")
        { }
    }
}
