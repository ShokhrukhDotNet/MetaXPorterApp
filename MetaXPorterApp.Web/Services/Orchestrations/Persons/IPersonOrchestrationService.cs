//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using System.Threading.Tasks;

namespace MetaXPorterApp.Web.Services.Orchestrations.Persons
{
    public interface IPersonOrchestrationService
    {
        ValueTask ExportAllPeopleWithPetsToXmlAsync();
        ValueTask<Stream> RetrievePeopleWithPetsXmlFileAsync();
    }
}
