//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MetaXPorterApp.Web.Models.Foundations.Persons;

namespace MetaXPorterApp.Web.Brokers.Sheets
{
    public partial class SheetBroker
    {
        public async ValueTask SavePeopleWithPetsToXmlFile(IEnumerable<Person> peopleWithPets, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            await using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            xmlSerializer.Serialize(fileStream, peopleWithPets);
        }

        public async ValueTask<MemoryStream> RetrievePeopleWithPetsXmlFile(string filePath)
        {
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            return new MemoryStream(fileBytes);
        }
    }
}
