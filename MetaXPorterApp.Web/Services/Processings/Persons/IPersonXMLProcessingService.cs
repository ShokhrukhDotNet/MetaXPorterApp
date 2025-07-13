//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Persons;

namespace MetaXPorterApp.Web.Services.Processings.Persons
{
    public interface IPersonXMLProcessingService
    {
        ValueTask ExportPersonPetsToXml(IEnumerable<Person> persons, string filePath);
        ValueTask<Stream> RetrievePersonPetsXml(string filePath);
    }
}
