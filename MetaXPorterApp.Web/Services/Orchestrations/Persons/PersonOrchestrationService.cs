//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using MetaXPorterApp.Web.Services.Processings.Persons;
using Xeptions;

namespace MetaXPorterApp.Web.Services.Orchestrations.Persons
{
    public class PersonOrchestrationService : IPersonOrchestrationService
    {
        private readonly IPersonProcessingService personProcessingService;
        private readonly IPersonXMLProcessingService personXMLProcessingService;

        private const string XmlFilePath = @"C:\Users\User\Desktop\MetaXPorterApp\MetaXPorterApp.Web\Resources\Export template.xml";

        public PersonOrchestrationService(
            IPersonProcessingService personProcessingService,
            IPersonXMLProcessingService personXMLProcessingService)
        {
            this.personProcessingService = personProcessingService;
            this.personXMLProcessingService = personXMLProcessingService;
        }

        public async ValueTask ExportAllPeopleWithPetsToXmlAsync()
        {
            try
            {
                var peopleWithPets =
                    this.personProcessingService.RetrieveAllPeopleWithPets().ToList();

                await this.personXMLProcessingService.ExportPersonPetsToXml(
                    peopleWithPets, XmlFilePath);
            }
            catch (Exception exception)
            {
                throw new Xeption(
                    message: "Orchestration service error occurred, contact support",
                    innerException: exception);
            }
        }

        public async ValueTask<Stream> RetrievePeopleWithPetsXmlFileAsync()
        {
            try
            {
                return await this.personXMLProcessingService
                    .RetrievePersonPetsXml(XmlFilePath);
            }
            catch (Exception exception)
            {
                throw new Xeption(
                    message: "Error occurred while retrieving the exported XML file.",
                    innerException: exception);
            }
        }

        public IQueryable<Person> RetrieveAllPeopleWithPets() =>
            this.personProcessingService.RetrieveAllPeopleWithPets();
    }
}
