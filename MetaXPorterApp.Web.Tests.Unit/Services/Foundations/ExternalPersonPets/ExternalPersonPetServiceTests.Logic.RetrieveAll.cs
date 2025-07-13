//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllExternalPersonPets()
        {
            // given
            List<ExternalPerson> randomExternalPersonPets = CreateRandomExternalPersonPets();
            List<ExternalPerson> storageExternalPersonPets = randomExternalPersonPets;
            List<ExternalPerson> expectedExternalPersonPets = storageExternalPersonPets.DeepClone();

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync())
                    .ReturnsAsync(storageExternalPersonPets);

            // when
            List<ExternalPerson> actualExternalPersonPets =
                await this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync();

            // then
            actualExternalPersonPets.Should().BeEquivalentTo(expectedExternalPersonPets);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(),
                    Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
