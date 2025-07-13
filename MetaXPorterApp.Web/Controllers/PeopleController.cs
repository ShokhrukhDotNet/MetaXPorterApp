//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorterApp.Web.Models.Orchestrations.PersonPets;
using MetaXPorterApp.Web.Services.Coordinations;
using MetaXPorterApp.Web.Services.Orchestrations.Persons;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MetaXPorterApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : RESTFulController
    {
        private readonly IPersonPetEventCoordinationService personPetEventCoordinationService;
        private readonly IPersonOrchestrationService personOrchestrationService;

        public PeopleController(
            IPersonPetEventCoordinationService personPetEventCoordinationService,
            IPersonOrchestrationService personOrchestrationService)
        {
            this.personPetEventCoordinationService = personPetEventCoordinationService;
            this.personOrchestrationService = personOrchestrationService;

        }

        [HttpGet]
        public async ValueTask<ActionResult<List<PersonPet>>> GetStoredPeople() =>
            Ok(await this.personPetEventCoordinationService.CoordinateExternalPersonPetsAsync());

        [HttpGet("export/download")]
        public async ValueTask<ActionResult> DownloadPeopleWithPetsXml()
        {
            await this.personOrchestrationService.ExportAllPeopleWithPetsToXmlAsync();

            Stream xmlFileStream =
                await this.personOrchestrationService.RetrievePeopleWithPetsXmlFileAsync();

            return File(xmlFileStream, "application/xml", "PeopleWithPets.xml");
        }
    }
}
