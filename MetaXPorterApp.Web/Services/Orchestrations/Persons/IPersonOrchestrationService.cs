//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Persons;

namespace MetaXPorterApp.Web.Services.Orchestrations.Persons
{
    public interface IPersonOrchestrationService
    {
        ValueTask ExportAllPeopleWithPetsToXmlAsync();
        ValueTask<Stream> RetrievePeopleWithPetsXmlFileAsync();
        IQueryable<Person> RetrieveAllPeopleWithPets();
    }
}
