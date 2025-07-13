//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using Xeptions;

namespace MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions
{
    public class FailedPersonStorageException : Xeption
    {
        public FailedPersonStorageException(Exception innerException)
            : base(message: "Failed person storage error occurred, contact support",
                  innerException)
        { }
    }
}
